using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mind : MonoBehaviour
{

    public static Mind mind;

    public Body host;

    public enum GameState
    {
        Running, Paused
    }

    public GameState gameState;

    private void Start()
    {
        Mind.mind = this;
        MigrateHost(host);
    }

    public void MigrateHost(Body newHost)
    {
        if (host != null)
        {
            host.toggleAI = true;
            host.gameObject.tag = "Enemy";
        }
        host = newHost;
        gameObject.transform.SetParent(host.gameObject.transform, false);
        host.toggleAI = false;
        host.gameObject.tag = "Host";
    }

}
