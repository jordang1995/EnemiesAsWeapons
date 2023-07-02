using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public Mind mind;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            AI ai = collision.GetComponent<AI>();
            ai.SetTarget(mind.host);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            AI ai = collision.GetComponent<AI>();
            ai.SetTarget(null);
        }
    }
}
