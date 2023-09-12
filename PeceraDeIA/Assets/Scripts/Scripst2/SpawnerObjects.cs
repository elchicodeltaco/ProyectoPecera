using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjects : MonoBehaviour
{
    public GameObject prefabSpawner; //el object al que le haremos copias

    public float tiempoMinimoSpawn;//intervalo para crear copias
    public float tiempoMaxSpawn;

    private float tiempoSeleccionado;//el tiempo escogido para generar otro objeto

    public int ComidasIndex;
    public int spawnerContador;
    public bool SpawnerActivo;

    

    //llevar la cuenta del spawn
    private float ultimoMomentoSpawn;

    // Start is called before the first frame update
    void Start()
    {

          SpawnerActivo = true;

    ///  prefabSpawner = GameObject.FindGameObjectWithTag("Comida");

    tiempoSeleccionado = Random.Range(tiempoMinimoSpawn, tiempoMaxSpawn);

        ultimoMomentoSpawn = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //prefabSpawner = GameObject.FindGameObjectWithTag("Comida");

        if(SpawnerActivo== true)
        {
            SacarComida();
        }

        if(SpawnerActivo== false)
        {
            Invoke(nameof(ActivarSp), 5);
        }
      
        
        
    }


   
    private void SacarComida()
    {
        if (Time.time >= ultimoMomentoSpawn + tiempoSeleccionado)
        {
            //se cumplio el tiempo de espera
            //hacemos un nuevo objeto
            GameObject copia = Instantiate(prefabSpawner, transform.position, transform.rotation);

            //cada que aparezca un nuevo asteroide actualizamos el momento en el que lo hizo
            ultimoMomentoSpawn = Time.time;
            spawnerContador++;
            //decidimos cuanto esperar para cuanto crear una nueva copia
            tiempoSeleccionado = Random.Range(tiempoMinimoSpawn, tiempoMaxSpawn);


            Debug.Log("esto hay en el contador " + ComidasIndex);

            

        }

        if (spawnerContador == 10)
        {
            SpawnerActivo = false;
            spawnerContador = 0;
        }
    }


    private void ActivarSp()
    {
        SpawnerActivo = true;
        //Debug.Log(WaitForSeconds);
        
    }


}
