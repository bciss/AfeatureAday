using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatAttributionManager : MonoBehaviour
{
    public  PlayerManager   player;
    public  BodyPartManager bodyPart;
    public Button mindUpButton;
    public Button mindDownButton;
    public Button strengthUpButton;
    public Button strengthDownButton;
    public TMP_Text mindText;
    public TMP_Text strengthText;
    public int mind;
    public int strength;


    // Start is called before the first frame update
    void Start()
    {
        mindText.text = mind.ToString();
        strengthText.text = strength.ToString();
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
        mindText.text = mind.ToString();
    }

    private void AddStrength()
    {
        if (player.PutRessource(Ressource.strength, bodyPart))
        {
            strength++;
        }
        strengthText.text = strength.ToString();
    }
    private void RemoveMind()
    {
        if (player.RemoveRessource(Ressource.mind, bodyPart))
        {
            mind--;
        }
        mindText.text = mind.ToString();
    }
    private void RemoveStrength()
    {
        if (player.RemoveRessource(Ressource.strength, bodyPart))
        {
            strength--;
        }
        strengthText.text = strength.ToString();
    }
}
