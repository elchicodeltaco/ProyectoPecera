using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separacion : SteeringBase
{
    public float radioSeparacion = 5f;
    public LayerMask capaAgentes;

    public override Vector3 CalcularSteering()
    {
        Vector3 steeringForce = Vector3.zero;

        Collider[] agentesCercanos = Physics.OverlapSphere
            (transform.position, radioSeparacion, capaAgentes);

        foreach (Collider agente in agentesCercanos)
        {
            if (agente.gameObject != gameObject)
            {
                Vector3 direccionSeparacion = transform.position - agente.transform.position;
                float distancia = direccionSeparacion.magnitude;
                steeringForce += direccionSeparacion.normalized / distancia;
            }
        }
        return steeringForce;
    }
}
