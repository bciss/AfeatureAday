using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats {
    public StatManager  force;
    public StatManager  speed;
    public StatManager  dodge;
    public StatManager  accuracy;
    public StatManager  healthRegain;
    public StatManager  staminaRegain;
}
public class StatContainer : MonoBehaviour
{
    public Stats    stats;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void UpdateSats(RoundStats stat)
    {
        stats.force.UpdateStat(stat.force);
        stats.speed.UpdateStat(stat.speed);
        stats.dodge.UpdateStat(stat.dodge);
        stats.accuracy.UpdateStat(stat.accuracy);
        stats.healthRegain.UpdateStat(stat.healthRegain);
        stats.staminaRegain.UpdateStat(stat.staminaRegain);
    }
}
