using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostMigration : Ability
{
    public float hitRadius;

    public override void AddHits(List<Body> bodiesHit, Vector3 position)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(position, hitRadius, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Hittable"));
        foreach (RaycastHit2D hit in hits)
        {
            Body body = (hit.collider.gameObject.GetComponent<Body>());
            if (body != null && body != user)
            {
                bodiesHit.Add(body);
                return;
            }
        }
    }

    public override void HitBodies(List<Body> bodiesHit)
    {
        Mind.MigrateHost(bodiesHit[0]);
    }

}
