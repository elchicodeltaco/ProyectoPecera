using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivalAngel : SteeringBase
{
    public Transform target;
    public float deceleration = 5f;
    public float speed = 2f;
    public float distR = 0.1f;
    private GameObject Comidas;
    // Start is called before the first frame update

    public override Vector3 CalcularSteering()
    {
        Comidas = GameObject.FindGameObjectWithTag("Comida");
        target = Comidas.transform;
        //target = 

        if (target != null)
        {
            Vector3 direccion = target.position - transform.position;
            float distancia = direccion.magnitude;

            if (distancia <= distR)
            {
                float velocidad = speed * (distancia / distR);
                Vector3 velocidadDeseada = direccion.normalized * velocidad;

                Vector3 vectorSteering = velocidadDeseada - MiRigidbody.velocity;
                return vectorSteering;
            }
            else
            {
                Vector3 velocidadDeseada = direccion * speed;
                Vector3 vectorSteering = velocidadDeseada - MiRigidbody.velocity;
                return vectorSteering;
            }
        }
        else
        {
            return Vector3.zero;
        }

    }
}
