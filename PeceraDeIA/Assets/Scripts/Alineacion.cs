using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alineacion : SteeringBase
{
    public float radioAlineacion = 5f;
    public LayerMask capaAgentes;
    public float speedRotation = .5f;

    public override Vector3 CalcularSteering()
    {
        Vector3 steeringForce = new Vector3();
        Collider[] agentesCercanos = Physics.OverlapSphere(transform.position, radioAlineacion, capaAgentes);

        foreach (Collider obj in agentesCercanos)
        {
            if (obj.gameObject != gameObject)
            {
                steeringForce += obj.transform.forward;
            }
        }
        if (agentesCercanos.Length > 0)
        {
            steeringForce /= (float)agentesCercanos.Length;
            steeringForce.Normalize();
            //steeringForce = steeringForce - transform.forward;
        }
        RotateToTarget(steeringForce);
        return steeringForce;
    }
    private void RotateToTarget(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(direction);
        Quaternion rotation2 = Quaternion.RotateTowards(GetComponentInChildren<MeshRenderer>().gameObject.transform.rotation, rotation, speedRotation);
        GetComponentInChildren<MeshRenderer>().gameObject.transform.rotation = rotation2;
    }
}
