using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoComidaAngel : MonoBehaviour
{
    public LayerMask PezAngel;
    // Start is called before the first frame update
    public float boxLenght = 0.5f;
    private float tiempoTranscurrido = 0f;
    public float tiempoEsperaComida = 3f;
    public void CompComida()
    {
        Collider[] comedoresAngel = Physics.OverlapSphere(transform.position, boxLenght, PezAngel);
        if(comedoresAngel.Length >= 1)
        {
            Esperar(3f);
        }
    }

    private void Esperar(float duracion)
    {
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido > tiempoEsperaComida)
        {
            Destroy(this.gameObject);
            tiempoTranscurrido = 0;

        }
    }


    private void Update()
    {
        CompComida();
    }
}
