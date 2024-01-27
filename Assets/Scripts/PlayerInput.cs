using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour, IEndDragHandler, IPointerClickHandler, IDragHandler, IBeginDragHandler
{
    public enum SwipeDirection
    {
        UP,
        DOWN,
        RIGHT,
        LEFT
    }
    public static PlayerInput Instance { get; private set; }

    public Action<SwipeDirection> OnSwipe;

    private void Awake()
    {
        Instance = this;
        OnSwipe += (dir) => Debug.Log("Swipped " + dir);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("BeginDrag");
        var swipeDir = GetDragDirection(eventData.position - eventData.pressPosition);
        OnSwipe.Invoke(swipeDir);
    }


    private SwipeDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        SwipeDirection draggedDir;
        if(positiveX > positiveY)
        {
            draggedDir = (dragVector.x > 0) ? SwipeDirection.RIGHT : SwipeDirection.LEFT;
        }
        else
        {
            draggedDir = (dragVector.y > 0) ? SwipeDirection.UP : SwipeDirection.DOWN;
        }
        return draggedDir;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Click");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("BeginDrag");
    }
}
