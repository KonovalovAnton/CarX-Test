using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    private List<GameObject> bulletPool;

    void Start () {
        var objToSpawn = new GameObject("Object pool");
        objToSpawn.transform.parent = transform;
    }
	
	
}
