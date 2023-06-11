using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mind : MonoBehaviour
{

    public static Mind mind;

    public Body host;
    public HostMigration hostMigrationAbility;

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
}
