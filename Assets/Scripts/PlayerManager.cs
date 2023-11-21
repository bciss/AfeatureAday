using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Body
{
    public  BodyPartManager head;
    public  BodyPartManager lungs;
    public  BodyPartManager arms;
    public  BodyPartManager diSy;
    public  BodyPartManager legs;
}
[System.Serializable]
public  class Effect
{
    public float healthHealEffect;
    public float healthDamageEffect;
    public float staminaHealEffect;
    public float staminaDamageEffect;
    public int   sequenceDuration;
}

[System.Serializable]
public  class RoundStats
{
    public float    force;
    public float    speed;
    public float    dodge;
    public float    accuracy;
    public float    healthRegain;
    public float    staminaRegain;


    public RoundStats(float force, float speed, float dodge, float accuracy, float healthRegain, float staminaRegain)
    {
        this.force = force;
        this.speed = speed;
        this.dodge = dodge;
        this.accuracy = accuracy;
        this.healthRegain = healthRegain;
        this.staminaRegain = staminaRegain;
    }
    public RoundStats Copy()
    {
        return new RoundStats(this.accuracy, this.speed, this.dodge, this.accuracy, this.healthRegain, this.staminaRegain);
    }

    public void Add(RoundStats roundStats)
    {
        this.force += roundStats.force;
        this.speed += roundStats.speed;
        this.dodge += roundStats.dodge;
        this.accuracy += roundStats.accuracy;
        this.healthRegain += roundStats.healthRegain;
        this.staminaRegain += roundStats.staminaRegain;
    }
        public void Remove(RoundStats roundStats)
    {
        this.force -= roundStats.force;
        this.speed -= roundStats.speed;
        this.dodge -= roundStats.dodge;
        this.accuracy -= roundStats.accuracy;
        this.healthRegain -= roundStats.healthRegain;
        this.staminaRegain -= roundStats.staminaRegain;
    }
}
public class PlayerManager : MonoBehaviour
{

    public  HealthManager           health;
    public  HealthManager           stamina;
    public  RessourceContainerBar   mindBar;
    public  RessourceContainerBar   strengthBar;
    public  int                     baseMind;
    public  int                     baseStrength;
    public  Body                    body;
    public  RoundStats              baseStats;
    public  RoundStats              roundStats;
    public  StatContainer           statDisplay;
    //public  Effect          innateEffect;
    // Start is called before the first frame update
    void Start()
    {
        roundStats = baseStats.Copy();
        statDisplay.UpdateSats(roundStats);
        mindBar.maxContainer = baseMind;
        mindBar.container = baseMind;
        strengthBar.maxContainer = baseStrength;
        strengthBar.container = baseStrength;
        mindBar.DrawContainers();
        strengthBar.DrawContainers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void    PlaySequence()
    {
        // if (innateEffect.sequenceDuration != 0)
        // {
        //     PlayEffect(innateEffect);
        // }
    }

    private void    PlayEffect(Effect effect) {
        
        health.Heal(effect.healthHealEffect);
        health.TakeDamage(effect.healthDamageEffect);
        stamina.Heal(effect.staminaHealEffect);
        stamina.TakeDamage(effect.staminaDamageEffect);
        if (effect.sequenceDuration > 0) {
            effect.sequenceDuration--;
        }
    }

    public void PutRessource(Ressource ressource, BodyPartManager bodyPart)
    {
        if (ressource == Ressource.mind && mindBar.container > 0)
        {
            mindBar.Remove();
            bodyPart.attributedMind++;
            roundStats.Add(bodyPart.effectPerMind);
        } else if (ressource == Ressource.strength && strengthBar.container > 0)
        {
            strengthBar.Remove();
            bodyPart.attributedStrength++;
            roundStats.Add(bodyPart.effectPerStrength);
        }
            statDisplay.UpdateSats(roundStats);

    }
    

    public void RemoveRessource(Ressource ressource, BodyPartManager bodyPart)
    {
        if (ressource == Ressource.mind && mindBar.container < mindBar.maxContainer)
        {
            mindBar.Add();
            bodyPart.attributedMind--;
            roundStats.Remove(bodyPart.effectPerMind);
        } else if (ressource == Ressource.strength && strengthBar.container < strengthBar.maxContainer)
        {
            strengthBar.Add();
            bodyPart.attributedStrength--;
            roundStats.Remove(bodyPart.effectPerStrength);
        }
            statDisplay.UpdateSats(roundStats);
    }
}

public enum Ressource {
    mind, 
    strength
}