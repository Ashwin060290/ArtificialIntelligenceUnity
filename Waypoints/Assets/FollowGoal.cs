using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGoal : MonoBehaviour {

    [SerializeField]
    private GameObject goal;

    private float speed = 10f, rotSpeed = 10f, accuracy = 2;

    void FixedUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.transform.position.x, this.transform.position.y, goal.transform.position.z);

        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

        //if (direction.magnitude > accuracy)
            this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
