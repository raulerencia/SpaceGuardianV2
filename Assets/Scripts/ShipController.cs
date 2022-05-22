using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public GameObject shipBody;
    public float velocity = 60f;
    public float turn = 90f;
    public float inputHorizontal, inputVertical;
    public GameObject explosionParticles;
    public GameObject gameOverPanel;

    public GameObject bullet;
    public Transform canon;


    private void Start()
    {
        StartCoroutine(Boost());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Avance fijo hacia adelante
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);

        /*transform.Rotate(Vector3.up * inputHorizontal * turn * Time.deltaTime, Space.World);

        transform.Rotate(Vector3.right * inputVertical * turn * Time.deltaTime * 2);*/

        if(inputHorizontal != 0)
        {
            transform.Translate(new Vector3(1,0,0) * (velocity / 2) * Time.deltaTime * inputHorizontal);
        }

        if (inputVertical != 0)
        {
            transform.Translate(new Vector3(0, 1, 0) * (velocity/2) * Time.deltaTime * inputVertical);
        }

        if (shipBody.transform.localRotation.z > -0.6f && shipBody.transform.localRotation.z < 0.6f)
        {
            shipBody.transform.Rotate(Vector3.forward * inputHorizontal * -turn * Time.deltaTime * 2);
        }
        
        if (inputHorizontal == 0)
        {
            shipBody.transform.rotation = Quaternion.Slerp(shipBody.transform.rotation, transform.rotation, 0.05f);
        }

        if(transform.position.y > 10)
        {
            transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        }

        if(transform. position.y < -10)
        {
            transform.position = new Vector3(transform.position.x, -10, transform.position.z);
        }

        if (transform.position.x > 15)
        {
            transform.position = new Vector3(15, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -15)
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
        }

    }

    private void OnMove(InputValue valor)
    {
       inputHorizontal = valor.Get<Vector2>().x;
       inputVertical = valor.Get<Vector2>().y;
    }

    public void OnFire(){
        Instantiate(bullet, canon.transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            explosionParticles.SetActive(true);
            gameOverPanel.SetActive(true);
            shipBody.SetActive(false);
        }
    }

    private IEnumerator Boost()
    {
        yield return new WaitForSeconds(30f);
        velocity = velocity * 1.2f;
        StartCoroutine(Boost());
    }
}
