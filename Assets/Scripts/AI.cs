using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Body target;
    public Body body;
    public List<NavMesh.Node> path = new List<NavMesh.Node>();
    public float pathingFrequency;
    public float arriveDistanceForAttacking;
    public float arriveDistanceForTravelling;

    private float nextPathing;

    private void Start()
    {
        nextPathing = Time.time;
    }

    public void Delegate()
    {
        if (target != null)
        {
            if (SeesTarget())
            {
                if (HasArrivedAtPoint(target.transform.position, arriveDistanceForAttacking))
                {
                    body.controller.LookAt(target.transform.position);
                    body.controller.UseAbility(1, target.transform.position);
                }
                else
                {
                    TravelTowardsPoint(target.transform.position);
                }
            }
            else
            {
                if (Time.time >= nextPathing)
                {
                    path = NavMesh.Instance.GetPath(body.transform.position, target.transform.position);
                    nextPathing = Time.time + pathingFrequency;
                }
                FollowPath();
            }
        }
        else
        {
            //Wander?
        }
    }

    public void TravelTowardsPoint(Vector3 point)
    {
        body.controller.LookAt(point);
        body.controller.Move((point - body.transform.position).normalized);
    }

    public bool HasArrivedAtPoint(Vector3 point, float arriveDistance)
    {
        return ((point - body.transform.position).magnitude <= arriveDistance);
    }

    public void FollowPath()
    {
        if (HasArrivedAtPoint(path[0].position, arriveDistanceForTravelling))
        {
            path.RemoveAt(0);
        }
        TravelTowardsPoint(path[0].position);
    }

    public bool SeesTarget()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(body.transform.position, (target.transform.position - body.transform.position), (target.transform.position - body.transform.position).magnitude, LayerMask.GetMask("Impassable"));
        if (hits.Length > 0)
        {
            return false;
        }
        return true;
    }

    public void SetTarget(Body target)
    {
        this.target = target;
    }
}
