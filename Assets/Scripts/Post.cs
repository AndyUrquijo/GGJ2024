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
    Animator animator;
    [SerializeField] TMPro.TextMeshProUGUI TapCounterLabel;
    public int TapCounter = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if(TapCounterLabel != null )
            TapCounterLabel.SetText(TapCounter.ToString());

    }

    public void SetSpeed(float speed)
    {
        animator.speed = speed;
    }

    public void Read()
    {
        if(Value == ExistentialValue.ANGST)
        {
            Player.Instance.LoseHealth();
        }
        //Debug.Log("Reading");
        Player.Instance.PlayReaction(Reaction);
        animator.speed = 1;
        PostSpawner.Instance.RemovePost(this); 
        animator.SetTrigger("Read");
    }

    public void Pass()
    {
        if(Value == ExistentialValue.CHILL)
        {
            Player.Instance.LoseHealth();
            Player.Instance.PlayReaction("Sad");
        }
        //Debug.Log("Passing");
        animator.speed = 1;
        PostSpawner.Instance.RemovePost(this);
        animator.SetTrigger("Pass");
    }

    public void Blow()
    {
        animator.speed = 1;
        PostSpawner.Instance.RemovePost(this);
        Player.Instance.LoseHealth();
        Player.Instance.PlayReaction("Angry");

    }

    public void Tap()
    {
        animator.SetTrigger("Tap");
        TapCounter--;
        TapCounter = Mathf.Max(0, TapCounter);
        TapCounterLabel.SetText(TapCounter.ToString());
        if(TapCounter <= 0)
            Pass();
    }

    public void Destroy() // Called from anim
    {
        GameObject.Destroy(gameObject);
    }
}