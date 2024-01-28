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

    void OnSwipe(PlayerInput.SwipeDirection direction)
    {
        var nextPost = PostSpawner.Instance.NextPost;
        switch(direction)
        {
            case PlayerInput.SwipeDirection.RIGHT: 
                if(nextPost.Value == Post.ExistentialValue.DREAD)
                    HealthCounter.Instance.LoseHealth();
                nextPost.Read();
                break;

            case PlayerInput.SwipeDirection.LEFT:
                if(nextPost.Value == Post.ExistentialValue.CHILL)
                    HealthCounter.Instance.LoseHealth();
                nextPost.Read();
                break;
        }
    }

}
