using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predictividad : SteeringBase
{
    public Transform evader;
    public float maxspeed = 5.0f;
    Vector3 ToEvader;
    private float tiempoPredicción = 1f;

    // Start is called before the first frame update


    // Update is called once per frame
    public override Vector3 CalcularSteering()
    {
        ToEvader = evader.position - MiRigidbody.position;

        float anticipacion = ToEvader.magnitude / maxspeed;

        Vector3 predictedPosition = evader.position + evader.GetComponent<Rigidbody>().velocity * anticipacion * tiempoPredicción;

        Vector3 velocidadDeseada = (predictedPosition - MiRigidbody.position).normalized * maxspeed;
         
        Vector3 steeringForce = velocidadDeseada - MiRigidbody.velocity;

        return steeringForce;
    }

}
