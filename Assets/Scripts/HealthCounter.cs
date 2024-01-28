using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
    TMPro.TextMeshProUGUI label;
    // Start is called before the first frame update
    public static HealthCounter Instance;

    public int HealthCount = 3;
    void Awake()
    {
        Instance = this;
        label = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        UpdateLabel();
    }

    void UpdateLabel()
    {
        label.SetText(HealthCount.ToString());
    }
   
    public void LoseHealth()
    {
        HealthCount--;
        UpdateLabel();
        if(HealthCount == 0)
        {
            UIManager.Instance.GameOver();
            //TODO: LOSE CONDITION HERE
        }
        else
        {
            //TODO: update health ui, trigger anim, etc
        }
    }
}
