using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBlend : MonoBehaviour
{
    public float maxForce = 5.0f;
    public float maxSpeed = 1f;
    private List<SteeringBase> comportamientos =
        new List<SteeringBase>();
    // Start is called before the first frame update
    void Start()
    {
        SteeringBase[] arreglo = GetComponents<SteeringBase>();
        for (int a = 0; a < arreglo.Length; a++)
        {
            comportamientos.Add(arreglo[a]);
        }
    }

    Vector3 WeightedTruncatedSum()
    {
        Vector3 fuerzaTotal = Vector3.zero;
        foreach (SteeringBase steering in comportamientos)
        {
            if (steering.Active)
            {
                fuerzaTotal += steering.CalcularSteering() * steering.weight;
            }
        }
        float magnitudTotal = fuerzaTotal.magnitude;
        if (magnitudTotal > maxForce)
        {
            fuerzaTotal = fuerzaTotal.normalized * maxForce;

        }
        return fuerzaTotal;
    }
    Vector3 PrioritizedDithering()
    {
        Vector3 fuerzaTotal = Vector3.zero;
        double prWanderAvoidance = 0.5f;

        System.Random rndm = new System.Random();
        foreach (SteeringBase steering in comportamientos)
        {
            if (rndm.Next() > prWanderAvoidance)
            {
                fuerzaTotal +=
                    steering.CalcularSteering();
                break;
            }
        }

        return fuerzaTotal;


    }
    // Update is called once per frame
    void Update()
    {
        Vector3 steering = WeightedTruncatedSum();
        GetComponent<Rigidbody>().AddForce(steering);
        if (steering.magnitude > maxSpeed)
            GetComponent<Rigidbody>().velocity =
                steering.normalized * maxSpeed;
    }
}
