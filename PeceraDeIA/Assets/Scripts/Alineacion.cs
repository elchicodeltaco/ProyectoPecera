using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alineacion : SteeringBase
{
    public float radioAlineacion = 5f;
    public LayerMask capaAgentes;
     
    public override Vector3 CalcularSteering()
    {
        Vector3 steeringForce = Vector3.zero;
        int numeroDeVecinos = 0;
        Collider[] agentesCercanos = Physics.OverlapSphere(transform.position, radioAlineacion, capaAgentes);

        foreach(Collider agente in agentesCercanos)
        {
          if(agente.gameObject != gameObject)
          {
              //Aquí debe de sumar la direccion hacia donde se dirige 
              steeringForce += agente.transform.forward;

              numeroDeVecinos++; 
          }
        }

        if(numeroDeVecinos > 0)
        {
            steeringForce /= numeroDeVecinos; //Este es el promedio
            steeringForce.Normalize();
            //steeringForce = steeringFoce - transfom.forward;
        }

        return steeringForce;
    }
}
