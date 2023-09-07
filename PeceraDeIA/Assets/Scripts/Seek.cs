using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBase
{
    public Transform Target; //A donde se quiere ir
    public float Speed = 5f;

    // Update is called once per frame
    public override Vector3 CalcularSteering()
    {
        if (Target != null) //hay comportamientos que no van a necesitar preguntar esto
        {
            Vector3 direccion = (Target.position - transform.position).normalized;
            Vector3 velocidad = direccion * Speed;
            Vector3 vectorSteering = velocidad - MiRigidbody.velocity;

            return vectorSteering;
            //GetComponent<Rigidbody>().AddForce(vectorSteering);
        }

        return Vector3.zero;

    }
}

