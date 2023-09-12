using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezDepredador : MonoBehaviour
{
    Transform perseguido;
    Transform pezAEscapar;



    GameObject[] arregloPresas;
    GameObject[] arregloDepredadores;
    void comportamientoDepredador()
    {
        float distanciaMin = float.MaxValue;
        foreach(GameObject pez in arregloPresas)
        {
            float distancia = (pez.transform.position - transform.position).magnitude;
            if (distancia < distanciaMin)
            {
                perseguido = pez.transform;

            }
        }
        distanciaMin = float.MaxValue;
        foreach (GameObject pez in arregloDepredadores)
        {
            float distancia = (pez.transform.position - transform.position).magnitude;
            if (distancia < distanciaMin){
                pezAEscapar = pez.transform;
            }
        }
        this.GetComponent<FleeAngel>().Target = pezAEscapar;
        this.GetComponent<Predictividad>().evader = perseguido;

    }
    // Start is called before the first frame update
    void Start()
    {
        arregloDepredadores = GameObject.FindGameObjectsWithTag("Depredadores");
        arregloPresas = GameObject.FindGameObjectsWithTag("PresaDeDepredador");

    }

    // Update is called once per frame
    void Update()
    {
        comportamientoDepredador();
    }
}
