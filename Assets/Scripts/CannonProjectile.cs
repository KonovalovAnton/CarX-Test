﻿using UnityEngine;
using System.Collections;

public class CannonProjectile : MonoBehaviour {
	public float m_speed = 0.2f;
	public int m_damage = 10;

    public Vector3 direction;

	void Update ()
    {
        if(direction != null)
        {
		    var translation =  direction * m_speed;
		    transform.Translate (translation);
        }
	}

	void OnTriggerEnter(Collider other) {
		var monster = other.gameObject.GetComponent<Monster> ();
		if (monster == null)
			return;

		monster.m_hp -= m_damage;
		if (monster.m_hp <= 0)
        {
            monster.TriggerDeath();
		}
        gameObject.GetComponent<PoolInstance>().Remove();
	}
}
