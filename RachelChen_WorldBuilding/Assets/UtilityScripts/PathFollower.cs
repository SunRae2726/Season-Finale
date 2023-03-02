using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Rigidbody))]

public class PathFollower : MonoBehaviour {


	List<Transform>  wayPoints = new List<Transform>();
	int targetWayPt = 0;
	public float speed = 2;
	public float waitTime = 2;
	float timeToMove = float.NegativeInfinity;
	// Use this for initialization
	void Start () {
		for (int wayPoint = 1; wayPoint < this.transform.childCount + 1; wayPoint++)
		{
			for (int i = 0; i < this.transform.childCount; i++)
			{
				if (this.transform.GetChild(i).name == wayPoint.ToString())
				{
					this.wayPoints.Add(this.transform.GetChild(i));
					break;
				}
			}
		}
		this.transform.DetachChildren();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 towards = wayPoints[targetWayPt].position - this.transform.position;
		float distance = towards.magnitude;
		towards.Normalize();

		float effSpeed = Mathf.Min(speed*Time.fixedDeltaTime, distance); 

		//this.transform.position += towards*effSpeed;
		this.GetComponent<Rigidbody>().MovePosition(this.transform.position + towards*effSpeed);

		if (distance < .1f)
		{
			if (timeToMove == float.NegativeInfinity)
			{
				timeToMove = Time.time + waitTime;
			} 
			else if (Time.time >= timeToMove)
			{
				targetWayPt = (targetWayPt + 1) % wayPoints.Count;
				timeToMove = float.NegativeInfinity;
			}
		}
	}
}
