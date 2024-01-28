using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
    TMPro.TextMeshProUGUI label;
    // Start is called before the first frame update
    public static HealthCounter Instance;

    void Awake()
    {
        Instance = this;
        label = GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }

    void Start()
    {
        UpdateLabel();
        Player.Instance.OnLoseHealth += UpdateLabel;
    }

    void UpdateLabel()
    {
        label.SetText(Player.Instance.Health.ToString());
    }
   
}
