using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        PlayerInput.Instance.OnSwipe += OnSwipe;
    }

    private void OnSwipe(PlayerInput.SwipeDirection direction)
    {
        switch(direction)
        {
            case PlayerInput.SwipeDirection.RIGHT:
                break;
            case PlayerInput.SwipeDirection.LEFT:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
