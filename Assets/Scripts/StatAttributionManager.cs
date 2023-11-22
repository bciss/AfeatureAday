using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatAttributionManager : MonoBehaviour
{
    public  PlayerManager   player;
    public  BodyPartManager bodyPart;
    public Button mindUpButton;
    public Button mindDownButton;
    public Button strengthUpButton;
    public Button strengthDownButton;
    public int mind;
    public int strength;

    // Start is called before the first frame update
    void Start()
    {
        mindUpButton.onClick.AddListener(() => AddMind());
        mindDownButton.onClick.AddListener(() => RemoveMind());
        strengthUpButton.onClick.AddListener(() => AddStrength());
        strengthDownButton.onClick.AddListener(() => RemoveStrength());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddMind()
    {
        if (player.PutRessource(Ressource.mind, bodyPart))
        {
            mind++;
        }
    }

    private void AddStrength()
    {
        if (player.PutRessource(Ressource.strength, bodyPart))
        {
            strength++;
        }
    }
    private void RemoveMind()
    {
        if (player.RemoveRessource(Ressource.mind, bodyPart))
        {
            mind--;
        }
    }
    private void RemoveStrength()
    {
        if (player.RemoveRessource(Ressource.strength, bodyPart))
        {
            strength--;
        }
    }
}
