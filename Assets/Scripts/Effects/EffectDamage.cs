using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamage : Effect
{
    public float damage = 10;

    public EffectDamage() : base() {}

    public override void Activate()
    {
        Debug.Log("ACTIVATED with hits count: " + hits.Count);
        foreach (Body body in hits)
        {
            Debug.Log("hitting: " + body.gameObject);

            //Debug.DrawLine(user.transform.position, body.transform.position, Color.red, 0.25f);
            body.TakeDamage(damage);
        }
    }
}
