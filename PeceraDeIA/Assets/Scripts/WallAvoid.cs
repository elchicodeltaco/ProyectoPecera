using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAvoid : SteeringBase
{
    // Start is called before the first frame update
    public float distanciaDeteccion = 5.0f;
    public LayerMask capaDeteccion;

    public override Vector3 CalcularSteering()
    {
        Vector3 steeringForce = Vector3.zero;

        Debug.DrawRay(transform.position, transform.forward * 3f, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(transform.position,
            transform.forward, out hit,
            distanciaDeteccion, capaDeteccion))
        {
            steeringForce += hit.normal;
        }
        if (Physics.Raycast(transform.position,
        transform.right, out hit,
        distanciaDeteccion, capaDeteccion))
        {
            steeringForce += hit.normal;
        }
        if (Physics.Raycast(transform.position,
        transform.right*-5, out hit,
        distanciaDeteccion, capaDeteccion))
        {
            steeringForce += hit.normal;
        }
        if (Physics.Raycast(transform.position,
            transform.up*5, out hit,
            distanciaDeteccion, capaDeteccion))
        {
            steeringForce += hit.normal;
        }
        if (Physics.Raycast(transform.position,
            Quaternion.Euler(0,45,0)*transform.forward*5, out hit,
            distanciaDeteccion, capaDeteccion))
        {
            steeringForce += hit.normal;
        }
        if (Physics.Raycast(transform.position,
            Quaternion.Euler(0, -45, 0) * transform.forward*5, out hit,
            distanciaDeteccion, capaDeteccion))
        {
            steeringForce += hit.normal;
        }
        Debug.DrawRay(transform.position, transform.right * -5, Color.green);
        if (Physics.Raycast(transform.position,
            Quaternion.Euler(0, -45, 0) * transform.right*-5, out hit,
            distanciaDeteccion, capaDeteccion))
        {
            steeringForce += hit.normal;
        }
        return steeringForce;
    }
}
