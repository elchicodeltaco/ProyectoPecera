using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekEscalador : SteeringBase
{
    //  public Transform Target; //A donde se quiere ir
    //public List<Transform> Targets = new List<Transform>();
    public Transform Target;
    public float Speed = 5f;
    private Transform ComidaActual;
    private  int ComidaActualIndex;
    public float WayPointSeekDist = 1f;
    private GameObject Comidas;
    
    // Update is called once per frame
    public override Vector3 CalcularSteering()
    {
        Comidas = GameObject.FindGameObjectWithTag("Comida");

        //  Targets.Add(Comidas.transform);

        Target = Comidas.transform;
       

        //ComidaActual = Targets[ComidaActualIndex];

       // Targets.Add()

        Vector3 steeringForce = Seek(Target, Speed);


        // hacia esto para cuando se hacia una lista de comidas, ya no es nesesario

        //if (Vector3.SqrMagnitude(ComidaActual.position - transform.position) < WayPointSeekDist * WayPointSeekDist)
        //{
        //    if (ComidaActualIndex + 1 < ta.Count)
        //    {
        //        ComidaActualIndex++;
        //        ComidaActual = Targets[ComidaActualIndex];
        //        Debug.Log("esto es lo que hay en lista de comida" + ComidaActual);
        //    }
        //    else
        //    {
        //        if (Vector3.SqrMagnitude(Targets[ComidaActualIndex].position - Targets[0].position) < WayPointSeekDist * WayPointSeekDist)
        //        {
        //            ComidaActualIndex = 0;

        //        }
        //        else
        //        {
        //            return Vector3.zero;
        //        }
        //    }
        //}
        return steeringForce;

    }

    public Vector3 Seek(Transform target, float velocidad)
    {
        Vector3 direccion =
        (target.position - transform.position).normalized;
        Vector3 vel = direccion * velocidad;
        Vector3 steeringForce = vel - MiRigidbody.velocity;
        return steeringForce;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Comida")
        {   //GameObject copia = Instantiate(ObejectToPool);

               // Targets.Remove(ComidaActual);
                Debug.Log("ha sido comida esta croqueta " + ComidaActual);
          

        }
    }

}


