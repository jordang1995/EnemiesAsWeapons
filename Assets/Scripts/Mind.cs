using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mind : MonoBehaviour
{

    public static Mind mind;

    public Body host;
    public HostMigration hostMigrationAbility;

    public UnityEvent<Body> deadBodyEvent;

    public enum GameState
    {
        Running, Paused
    }

    public GameState gameState;

    private void Start()
    {
        Mind.mind = this;
        MigrateHost(host);
        deadBodyEvent = new UnityEvent<Body>();
        deadBodyEvent.AddListener(DeadBodyEventHandler);
    }

/*    private void Update()
    {
        host.TakeDamage(Time.deltaTime * 50f);
    }*/

    public static void MigrateHost(Body newHost)
    {
        Mind.mind.host.toggleAI = true;
        Mind.mind.host.gameObject.tag = "Enemy";
        Mind.mind.host.abilities[0] = null;
        Mind.mind.host = newHost;
        Mind.mind.gameObject.transform.SetParent(Mind.mind.host.gameObject.transform, false);
        Mind.mind.host.toggleAI = false;
        Mind.mind.host.gameObject.tag = "Host";
        Mind.mind.host.abilities[0] = Mind.mind.hostMigrationAbility;
    }

    public void DeadBodyEventHandler(Body body)
    {
        if (body == host)
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        Debug.Log("Game Over!");
    }
}
