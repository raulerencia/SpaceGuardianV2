using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour
{
    private Vector3 rotationVector;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        rotationVector = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationVector * velocity);
    }
}
