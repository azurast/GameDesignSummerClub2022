using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipeObject;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn",0,spawnTime);
    }

    void Spawn(){

        Vector2 spawnedPosition = new Vector2(transform.position.x, Random.Range(1.5f,-1.5f));

        GameObject spawnedPipe = Instantiate(pipeObject, spawnedPosition ,transform.rotation);
        Destroy(spawnedPipe, 5);
    }
}
