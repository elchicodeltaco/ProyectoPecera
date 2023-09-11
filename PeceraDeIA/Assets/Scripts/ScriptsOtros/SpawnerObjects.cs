using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjects : MonoBehaviour
{
    public GameObject prefabSpawner; //el object al que le haremos copias

    public float tiempoMinimoSpawn;//intervalo para crear copias
    public float tiempoMaxSpawn;

    private float tiempoSeleccionado;//el tiempo escogido para generar otro objeto

    //llevar la cuenta del spawn
    private float ultimoMomentoSpawn;

    // Start is called before the first frame update
    void Start()
    {
        tiempoSeleccionado = Random.Range(tiempoMinimoSpawn, tiempoMaxSpawn);

        ultimoMomentoSpawn = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= ultimoMomentoSpawn + tiempoSeleccionado)
        {
            //se cumplio el tiempo de espera
            //hacemos un nuevo objeto
            GameObject copia = Instantiate(prefabSpawner, transform.position, transform.rotation);

            //cada que aparezca un nuevo asteroide actualizamos el momento en el que lo hizo
            ultimoMomentoSpawn = Time.time;

            //decidimos cuanto esperar para cuanto crear una nueva copia
            tiempoSeleccionado = Random.Range(tiempoMinimoSpawn, tiempoMaxSpawn);
        }
    }
}
