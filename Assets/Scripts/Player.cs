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
        var spawner = PostSpawner.Instance;
        switch(direction)
        {
            case PlayerInput.SwipeDirection.RIGHT:
            case PlayerInput.SwipeDirection.LEFT:
                spawner.RemovePost(spawner.NextPost);
                break;
        }
    }

}
