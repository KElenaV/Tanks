using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    
    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        foreach (Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
        
            for (int i = 0; i < pool.Size; i++)
            {
                GameObject newObject = Instantiate(pool.Prefab);
                newObject.SetActive(false);
                objectPool.Enqueue(newObject);
            }
            
            PoolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!PoolDictionary.ContainsKey(tag))
            return null;

        GameObject objectToSpawn = PoolDictionary[tag].Dequeue();
        
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        
        PoolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}