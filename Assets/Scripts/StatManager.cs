using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatManager : MonoBehaviour
{
    public  Image       statBar;
    public  float       statPercent = 100f;
    public  TMP_Text    label;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public  void    UpdateStat(float statAmount)
    {
        statPercent = statAmount;
        statBar.fillAmount = statPercent / 100f;
        // statAmount = Mathf.Clamp(statPercent, 0, 100);
        // statBar.fillAmount = statPercent / 100f;
    }
}
