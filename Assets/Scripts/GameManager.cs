using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public  GameObject          GamePanel;
    public  GameObject          WinPanel;
    public  GameObject          LoosePanel;
    public  int                 Countdown = 3;
    public  List<GameObject>    HPs;
    private int                 HPcount;

    // Start is called before the first frame update
    void Start()
    {
        HPcount = HPs.Count - 1;
        Countdown = HPs.Count;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void WinButtonPressed() {

        Countdown -= 1;
        HPs[HPcount].SetActive(false);
        HPcount -= 1;
        if (Countdown <= 0) {
            Win();
        }
    }

    public void LooseButtonPressed() {
        Loose();
    }
    
    private void Win() {
        GamePanel.SetActive(false);
        WinPanel.SetActive(true);
    }

    private void Loose() {
        GamePanel.SetActive(false);
        LoosePanel.SetActive(true);
    }
}
