using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var retryButton = GetComponentInChildren<Button>();
        retryButton.onClick.AddListener(OnRetry);
    }

    private void OnRetry()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }

}
