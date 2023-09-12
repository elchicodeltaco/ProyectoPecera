using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezAngel : MonoBehaviour
{

    public LayerMask capaDeteccion;
    public LayerMask capaDeteccionComida;

    public int boxLenght = 5;

    Collider depredadorMasCercano;
    Collider comidaMasCercana;

    private float distMin = float.MaxValue;
    // Start is called before the first frame update
    public void ComportamientoAngel()
    {
        Collider[] depredadores = Physics.OverlapSphere(transform.position, boxLenght, capaDeteccion);
        Collider[] comidas = Physics.OverlapSphere(transform.position, boxLenght, capaDeteccionComida);

        if (depredadores != null)
        {
            distMin = float.MaxValue;
            foreach (Collider depredador in depredadores)
            {
                Vector3 posicionDepredador = depredador.transform.position;
                float distancia = posicionDepredador.magnitude;
                if(distancia < distMin) { 
                    depredadorMasCercano = depredador;
                }
            }
            this.GetComponent<FleeAngel>().Target = depredadorMasCercano.transform; 
        }
        if(comidas!= null)
        {
            distMin = float.MaxValue;
            foreach (Collider comida in comidas)
            {
                Vector3 posicionComida = comida.transform.position;
                float distancia = posicionComida.magnitude;
                if (distancia < distMin)
                {
                    comidaMasCercana = comida;
                }
            }
            if(comidaMasCercana!= null)
            {
                this.GetComponent<ArrivalAngel>().target = comidaMasCercana.transform;

            }
        }
        if (depredadorMasCercano.transform.position.magnitude - transform.position.magnitude > comidaMasCercana.transform.position.magnitude-transform.position.magnitude)
        {
            this.GetComponent<ArrivalAngel>().weight = 3;
            this.GetComponent<FleeAngel>().weight = 0;

        }
        else if ((depredadorMasCercano.transform.position.magnitude - transform.position.magnitude > comidaMasCercana.transform.position.magnitude - transform.position.magnitude))
        {
            this.GetComponent<ArrivalAngel>().weight = 0;
            this.GetComponent<FleeAngel>().weight = 3;
        }

    }
    private void Update()
    {
        ComportamientoAngel();
    }
}
