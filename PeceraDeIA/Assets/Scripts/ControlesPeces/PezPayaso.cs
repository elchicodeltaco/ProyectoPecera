using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezPayaso : MonoBehaviour
{
    // Start is called before the first frame update
    public float boxLenght = 10f;
    public float boxLenghtRefugios = 1000f;

    public LayerMask depredadores;
    public float cercaniaARefugio;
    private Transform targetCercano;
    private Transform targetRefugioCercano;

    public LayerMask refugiosCapa;

    void PezPayasoComportamiento()
    {
        Collider[] pecesDepredadores = Physics.OverlapSphere(transform.position, boxLenght, depredadores);
        Collider[] refugios = Physics.OverlapSphere(transform.position, boxLenghtRefugios, refugiosCapa);


        if (pecesDepredadores.Length > 0)
        {
            float disMasCerca = float.MaxValue;
            foreach(Collider pezGrande in pecesDepredadores)
            {
                Vector3 posicionPez = (pezGrande.transform.position);
                float distancia = posicionPez.magnitude;
                if(distancia < disMasCerca)
                {
                    targetCercano = pezGrande.transform;
                    disMasCerca = distancia;                
                }

                this.GetComponent<Seek>().weight = 6;
                this.GetComponent<Wander>().weight = 0;
            }

        }
        if (refugios.Length > 0)
        {
            float disMasCerca = float.MaxValue;
            foreach (Collider refugio in refugios)
            {
                Vector3 posicionPez = (refugio.transform.position);
                float distancia = posicionPez.magnitude;
                if (distancia < disMasCerca)
                {
                    targetRefugioCercano = refugio.transform;
                    disMasCerca = distancia;
                }
            }
            this.GetComponent<Seek>().Target = targetRefugioCercano;
        }

        else if(pecesDepredadores.Length == 0)
        {
            this.GetComponent<Seek>().weight = 0;
            this.GetComponent<Wander>().weight = 6;
        }
    }

    void Update()
    {
        PezPayasoComportamiento();
    }
}
