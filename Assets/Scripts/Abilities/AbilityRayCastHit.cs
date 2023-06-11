using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRayCastHit : Ability
{

    public float distance;
    public int damage;

    public override void AddHits(List<Body> bodiesHit)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(user.transform.position, (Utilities.GetMousePositsion() - user.transform.position), distance, LayerMask.GetMask("Hittable"));
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
        Debug.DrawLine(user.transform.position, bodiesHit[0].transform.position, Color.red, 0.25f);
        bodiesHit[0].TakeDamage(damage);
    }
}
