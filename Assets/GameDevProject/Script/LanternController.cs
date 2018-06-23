using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour {
	public static LanternController current;
	public float speed;
	public float reachingDistance;

	private SpriteRenderer spriteRend;
	private Rigidbody2D body;

	private float top;
	private float bottom;
	private float left;
	private float right;

	void Awake(){
		current = this;
	}
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();

		spriteRend = GetComponent<SpriteRenderer>();
		top = CameraScreen.current.ScreenSize.y;
		bottom = -CameraScreen.current.ScreenSize.y;
		left = -CameraScreen.current.ScreenSize.x;
		right = CameraScreen.current.ScreenSize.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float verticalVal = Input.GetAxis("Vertical");
		if (verticalVal > 0 && transform.position.y >= top)
			verticalVal = 0;
		else if (verticalVal < 0 && transform.position.y <= bottom)
			verticalVal = 0;

		float horizontalVal = Input.GetAxis("Horizontal");
		if (horizontalVal < 0 && transform.position.x <= left)
			horizontalVal = 0;

		if (horizontalVal > 0 && transform.position.x >= right)
			horizontalVal = 0;

		Vector3 move = new Vector3(horizontalVal, verticalVal, 0);
		//Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		//this.transform.position += move * speed * Time.deltaTime;
		this.transform.Translate( move * speed * Time.deltaTime);
	}

	public bool IsInRadius(Vector3 pos){
		Vector3 currPos = this.transform.position;
		return (pos.x >(currPos.x-reachingDistance) && pos.x < (currPos.x+reachingDistance) && pos.y > (currPos.y - reachingDistance) && pos.y < (currPos.y + reachingDistance));
	}
}
