using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCircleCastHit : Ability
{
    public float hitRadius;

    public override void UseAbility(Vector3 position)
    {
        HostMigration effect = new HostMigration();
        RaycastHit2D[] hits = Physics2D.CircleCastAll(position, hitRadius, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Hittable"));
        foreach (RaycastHit2D hit in hits)
        {
            Body body = (hit.collider.gameObject.GetComponent<Body>());
            if (body != null && body != user)
            {
                effect.onHitEvent.Invoke(new List<Body>() { body });
                effect.onActivateEvent.Invoke();
                return;
            }
        }
    }
}
