using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Post : MonoBehaviour
{
    public enum ExistentialValue
    {
        CHILL, 
        DREAD
    }
    public ExistentialValue Value;

    public void SetSpeed(float speed)
    {
        GetComponent<Animator>().speed = speed;
    }

    public void Read()
    {
        PostSpawner.Instance.RemovePost(this);
        GameObject.Destroy(gameObject); // TODO: Replace with anim
    }

    public void Ignore()
    {
        PostSpawner.Instance.RemovePost(this);
        GameObject.Destroy(gameObject); // TODO: Replace with anim
    }
}