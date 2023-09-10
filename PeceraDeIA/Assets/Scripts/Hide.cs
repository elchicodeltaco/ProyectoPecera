using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : SteeringBase
{
    public Transform target;
    public LayerMask capaObstaculos;

    double disToClose = double.MaxValue;
    Vector3 bestHidding;
    public float distMax = 100f;
    public float maxSpeed = 5f;
    public override Vector3 CalcularSteering()
    {
        Collider[] obstaculos = Physics.OverlapSphere(transform.position, distMax, capaObstaculos);

        double distMasChica = 100000.0;
        Vector3 puntoCercano = Vector3.zero;
        foreach (Collider obstaculo in obstaculos)
        {
            Vector3 hiddingSpot = getHidePosition(obstaculo.transform.position, obstaculo.GetComponent<SphereCollider>().radius);

            if ((transform.position - hiddingSpot).magnitude < distMasChica)
            {
                distMasChica += (transform.position - hiddingSpot).magnitude;
                puntoCercano = hiddingSpot;
            }
        }
        if (puntoCercano != null)
        {
            Vector3 direccion =
            (puntoCercano - transform.position).normalized;
            Vector3 vel = direccion * maxSpeed;
            Vector3 steeringForce = vel - MiRigidbody.velocity;
            return steeringForce;
        }
        else
        {
            Vector3 velocidadeseada = ((puntoCercano - transform.position).normalized) * maxSpeed;
            Vector3 vectorSteering = velocidadeseada - MiRigidbody.velocity;
            return vectorSteering;

        }
    }




    public Vector3 getHidePosition(Vector3 posOb, float radiusOb)
    {
        float DistFromBoundary = 30.0f;

        float distAway = radiusOb + DistFromBoundary;

        Vector3 toObj = (posOb - target.position).normalized;

        return ((toObj * distAway) + posOb);
    }
}
