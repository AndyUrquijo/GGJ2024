using UnityEngine;

public class Post : MonoBehaviour
{
    public enum ExistentialValue
    {
        CHILL, 
        DREAD
    }
    public ExistentialValue Value;

    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
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

    public void Destroy() // Called from anim
    {
        GameObject.Destroy(gameObject);
    }
}