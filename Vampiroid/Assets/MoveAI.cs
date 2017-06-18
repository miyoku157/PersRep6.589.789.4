using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAI : MonoBehaviour {

    [SerializeField]
    private List<GameObject> Waypoints;

    [SerializeField]
    private bool repeat;

    private Vector2 Target;

    private int TargetIndex=0;

    private float Speed = 10;
	// Use this for initialization
	void Start () {
        if (Waypoints != null)
        {
            Target = Waypoints[TargetIndex].transform.position;
        }
        else
        {
            enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, Target) < 0.05)
        {
            TargetIndex++;
            if (Waypoints.Count <=TargetIndex)
            {
                if (repeat)
                {
                    TargetIndex = 0;
                }
            }
            Target = Waypoints[TargetIndex].transform.position;
        }
    }
}
