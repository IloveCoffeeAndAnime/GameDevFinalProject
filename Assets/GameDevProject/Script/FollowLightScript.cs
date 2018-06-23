using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLightScript : MonoBehaviour {
	public float speed;
	 float leftBound;
	 float rightBound;
	 float topBound;
	 float bottomBound;
	Vector3 currDirection;
	//time during which objec tmoves in certain direction
	float timeForDirection = 0f;
	const float minTimeForDirection = 0.5f;
	const float maxTimeForDirection = 1.0f;
	float savedTime = 0;

	// Use this for initialization
	void Start () {
		currDirection = GetRandomDir ();
		timeForDirection = Random.Range (minTimeForDirection,maxTimeForDirection);
		savedTime = Time.time;
		leftBound = -CameraScreen.current.ScreenSize.x;
		rightBound = CameraScreen.current.ScreenSize.x;
		topBound = CameraScreen.current.ScreenSize.y;
		bottomBound =  -CameraScreen.current.ScreenSize.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (LanternController.current.IsInRadius (this.transform.position)) {
			MoveToLantern ();
		} else {
			MakeRandoMove ();
		}
	}

	void MoveToLantern(){
		this.transform.position = Vector3.MoveTowards (this.transform.position, LanternController.current.transform.position, speed);
	}

	void MakeRandoMove(){
		if (Time.time - savedTime >= timeForDirection) {
			savedTime = Time.time;
			currDirection = GetRandomDir ();
		}
		Vector3 newPos = this.transform.position + currDirection * speed;
		Vector3 diff = BoundAndPosDiff (newPos);
		this.transform.position = newPos + diff;
	}

	Vector3 GetRandomDir(){
		var x = Random.Range(-1f, 1f);
		var y = Random.Range(-1f, 1f);
		return new Vector3(x, y, 0f).normalized;
	}
		

	Vector3 BoundAndPosDiff(Vector3 pos){
		Vector3 diff = new Vector3 (0,0,0);
		if (pos.x <= leftBound)
			diff.x = leftBound - pos.x;
		else if (pos.x >= rightBound)
			diff.x = rightBound - pos.x;
		if (pos.y >= topBound)
			diff.y = topBound - pos.y;
		else if (pos.y <= bottomBound)
			diff.y = bottomBound - pos.y;
		return diff;
	}
}
