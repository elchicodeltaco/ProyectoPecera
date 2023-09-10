using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursuit : SteeringBase
{
    // Start is called before the first frame update
    public Rigidbody Lider;
    public Vector3 offset;
    public float velocidad = 5f;
    public float maxSpeed = 10;

    public override Vector3 CalcularSteering()
    {
        if (Lider != null)
        {
            Vector3 worldOffsetPos = PointToWorldSpace(offset, Lider.transform.up, Lider.transform.right, Lider.transform.up, Lider.transform.position);
            Vector3 toOffset = worldOffsetPos - transform.position;
            float lookAheadTime = toOffset.magnitude / (maxSpeed + Lider.GetComponent<Rigidbody>().velocity.magnitude);

            Vector3 steeringForce = Seek(worldOffsetPos + Lider.velocity * lookAheadTime, velocidad);

            return steeringForce;
        }
        else
        {
            return Vector3.zero;
        }
    }

    private Vector3 PointToWorldSpace(Vector3 point, Vector3 heading, Vector3 side, Vector3 up, Vector3 position)
    {
        Vector3 worldPoint = Vector3.zero;

        worldPoint.x = point.x * heading.x + point.y * side.x + point.z * up.x + position.x;
        worldPoint.y = point.x * heading.y + point.y * side.y + point.z * up.y + position.y;
        worldPoint.z = point.x * heading.z + point.y * side.z + point.z * up.z + position.z;

        return worldPoint;
    }

    public Vector3 Seek(Vector3 target, float velocidad)
    {
        Vector3 direccion =
        (target - transform.position).normalized;
        Vector3 vel = direccion * velocidad;
        Vector3 steeringForce = vel - MiRigidbody.velocity;
        return steeringForce;
    }
}
