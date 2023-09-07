using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBase
{
    public float RadioWander = 5f;
    public float DistanciaWander = 3f;
    public float JitterWander = 0.5f;

    private Vector3 Target;

    private void ActualizarTargetWander()
    {
        //Actualizar el objetivo de wander

        Vector3 centroCirculo = MiRigidbody.velocity.normalized * DistanciaWander;
        Vector3 desplazamiento = Random.insideUnitSphere;

        Vector3 targetPos = centroCirculo + desplazamiento;
        targetPos.Normalize();
        Target = targetPos;
    }



    public override Vector3 CalcularSteering()
    {
        //Calcula punto aleatorio 
        Vector3 centroCirculo = MiRigidbody.velocity.normalized * DistanciaWander;
        Vector3 desplazamiento = Random.insideUnitSphere;
        //Punto a la distancia del radio
        Vector3 targetPos = centroCirculo + desplazamiento;
        targetPos.Normalize();
        Target= targetPos;

        //Colocar el aro enfrente del agente. Convertir de espacio local a espacio de mundo 
        Target = transform.TransformPoint(Target * RadioWander);

        //Calcular fuerza de Steering
        Vector3 fuerzaSteering = Target - transform.position;
        //Si se desea que el agente se mueva sobre un plano, se puede cancelar ls fuerza de steering en una coordenada/ en un eje

        //fuerzaSteering.y = 0f;
        fuerzaSteering.Normalize();
        fuerzaSteering -= MiRigidbody.velocity;

        return fuerzaSteering;
    }

    void Start()
    {
        ActualizarTargetWander();
        //Cada frame debe de calcular el punto hacia donde se dirige el agente
    }
}
