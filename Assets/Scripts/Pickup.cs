using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Body body = collision.gameObject.GetComponent<Body>();
        Debug.Log(body);
        if (body != null)
        {
            body.Heal(heal);
            GameObject.Destroy(gameObject);
        }
    }
}
