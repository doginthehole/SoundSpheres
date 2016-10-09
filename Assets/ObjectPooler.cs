using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ObjectPooler : MonoBehaviour
{
    // Use this for initialization
    public List<GameObject> pooledObjects;
    public int maxCount = 10;
    public bool shouldGrow = true;
    public GameObject pooledObject;

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < maxCount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);

        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {

            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (shouldGrow)
        {
            GameObject obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
    public void DeactivateAllObjects()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].SetActive(false);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
    }
}
