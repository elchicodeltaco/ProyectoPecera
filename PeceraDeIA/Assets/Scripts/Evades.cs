using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evades : SteeringBase
{
    public Transform perseguidor;
    public float maxspeed = 5.0f;
    Vector3 ToEvader;
    private float tiempoPredicción = 2f;

    //Variables Varias
    Vector3 distancia;

    // Update is called once per frame
    public override Vector3 CalcularSteering()
    {
        ToEvader = perseguidor.position - MiRigidbody.position;

        float anticipacion = ToEvader.magnitude / maxspeed;

        Vector3 predictedPosition = perseguidor.position + perseguidor.GetComponent<Rigidbody>().velocity * anticipacion * tiempoPredicción;

        // Calcula la dirección deseada para dirigirse hacia la posición predicha del perseguidor
        Vector3 velocidadDeseada = (predictedPosition - MiRigidbody.position).normalized * maxspeed;

        Vector3 steeringForce = velocidadDeseada - MiRigidbody.velocity;

        return steeringForce;
    }
}

