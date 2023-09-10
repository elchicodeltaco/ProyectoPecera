using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohesion : SteeringBase
{
    public float radioCohesion = 5f;
    public LayerMask capaAgentes;
    public float speed = 5f;
    public float distanciaMinima = 2f; // Distancia mínima para evitar colisiones

    public override Vector3 CalcularSteering()
    {
        Vector3 centroDeLaMasa = Vector3.zero;
        Vector3 avoidanceForce = Vector3.zero;
        int numeroDeVecinos = 0;

        Collider[] agentesCercanos = Physics.OverlapSphere(transform.position, radioCohesion, capaAgentes);

        foreach (Collider agente in agentesCercanos)
        {
            if (agente.gameObject != gameObject)
            {
                // Calcular la dirección hacia el agente
                Vector3 direccion = agente.transform.position - transform.position;
                float distancia = direccion.magnitude;

                // Si la distancia es menor que la distancia mínima, calcular una fuerza de separación
                if (distancia < distanciaMinima)
                {
                    avoidanceForce += -direccion.normalized * (distanciaMinima - distancia);
                }
                else
                {
                    // Sumar la posición para la cohesión
                    centroDeLaMasa += agente.transform.position;
                    numeroDeVecinos++;
                }
            }
        }

        if (numeroDeVecinos > 0)
        {
            // Calcular el centro de la masa como el promedio de las posiciones
            centroDeLaMasa /= numeroDeVecinos;
        }

        // Calcular la fuerza de dirección para la cohesión
        Vector3 cohesionForce = Seek(centroDeLaMasa);

        // Combinar la fuerza de cohesión con la fuerza de separación
        Vector3 steeringForce = cohesionForce + avoidanceForce;

        return steeringForce;
    }

    private Vector3 Seek(Vector3 posicion)
    {
        Vector3 direccion = (posicion - transform.position).normalized;
        Vector3 velocidad = direccion * speed;
        Vector3 vectorSteering = velocidad - MiRigidbody.velocity;

        return vectorSteering;
    }
}
