using UnityEngine;
using System.Collections;

public class SimpleTower : AbstractTower
{
    public override bool Update()
    {
        if(base.Update())
        {
            Monster target = SelectTarget();
            if(target != null)
            {
                var obj = Shoot(spawnPoint.position);
                obj.GetComponent<GuidedProjectile>().m_target = target.gameObject;
            }
        }

        return true;
	}
}
