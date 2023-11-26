using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private readonly GameObject prefab;
    private List<GameObject> instantiateObjects;
    private List<GameObject> recycledObjects;

    private int counter = 0; 
    
    public ObjectPool(GameObject prefab)
    {
        this.prefab = prefab;
        instantiateObjects = new List<GameObject>();
    }

    public void Init(int amount)
    {
        recycledObjects = new List<GameObject>();

        for (int i = 0; i < amount; i++)
        {
            var instance = NewInstance();
            instance.SetActive(false);
            recycledObjects.Add(instance);
        
        }
    }

    private GameObject NewInstance()
    {
        var instace = Instantiate(prefab);
        counter++;
        instace.name = prefab.name + " " + counter.ToString();
        var aux = instace.GetComponent<RecyclableObject>();

        aux.Config(this);

        return instace;
    }

    public GameObject Spawn(Vector3 pos)
    {
        var recyclableObject = GetInstance();
        recycledObjects.Remove(recyclableObject);
        instantiateObjects.Add(recyclableObject);
        recyclableObject.SetActive(true);

        var aux = recyclableObject.GetComponent<RecyclableObject>();
        aux.Init(pos);
        return recyclableObject;
    }

    private GameObject GetInstance()
    {
        return recycledObjects[0];
    }

    public void RecycleObject(GameObject recyclableObject)
    {
        instantiateObjects.Remove(recyclableObject);
        recyclableObject.SetActive(false);

        recycledObjects.Add(recyclableObject);
    }
}
