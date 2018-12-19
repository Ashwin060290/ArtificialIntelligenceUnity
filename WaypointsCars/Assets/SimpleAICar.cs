using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleAICar : MonoBehaviour {

	public Transform goal;
	public Text readout;
	public float rotSpeed = 1.0f;
    float accelaration = 5f;
    float deacceleration = 5f;
    float maxSpeed = 100f, minSpeed = 0f;
    float speed = 0f;
    float brakeGoal = 20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 lookAtGoal = new Vector3(goal.position.x, 
										this.transform.position.y, 
										goal.position.z);
		Vector3 direction = lookAtGoal - this.transform.position;

		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
												Quaternion.LookRotation(direction), 
												Time.deltaTime*rotSpeed);

        

        if(Vector3.Angle(goal.transform.forward, this.transform.forward) > brakeGoal)
            speed = Mathf.Clamp(speed - (deacceleration * Time.deltaTime), minSpeed, maxSpeed);
        else
            speed = Mathf.Clamp(speed + (accelaration * Time.deltaTime), minSpeed, maxSpeed);

        this.transform.Translate(0,0,speed);
		AnalogueSpeedConverter.ShowSpeed(speed, minSpeed, maxSpeed);
		readout.text = "" + (int)speed;
	}
}
