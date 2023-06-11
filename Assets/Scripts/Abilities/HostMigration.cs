using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostMigration : Ability
{
    public float hitRadius;

    public override void AddHits(List<Body> bodiesHit)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(Utilities.GetMousePositsion(), hitRadius, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Body body = (hit.collider.gameObject.GetComponent<Body>());
                if (body != null)
                {
                    bodiesHit.Add(body);
                    return;
                }
            }
        }
    }

    public override void HitBodies(List<Body> bodiesHit)
    {
        Mind.MigrateHost(bodiesHit[0]);
    }

}
