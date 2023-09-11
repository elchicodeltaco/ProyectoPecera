using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class ControlAsteroides : MonoBehaviour
{
    private Rigidbody RigidComida;
    private Transform playertransform;//saber donde está el jugador
    private Vector2 direccion;//calcular hacia donde tiene que ir el asteroide
  //  public GameObject preFabParticulas;// el efecto de particulas

    public float velocidad;
   


  //  public GameObject prefabAsteroideMenor; //este será el objeto que se instancia cuando el primer asteroide se destrye
    public bool direccionAleatoria;

    public bool EsChico;

    // Start is called before the first frame update
    void Start()
    {
        RigidComida = GetComponent<Rigidbody>();

        if (direccionAleatoria)
        {
            direccion = new Vector3(Random.Range(-1f, 1f),  Random.Range(-1f, 1f), Random.Range(-1f, 1f));
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

   

}
