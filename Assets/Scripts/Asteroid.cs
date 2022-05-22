using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private int hp = 2;
    public GameObject explosionParticles;
    private Vector3 rotationVector;

    private void Start()
    {
        rotationVector = new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Instantiate(explosionParticles, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        transform.Rotate(rotationVector);
    }

    private void OnCollisionEnter(Collision collision)
    {
        hp--;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
