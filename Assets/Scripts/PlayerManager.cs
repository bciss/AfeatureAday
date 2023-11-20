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
public class PlayerManager : MonoBehaviour
{

    public  HealthManager   health;
    public  HealthManager   stamina;
    public  Body            body;
    public  Effect          innateEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void    PlaySequence()
    {
        if (innateEffect.sequenceDuration != 0)
        {
            PlayEffect(innateEffect);
        }
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
}
