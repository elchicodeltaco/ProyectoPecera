using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeAngel : SteeringBase
{
    public Transform Target;
    public float speed;

    public override Vector3 CalcularSteering()
    {
        if (Target != null)
        {
            Vector3 direccion =
                (transform.position - Target.position).normalized;
            Vector3 velocidad = direccion * speed;
            Vector3 steeringForce = velocidad - MiRigidbody.velocity;
            return steeringForce;
        }
        return Vector3.zero;
    }
}

