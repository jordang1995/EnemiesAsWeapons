using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Body owner;
    public float duration;
    public float range;
    public float speed;

    private Vector3 direction;
}
