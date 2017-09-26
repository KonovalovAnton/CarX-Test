using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractTower : MonoBehaviour {

    [SerializeField]
    protected GameObject m_projectilePrefab;

    [SerializeField]
    protected float m_shootInterval = 0.5f;

    [SerializeField]
    protected float m_range = 4f;

    protected float lastShotTime;

    private ObjectPool bulletPool;

    protected List<Monster> monsterList = new List<Monster>();

    private void Start()
    {
        bulletPool = gameObject.AddComponent<ObjectPool>();
        SphereCollider sc = gameObject.AddComponent<SphereCollider>();
        sc.isTrigger = true;
        sc.radius = m_range;
    }

    private void OnTriggerEnter(Collider other)
    {
        Monster m = other.GetComponent<Monster>();
        if(m != null)
        {
            monsterList.Add(m);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Monster m = other.GetComponent<Monster>();
        if (m != null)
        {
            monsterList.Remove(m);
        }
    }

    public virtual Monster SelectTarget()
    {
        Monster target = null;
        float range = float.MaxValue;

        foreach (var item in monsterList)
        {
            float r = Vector3.Distance(item.transform.position, transform.position);
            if (r < range)
            {
                range = r;
                target = item;
            }
        }

        return target;
    }

    public virtual GameObject Shoot(Vector3 pos)
    {
        lastShotTime = Time.time;
        return bulletPool.Spawn(m_projectilePrefab, pos);
    }

    public virtual bool Update()
    {
        if(m_projectilePrefab == null)
        {
            return false;
        }

        if(Time.time - lastShotTime < m_shootInterval)
        {
            return false;
        }

        return true;
    }
}
