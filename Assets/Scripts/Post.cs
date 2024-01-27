using System.Collections;
using System.Collections.Generic;
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

    public float Speed;

    public void Update()
    {
        transform.position += Vector3.up * Speed *Time.deltaTime;
    }
}