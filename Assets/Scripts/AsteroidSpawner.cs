using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public List<GameObject> asteroids;
    public float spawnTime;

    private void Start()
    {
        StartCoroutine(AsteroidSpawn());
    }

    private IEnumerator AsteroidSpawn()
    {
        yield return new WaitForSeconds(spawnTime);
        
        Instantiate(asteroids[UnityEngine.Random.Range(0, asteroids.Count)], new Vector3(UnityEngine.Random.Range(-15, 15), UnityEngine.Random.Range(-10, 10), this.transform.position.z), Quaternion.identity);

        StartCoroutine(AsteroidSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
