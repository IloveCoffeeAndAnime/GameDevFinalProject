using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesGenerator : MonoBehaviour {

    public GameObject ayakashiPrefab;
    public float pause = 2f;
    public float jumpForce = 1000f;

    private Vector3 startPos;
    private float timer = 0f ;

	// Use this for initialization
	void Start () {
        startPos = new Vector3(0, -CameraScreen.current.ScreenSize.y, 0);
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
            CreateObject();
        }
    }

    private void CreateObject()
    {
        startPos.x = Random.Range(-CameraScreen.current.ScreenSize.x, CameraScreen.current.ScreenSize.x);
        GameObject obj = GameObject.Instantiate(this.ayakashiPrefab, startPos, transform.rotation);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
    }
}
