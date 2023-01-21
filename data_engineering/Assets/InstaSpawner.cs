using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaSpawner : Spawner
{
    public GameObject prefabToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool canSpawn()
    {
        return true;
    }

    public override GameObject spawn()
    {
        return Instantiate(prefabToSpawn);
    }
}
