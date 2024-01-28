using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

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
        PlayerInput.Instance.OnTap += OnTap;
    }

    private void OnTap()
    {
        // TODO: Dread cards here
        var nextPost = PostSpawner.Instance.NextPost;
        if(nextPost == null) return;
        if(nextPost.Value == Post.ExistentialValue.DREAD)
            nextPost.Tap();
    }

    void OnSwipe(PlayerInput.SwipeDirection direction)
    {
        var nextPost = PostSpawner.Instance.NextPost;
        if(nextPost == null) return;

        if(nextPost.Value == Post.ExistentialValue.DREAD) return;


        switch(direction)
        {
            case PlayerInput.SwipeDirection.RIGHT:
                nextPost.Read();
                break;

            case PlayerInput.SwipeDirection.LEFT:
                nextPost.Pass();
                break;
        }
    }

    public void PlayReaction(string emotion)
    {
        animator.SetTrigger(emotion);
    }

    public void LoseHealth()
    {
        Health--;
        Health = Math.Max(0, Health);

        animator.SetFloat("HealthRatio", (float)Health / MaxHealth);
        OnLoseHealth.Invoke();
        if(Health <= 0)
        {
            string gameOverLabel = UnityEngine.Random.Range(0, 2) == 0 ?
                "Consumiste demasiado contenido político y te has convertido en militante de un partido de extrema derecha." :
                "Tuviste una sobredosis de preocupación y desarrollaste un trastorno de ansiedad.";

            UIManager.Instance.GameOver("GAME OVER", gameOverLabel);
            PlayReaction("Dead");
        }
        else
        {
            OnLoseHealth.Invoke();
        }
    }
}
