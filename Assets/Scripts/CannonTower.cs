﻿using UnityEngine;
using System.Collections;

public class CannonTower : AbstractTower
{
	private float m_lastShotTime = -0.5f;

    [SerializeField]
    Transform yaw;

    [SerializeField]
    Transform pitch;

    Vector3 PredictPosition(Monster target)
    {        
        Vector3 monsterPosition = target.transform.position;
        Vector3 monsterMovementDirection = (target.m_moveTarget.transform.position - monsterPosition).normalized;
        Vector3 fromMonsterToTowerDirection = (spawnPoint.position - monsterPosition).normalized;

        float monsterVelocity = target.m_speed;
        float bulletVelocity = m_projectilePrefab.GetComponent<CannonProjectile>().m_speed;
        float initialDistance = Vector3.Distance(spawnPoint.position, monsterPosition);
        float alpha = Vector3.Angle(monsterMovementDirection, fromMonsterToTowerDirection);
        float alphaRad = alpha * Mathf.PI / 180;

        float a = 1 - Mathf.Pow(monsterVelocity / bulletVelocity, 2);
        float b = 2 * monsterVelocity / bulletVelocity * initialDistance * Mathf.Cos(alphaRad);
        float c = - initialDistance * initialDistance;

        float D = b * b - 4 * a * c;
        float predictionL = (-b + Mathf.Sqrt(D)) / (2 * a);

        return monsterPosition + predictionL * monsterVelocity / bulletVelocity * monsterMovementDirection;
    }

	public override bool Update ()
    {
		if(base.Update())
        {
            Monster target = SelectTarget();
            if(target != null)
            {
                var obj = Shoot(spawnPoint.position);
                Vector3 forward = (PredictPosition(target) - spawnPoint.position).normalized;
                obj.GetComponent<CannonProjectile>().direction = forward;

                Debug.Log(pitch.forward);
                Debug.Log(forward);
                yaw.localRotation = Quaternion.Euler(0, Mathf.Atan2(forward.x,forward.z) / Mathf.PI * 180, 0);
                pitch.localRotation = Quaternion.Euler(-Mathf.Atan2(forward.y, forward.z) / Mathf.PI * 180, 0, 0);
            }
        }
        return true;
	}
}
