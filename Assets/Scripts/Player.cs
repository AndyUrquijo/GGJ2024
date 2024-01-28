using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public int Health;
    public int MaxHealth { get; private set; }

    public Action OnLoseHealth;
    [SerializeField] Animator animator;

    void Awake()
    {
        Instance = this;
        MaxHealth = Health;
        animator.SetFloat("HealthRatio", 1);
    }

    void Start()
    {
        PlayerInput.Instance.OnSwipe += OnSwipe;
    }

    void OnSwipe(PlayerInput.SwipeDirection direction)
    {
        var nextPost = PostSpawner.Instance.NextPost;
        if(nextPost == null) return;

        switch(direction)
        {
            case PlayerInput.SwipeDirection.RIGHT:
                if(nextPost.Value == Post.ExistentialValue.DREAD)
                {
                    LoseHealth();
                    animator.SetTrigger(nextPost.ReactionId);
                }
                else
                {
                    animator.SetTrigger(nextPost.ReactionId);
                    //animator.SetTrigger("Glad");
                }

                nextPost.Read();
                break;

            case PlayerInput.SwipeDirection.LEFT:
                if(nextPost.Value == Post.ExistentialValue.CHILL)
                {
                    LoseHealth();
                    animator.SetTrigger("Sad");
                }
                else
                {
                    //animator.SetTrigger("sumthin");
                }

                nextPost.Pass();
                break;
        }
    }

    public void LoseHealth()
    {
        Health--;
        Health = Math.Max(0, Health);

        animator.SetFloat("HealthRatio", (float)Health / MaxHealth);
        OnLoseHealth.Invoke();
        if(Health <= 0)
        {
            UIManager.Instance.GameOver();
            //TODO: LOSE CONDITION HERE
        }
        else
        {
            OnLoseHealth.Invoke();
            //TODO: update health ui, trigger anim, etc
        }
    }
}
