using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Effect
{
    protected List<Body> hits;
    //public Body user;

    public Effect()
    {
        hits = new List<Body>();
        onHitEvent.AddListener(AddHits);
        onActivateEvent.AddListener(Activate);
    }

    public void AddHits(List<Body> bodies)
    {
        hits.AddRange(bodies);
    }

    public abstract void Activate();

    public class OnHitEvent : UnityEvent<List<Body>> { }
    public OnHitEvent onHitEvent = new OnHitEvent();

    public class OnActivateEvent : UnityEvent { }
    public OnActivateEvent onActivateEvent = new OnActivateEvent();
}
