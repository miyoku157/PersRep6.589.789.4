using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class Move : MonoBehaviour {


    [Tooltip("The Speed of the player, *2 if double tap")]
    public float Speed = 10;

    [Tooltip("The distance from the finger the prefab will move")]
    public float Distance = 10.0f;

    private bool isRunning = false;

    private Vector2 target;

    private void Start()
    {
        target = transform.position;
    }
    private void Update()
    {
        if (!isRunning)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Speed * 10 * Time.deltaTime);
        }
    }
    public void MoveSimple(LeanFinger finger)
    {
        isRunning = false;
        if(finger!= null)
            target = finger.GetWorldPosition(Distance);
    }

    public void MoveDouble(LeanFinger finger)
    {
        isRunning = true;
        if (finger != null)
            target = finger.GetWorldPosition(Distance);
    }
}

