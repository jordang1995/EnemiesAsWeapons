using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostMigration : Effect
{
    public HostMigration() : base() {}

    public override void Activate()
    {
        Mind.MigrateHost(hits[0]);
    }
}
