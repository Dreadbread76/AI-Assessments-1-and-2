using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTest : MonoBehaviour
{
    PoolManager spherePool;
    // Start is called before the first frame update
    private void Start()
    {
        for(int x=0; x<10; x++)
        {
            spherePool.Spawn();
        }
        StartCoroutine(despawnSpheres());
        StartCoroutine(spawnSpheres());
    }


   IEnumerator despawnSpheres()
    {
        while(spherePool.spawnedResource.Count > 0)
        {
            yield return new WaitForSeconds(1f);

            spherePool.Despawn(spherePool.spawnedResource[0]);
        }
    }

    IEnumerator spawnSpheres()
    {
        while (spherePool.spawnedResource.Count > 0)
        {
            yield return new WaitForSeconds(2f);
            {
                GameObject theThingISpawned = spherePool.Spawn();
                //When spawning, we need to reset the values of the gameobject
                theThingISpawned.transform.position = Vector3.zero;
            }
        }
    }
}
