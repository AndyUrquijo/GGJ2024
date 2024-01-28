using UnityEngine;

public class Post : MonoBehaviour
{
    public enum ExistentialValue
    {
        CHILL, // Swipe these right
        ANGST, // Swpie these left
        DREAD // tap the heck out of em
    }
    public ExistentialValue Value;
    public string Reaction;
    [HideInInspector] public int ReactionId;
    Animator animator;

    public int TapCounter = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        ReactionId = Animator.StringToHash(Reaction);
    }

    public void SetSpeed(float speed)
    {
        animator.speed = speed;
    }

    public void Read()
    {
        Debug.Log("Reading");
        PostSpawner.Instance.RemovePost(this);
        animator.SetTrigger("Read");
    }

    public void Pass()
    {
        Debug.Log("Passing");
        PostSpawner.Instance.RemovePost(this);
        animator.SetTrigger("Pass");
    }

    public void Blow()
    {
        PostSpawner.Instance.RemovePost(this);
        Player.Instance.LoseHealth();
    }

    public void Tap()
    {
        animator.SetTrigger("Tap");
    }

    public void Destroy() // Called from anim
    {
        GameObject.Destroy(gameObject);
    }
}