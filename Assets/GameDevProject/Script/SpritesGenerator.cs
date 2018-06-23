using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesGenerator : MonoBehaviour {

    public GameObject ayakashiPrefab;
    public float pause = 2f;
    public float jumpForce = 10f;

    private Vector3 startPos;
    private float timer = 0f ;
	public bool xPosRandom;

	// Use this for initialization
	void Start () {
		startPos = new Vector3(-CameraScreen.current.ScreenSize.x, -CameraScreen.current.ScreenSize.y, 0);
		Debug.Log ("StartPos: "+startPos);
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = pause;
			if (xPosRandom) {
				startPos.x = Random.Range(-CameraScreen.current.ScreenSize.x, CameraScreen.current.ScreenSize.x);
			}
			CreateObjectJumping (startPos);
        }
    }

	private void CreateObjectJumping(Vector3 startPos)
    {
      //  startPos.x = Random.Range(-CameraScreen.current.ScreenSize.x, CameraScreen.current.ScreenSize.x);
        GameObject obj = GameObject.Instantiate(this.ayakashiPrefab, startPos, transform.rotation);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
    }

	/*private void CreateObjectNotJumping()
	{
		startPos.x = -CameraScreen.current.ScreenSize.x;
		GameObject obj = GameObject.Instantiate(this.ayakashiPrefab, startPos, transform.rotation);
	}*/

}
