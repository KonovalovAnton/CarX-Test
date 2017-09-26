using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    GameObject rootToSpawn;

    private Stack<PoolInstance> objPool;

    public GameObject Spawn(GameObject go, Vector3 pos)
    {
        GameObject instance;

        if (objPool.Count == 0)
        {
            instance = Instantiate(go, pos, Quaternion.identity);
            instance.transform.parent = rootToSpawn.transform;
            instance.AddComponent<PoolInstance>().SetCreator(this);
        }
        else
        {
            instance = objPool.Pop().gameObject;
            instance.gameObject.SetActive(true);
            instance.transform.position = pos;
        }

        return instance;
    }

    public void Remove(PoolInstance instance)
    {
        instance.gameObject.SetActive(false);
        objPool.Push(instance);
    }

    void Start () {
        objPool = new Stack<PoolInstance>();
        rootToSpawn = new GameObject("Object pool");
        rootToSpawn.transform.parent = transform;
    }
	
	
}
