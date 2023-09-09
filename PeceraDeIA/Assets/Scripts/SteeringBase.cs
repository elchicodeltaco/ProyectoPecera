using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBase : MonoBehaviour
{
    public bool Active = false;
    protected Rigidbody MiRigidbody;
    public float weight = 1.0f;

    // Start is called before the first frame update
    void Awake() //Ejecutado antes de Start
    {
        MiRigidbody = GetComponent<Rigidbody>();
    }

    public abstract Vector3 CalcularSteering();

    // Update is called once per frame
    /*protected void Update()
    {
        if (Active)
        {
            Vector3 fuerza = CalcularSteering();
            MiRigidbody.AddForce(fuerza);
        }
    }*/
}




