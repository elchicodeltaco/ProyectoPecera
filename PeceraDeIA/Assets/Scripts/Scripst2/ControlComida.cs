using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class ControlComida : MonoBehaviour
{
    private Rigidbody RigidComida;
   
    private Vector2 direccion;//calcular hacia donde tiene que ir el asteroide
  //  public GameObject preFabParticulas;// el efecto de particulas

    public float velocidad;


    private float TiempoMinimoAutodes;//intervalo para crear copias
    private float TiempoMaxAutodes;
    private float TiempoSeleccionado;
    private float ultimoMomentoSpawn;

    //  public GameObject prefabAsteroideMenor; //este será el objeto que se instancia cuando el primer asteroide se destrye
    public bool direccionAleatoria;

    public bool EsComido;

    // Start is called before the first frame update
    void Start()
    {
        TiempoMaxAutodes = 70;
        TiempoMinimoAutodes = 65;

        TiempoSeleccionado = Random.Range(TiempoMinimoAutodes, TiempoMaxAutodes);

        ultimoMomentoSpawn = 0f;

        RigidComida = GetComponent<Rigidbody>();

        if (direccionAleatoria)
        {
            direccion = new Vector3(Random.Range(-1f, 1f),  Random.Range(-1f, 1f), 0);
        }
        //else
        //{
        //    //buscamos al jugador
        //    playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        //    direccion = playertransform.position - transform.position;
        //}

        direccion.Normalize(); //obtengo un vector de valor 1

        direccion *= velocidad;//lo escalamos a la velocidad deseada

        //le asignamos el vector asteroide

        RigidComida.velocity = direccion;
    }

    // Update is called once per frame
    void Update()
    {
        //solo en Caso de ser ocupado ser invoca esta funcion
       // AutoDestruccion();
    }

    //private void OnCollisionEnter3D(Collision3D collision)
    //{
    //    //el asteroide tiene choca con un laser
    //    if (collision.gameObject.tag.Equals("Pez"))
    //    {
    //        collision.gameObject.SetActive(false); //desactivo el disparo
           
    //        //ahora voy a revisar si son asteroides chicos
    //        //si el asteroide no es chico
    //        if (EsChico== false) 
    //        {
    //            //genero nuevos asteroides con nuevo tamaño
    //            //asteroide 1
    //            GameObject nuevo = Instantiate(prefabAsteroideMenor, transform.position, transform.rotation);
    //            nuevo.GetComponent<ControlAsteroides>().direccionAleatoria = true;

    //            GameObject.Find("GameManajer").GetComponent<GameManager>().SumarPuntos();


    //            //asteroide 2
    //            nuevo = Instantiate(prefabAsteroideMenor, transform.position, transform.rotation);
    //            nuevo.GetComponent<ControlAsteroides>().direccionAleatoria = true;

    //           // Instantiate(preFabParticulas, transform.position, Quaternion.identity);//esto es para que apareca el efecto de particulas
    //            GameObject.Find("GameManajer").GetComponent<GameManager>().SumarPuntos();
    //            Destroy(gameObject);//destruye el asteroide
    //        }
    //        //si no es asi entonces hablamos de un asteroide chiquito
    //        else
    //        {
    //            //Instantiate(preFabParticulas, transform.position, Quaternion.identity);
    //            GameObject.Find("GameManajer").GetComponent<GameManager>().SumarPuntos();
    //            Destroy(gameObject);
    //        }
           
           

    //    }
    //}

    private void AutoDestruccion()
    {
        if (Time.time >= ultimoMomentoSpawn + TiempoSeleccionado)
        {
            //se cumplio el tiempo de espera
            //Se Autodestruye
            Debug.Log("se a autodestuido..");
            Destroy(gameObject);

            //cada que aparezca un nuevo asteroide actualizamos el momento en el que lo hizo
            ultimoMomentoSpawn = Time.time;

            //decidimos cuanto esperar para cuanto crear una nueva copia
            TiempoSeleccionado = Random.Range(TiempoMinimoAutodes, TiempoMaxAutodes);


            

        }

    }

   

}
