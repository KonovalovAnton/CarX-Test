using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolInstance : MonoBehaviour {

    ObjectPool creator;

    public void SetCreator(ObjectPool op)
    {
        creator = op;
    }

    public void Remove()
    {
        creator.Remove(this);
    }
}
