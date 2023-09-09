using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : SteeringBase
{
    [Header("Variables")]
    public LayerMask obstaclesLayer;
    public float speed = 2;
    public float radiusDetection = 2;

    public float speedRotation = 3f;
    private float boxLength;
    private RaycastHit hit;



    public override Vector3 CalcularSteering()
    {
        List<Collider> obstacles = new List<Collider>();

        //el crecimiento de la zona de deteccion aumenta proporcionalmete a la velocidad del agente
        boxLength = radiusDetection * (MiRigidbody.velocity.magnitude / speed) + radiusDetection;

        Debug.DrawRay(transform.position, MiRigidbody.velocity.normalized * boxLength);
        //almacenar todos los posibles obstaculos 
        if (Physics.Raycast(transform.position, MiRigidbody.velocity, out hit, boxLength, obstaclesLayer))
        {
            obstacles.Add(hit.collider);
        }
        //esta variable nos ayuda a saber cual es el objeto mas cercano
        Collider nearestObstacle = null;
        //esta nos ayudara a saber cual es la distancia de la interseccion del objeto mas cercano
        float distClosestIP = int.MaxValue;
        //nos ayudara a transformar las coor locales del objeto mas cercano
        Vector3 localPosOfClosestObs = new Vector3();

        foreach (Collider collider in obstacles)
        {
            //se transforma la posicion de coordenadas de mundo a coordenadas locales
            Vector3 localPosition = transform.InverseTransformPoint(collider.transform.position);

            float distance = hit.distance;//localPosition.magnitude;
            if (distance < distClosestIP)
            {
                // distancia al punto mas cercano
                distClosestIP = distance;
                //obstaculo mas cercano
                nearestObstacle = collider;
                //posision local del obstaculo mas cercano
                localPosOfClosestObs = localPosition;
            }
        }

        //segunda parte
        Vector3 steeringForce = Vector3.zero;
        if (nearestObstacle != null)
        {
            //si el agente esta mas cerca al objeto mayor debe ser la fuerza
            float multiplier = 1 + (boxLength - distClosestIP) / boxLength;

            //calculating the lateral force
            steeringForce.x = (nearestObstacle.GetComponent<SphereCollider>().radius - localPosOfClosestObs.x) * multiplier;
            steeringForce.z = (nearestObstacle.GetComponent<SphereCollider>().radius - localPosOfClosestObs.z) * 0.2f;
            steeringForce.y = (nearestObstacle.GetComponent<SphereCollider>().radius - localPosOfClosestObs.y) * 0.2f;
            //0.2 representa una fuerza de arrastre proporcional a la distancia desde el agente
            //Vector3 globalPos = (steeringForce - transform.position).normalized;
            //steeringForce = globalPos;
        }



        RotateToTarget(steeringForce.normalized);
        return steeringForce;
    }

    void RotateToTarget(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(direction);
        Quaternion rotation2 = Quaternion.RotateTowards(GetComponentInChildren<MeshRenderer>().gameObject.transform.rotation, rotation, speedRotation);
        GetComponentInChildren<MeshRenderer>().gameObject.transform.rotation = rotation2;

    }
}
