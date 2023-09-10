using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezLimpiador : MonoBehaviour
{
    private Transform targetCercano;
    public LayerMask pezSeguido;
    public LayerMask pezLimpiador;

    public float boxLenght = 10f;
    public double distMasCerca = double.MaxValue;
    public float distCambio = 5f;
    // Start is called before the first frame update
    public void PezLimpiadorComportamiento()
    {
        Collider[] PecesGrandes = Physics.OverlapSphere(transform.position, boxLenght, pezSeguido);

        if(PecesGrandes != null)
        {
            this.GetComponent<Wander>().weight = 0;

            foreach(Collider pezGrande in PecesGrandes)
            {
                Vector3 posicionPez = (pezGrande.transform.position);
                float distancia = posicionPez.magnitude;
                if(distancia < distMasCerca)
                {
                    targetCercano = pezGrande.transform;
                }
            }
            this.GetComponent<Arrive>().target = targetCercano;
            this.GetComponent<OffsetPursuit>().Lider = targetCercano.GetComponent<Rigidbody>();

            if ((targetCercano.position - transform.position).magnitude > distCambio)
            {
                this.GetComponent<Arrive>().weight = 6;
                this.GetComponent<OffsetPursuit>().weight = 0;
            }
            else if((targetCercano.position - transform.position).magnitude <= distCambio)
            {
                this.GetComponent<Arrive>().weight = 0;
                this.GetComponent<OffsetPursuit>().weight = 6;
            }

        }
        else
        {
            this.GetComponent<OffsetPursuit>().weight = 0;
            this.GetComponent<Arrive>().weight = 0;
            this.GetComponent<Wander>().weight = 6;

        }
    }

    public void offsetSegúnPecesLimpiadoresCerca()
    {
    }

    void Update()
    {
        PezLimpiadorComportamiento();
    }
}
