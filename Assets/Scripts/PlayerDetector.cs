using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool enemyDetected;
    public GameObject canon;
    public GameObject player;
    public Transform gunCanon;
    public GameObject bullet;
    public float bulletSpeed;

    // Update is called once per frame
    void Update()
    {
        if (enemyDetected)
        {
            canon.transform.LookAt(player.transform);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            enemyDetected = true;
            StartCoroutine(Disparar());
        }
    }

    private IEnumerator Disparar()
    {
        yield return new WaitForSeconds(0.2f);

        if (enemyDetected)
        {
            //Instantiate(bullet, gunCanon.transform.position, canon.transform.rotation);

            var instance = Instantiate(bullet, transform.position, Quaternion.identity);
            if(InterceptionDirection(player.transform.position, transform.position, player.GetComponent<Rigidbody>().velocity, bulletSpeed, out var direction))
            {
                instance.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
            }
            else
            {
                instance.GetComponent<Rigidbody>().velocity = (player.transform.position - transform.position).normalized * bulletSpeed;
            }

            StartCoroutine(Disparar());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            enemyDetected = false;
        }
    }

    public bool InterceptionDirection(Vector3 a, Vector3 b, Vector3 vA, float sB, out Vector3 result)
    {
        var aToB = a - b;
        var dC = aToB.magnitude;
        var alpha = Vector3.Angle(aToB, vA) * Mathf.Deg2Rad;
        var sA = vA.magnitude;
        var r = sA / sB;
        if(MyMath.SolveQuadratic(1-r*r, 2*r*dC*Mathf.Cos(alpha), -(dC * dC), out var root1, out var root2) == 0){
            result = Vector3.zero;
            return false;
        }
        var dA = Mathf.Max(root1, root2);
        var t = dA / sB;
        var c = a + vA * t;
        result = (c - b).normalized;
        return true;
    }

    public class MyMath
    {
        public static int SolveQuadratic(float a, float b, float c, out float root1, out float root2)
        {
            var discriminant = b * -4 * a * c;
            if (discriminant < 0)
            {
                root1 = Mathf.Infinity;
                root2 = -root1;
                return 0;
            }

            root1 = (-b + Mathf.Sqrt(discriminant)) / (2 * a);
            root2 = (-b - Mathf.Sqrt(discriminant)) / (2 * a);
            return discriminant > 0 ? 2 : 1;
        }
    }
}
