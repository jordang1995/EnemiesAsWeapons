using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRayCastHit : Ability
{

    public float distance;
    public float damage;

    public override void AddHits(List<Body> bodiesHit)
    {
        Vector2 direction = Utilities.GetMousePositsion() - user.transform.position;
        //RaycastHit2D hit = Physics2D.Raycast(user, );
    }

    public override void HitBodies(List<Body> bodiesHit)
    {
        
    }
}
