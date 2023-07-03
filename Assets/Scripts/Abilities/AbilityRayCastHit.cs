using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRayCastHit : Ability
{
    public float distance;

    public override void UseAbility(Vector3 position)
    {
        EffectDamage effect = new EffectDamage();
        RaycastHit2D[] hits = Physics2D.RaycastAll(user.transform.position, (position - user.transform.position), distance, LayerMask.GetMask("Hittable"));
        foreach (RaycastHit2D hit in hits)
        {
            Body body = (hit.collider.gameObject.GetComponent<Body>());
            if (body != null && body != user)
            {
                effect.onHitEvent.Invoke(new List<Body>() {body});
                effect.onActivateEvent.Invoke();
                return;
            }
        }
    }
}
