using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractTower : MonoBehaviour {

    [SerializeField]
    protected GameObject m_projectilePrefab;

    [SerializeField]
    protected float m_shootInterval = 0.5f;

    protected float lastShotTime;

    protected List<Monster> monsterList;

    private AbstractTower()
    {
        monsterList = new List<Monster>();
    }

    private void Start()
    {
        gameObject.AddComponent<ObjectPool>();
    }

    public virtual void UpdateMonsterList() { }

    public virtual void SelectTarget() { }

    public virtual void Shoot(Monster target)
    {
        lastShotTime = Time.time;
    }

    public virtual void Update()
    {
        if(m_projectilePrefab == null)
        {
            return;
        }

        if(Time.time - lastShotTime < m_shootInterval)
        {
            return;
        }
    }
}
