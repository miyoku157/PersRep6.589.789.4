using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAI : MonoBehaviour {

    [SerializeField]
    private List<GameObject> Waypoints;

    [SerializeField]
    private bool repeat;

    [SerializeField]
    private AnimationCurve curve; 

    private Vector2 Target;

    private int TargetIndex=0;

    private float time=0;

    private float percent;

    private float origine;

    private Vector2 direction;

    [SerializeField]
    private float Speed = 0.1f;
	// Use this for initialization
	void Start () {
        if (Waypoints != null)
        {
            Target = Waypoints[TargetIndex].transform.position;
            origine = Vector2.Distance(transform.position, Target);
            percent = (origine-Vector2.Distance(transform.position, Target)) / Vector2.Distance(transform.position, Target) * 100;
            Lookat2d(Waypoints[0]);
        }
        else
        {
            enabled = false;
        }
	}
    private void FixedUpdate()
    {

        if (GetComponent<Rigidbody2D>().velocity.magnitude > Speed)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * Speed;
            time = 0.5f;
        }
        else {

            if (time < 0.5f && percent < 25)
            {
                time += 0.1f;
                GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * Speed * curve.Evaluate(time), ForceMode2D.Force);
            }
        }
        if (percent > 75)
        {
            time += 0.1f;
            GetComponent<Rigidbody2D>().AddRelativeForce(-Vector2.right * Speed * curve.Evaluate(time), ForceMode2D.Force);
        }
        percent = (origine - Vector2.Distance(transform.position, Target)) / origine * 100;

    }
    // Update is called once per frame
    void Update () {
        
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

    private void Lookat2d(GameObject input)
    {
        Vector3 diff = input.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        GetComponent<Rigidbody2D>().MoveRotation(rot_z);
        direction = diff;
    }
}
