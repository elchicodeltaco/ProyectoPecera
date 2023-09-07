using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohesion : SteeringBase
{
    public float radioCohesion = 5f;
    public LayerMask capaAgentes;
    public float Speed = 5f; 

    public override Vector3 CalcularSteering()
    {
        Vector3 centroDeLaMasa = Vector3.zero;
        int numeroDeVecinos = 0;
        Collider[] agentesCercanos = Physics.OverlapSphere(transform.position, radioCohesion, capaAgentes);

        foreach (Collider agente in agentesCercanos)
        {
            if (agente.gameObject != gameObject)
            {
                //Aquí debe de sumar la direccion hacia donde se dirige 
                centroDeLaMasa += agente.transform.position;

                numeroDeVecinos++;
            }
        }

        if (numeroDeVecinos > 0)
        {
            //El centro de la masa es el promedio de la suma de las posiciones
            centroDeLaMasa /= numeroDeVecinos; 
        }

        return Seek(centroDeLaMasa);
    }

    private Vector3 Seek(Vector3 posicion)
    {
        Vector3 direccion = (posicion - transform.position).normalized;
        Vector3 velocidad = direccion * Speed;
        Vector3 vectorSteering = velocidad - MiRigidbody.velocity;

        return vectorSteering;
    }
}
