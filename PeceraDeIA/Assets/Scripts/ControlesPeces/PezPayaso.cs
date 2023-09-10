using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezPayaso : MonoBehaviour
{
    // Start is called before the first frame update
    public float boxLenght = 10f;
    public LayerMask depredadores;
    public float cercaniaARefugio;
    private Transform targetCercano;

    void PezPayasoComportamiento()
    {
        Collider[] pecesDepredadores = Physics.OverlapSphere(transform.position, boxLenght, depredadores);

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

                if((transform.position - this.GetComponent<Seek>().Target.transform.position).magnitude < cercaniaARefugio)
                {
                    this.GetComponent<Hide>().weight = 6;
                    this.GetComponent<Hide>().target = targetCercano;

                    this.GetComponent<Seek>().weight = 0;
                }
                else if ((transform.position - this.GetComponent<Seek>().Target.transform.position).magnitude > cercaniaARefugio);
                {
                    this.GetComponent<Hide>().weight = 0;
                    this.GetComponent<Seek>().weight = 6;
                }
            }

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
