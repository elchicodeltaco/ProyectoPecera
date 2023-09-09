using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezAngel : MonoBehaviour
{

    public LayerMask capaDeteccion;
    public int boxLenght = 5;

    Collider depredadorMasCercano;
    private float distMin = float.MaxValue;
    // Start is called before the first frame update
    public void ComportamientoAngel()
    {
        Collider[] depredadores = Physics.OverlapSphere(transform.position, boxLenght, capaDeteccion);

        if(depredadores != null)
        {
            this.GetComponent<FleeAngel>().weight = 10f;
            foreach(Collider depredador in depredadores)
            {
                Vector3 posicionDepredador = depredador.transform.position;
                float distancia = posicionDepredador.magnitude;
                if(distancia < distMin) { 
                    depredadorMasCercano = depredador;
                }
            }
            this.GetComponent<FleeAngel>().Target = depredadorMasCercano.transform;
            this.GetComponent<FleeAngel>().weight = 10;
        }
        else
        {
            this.GetComponent<FleeAngel>().weight = 0;
            this.GetComponent<ArrivalAngel>().weight = 10;

        }


    }
}
