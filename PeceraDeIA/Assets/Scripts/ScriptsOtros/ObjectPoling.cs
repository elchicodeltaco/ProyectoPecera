using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoling : MonoBehaviour
{
    public GameObject ObejectToPool; //objeto del que se crearan instancias (copias)

    public int objectNumber;    //numero de copias que voy a crear

    private List<GameObject> Pool; //el pool de objetos


    private void LlenarPool()
    {
        Pool = new List<GameObject>();

        for (int i = 0; i < objectNumber; i++)
        {
            GameObject copia = Instantiate(ObejectToPool);

            Pool.Add(copia);

            copia.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LlenarPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetObjectInPool()
    {
        //tenemos que recorrer nuestro pool en busca de un objeto que este disponible (o sea desactiva)
        foreach(GameObject objeto in Pool)
        {
            //esta disponible en la jerarquia?
            if (!objeto.activeInHierarchy)
            {
                objeto.SetActive(true);

                return objeto;
            }
        }

        //si llega aqui quiere decir que no hay objetos
        return null; 


    }


}
