using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    [SerializeField]
    float m_interval = 3;

    [SerializeField]
    GameObject m_moveTarget;

    [SerializeField]
    GameObject prefab;

	private float m_lastSpawn;

    ObjectPool monsterPool;

    private void Awake()
    {

    }

    void Update ()
    {
		if (Time.time > m_lastSpawn + m_interval)
        {
            if(monsterPool == null)
            {
                monsterPool = gameObject.AddComponent<ObjectPool>();
            }
            var go = monsterPool.Spawn(prefab, transform.position);
			go.GetComponent<Monster>().m_moveTarget = m_moveTarget;

			m_lastSpawn = Time.time;
		}
	}
}
