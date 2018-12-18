using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaPointFollow : MonoBehaviour {

    private GameObject[] waypoints;
    private int firstPoint = 0;

    public float speed = 10f, rotSpeed = 10f, accuracy = 2f;
	// Use this for initialization
	void Start () {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (waypoints.Length == 0) return;

        if (firstPoint == waypoints.Length)
            firstPoint = 0;
        Debug.Log(firstPoint);

        Vector3 lookAtGoal = new Vector3(waypoints[firstPoint].transform.position.x, this.transform.position.y, waypoints[firstPoint].transform.position.z);

        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

        if(direction.magnitude < accuracy)
        {
            firstPoint++;
        }

        this.transform.Translate(0,0,speed* Time.deltaTime);
	}
}
