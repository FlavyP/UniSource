using UnityEngine;
using System.Collections;


public class SpawnObject : MonoBehaviour
{
    public GameObject spawnPrefab;

    // Use this for initialization
    void Start()
    {
        Spawn();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Spawn()
    {
        Instantiate(spawnPrefab, transform.position, transform.rotation);
    }
}

