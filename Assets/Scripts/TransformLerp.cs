using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformLerp : MonoBehaviour
{
    public GameObject objective;

    public bool seguirPosicion;
    public float acercamientoPosicion = 0.5f;
    public bool seguirRotacion;
    public float acercamientoRotacion = 0.5f;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (seguirPosicion)
        {
            transform.position = Vector3.Lerp(transform.position, objective.transform.position, acercamientoPosicion);
        }

        if (seguirRotacion)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, objective.transform.rotation, acercamientoRotacion);
        }
    }
}
