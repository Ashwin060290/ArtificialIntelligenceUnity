using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class WayPointUsingWPCircuit : MonoBehaviour {

    public WaypointCircuit circuit;
    private int currentPoint = 0;
    private float speed = 10f, rotSpeed = 10f, accuracy = 2f;

    void FixedUpdate()
    {
        if (circuit.Waypoints.Length == 0) return;

        if (currentPoint == circuit.Waypoints.Length) currentPoint = 0;

        Vector3 lookAtGoal = new Vector3(circuit.Waypoints[currentPoint].transform.position.x, this.transform.position.y, circuit.Waypoints[currentPoint].transform.position.z);

        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

        this.transform.Translate(0,0,speed*Time.deltaTime);

        if (direction.magnitude < accuracy)
            currentPoint++;
    }
}
