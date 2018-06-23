using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

    public float speed = 20f;
    
    private SpriteRenderer spriteRend;
    private Rigidbody2D body;

    private float top;
    private float bottom;
    private float left;
    private float right;
    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();

        spriteRend = GetComponent<SpriteRenderer>();
        top = CameraScreen.current.ScreenSize.y - spriteRend.bounds.size.y;
		bottom = -CameraScreen.current.ScreenSize.y + spriteRend.bounds.size.y;
        left = -CameraScreen.current.ScreenSize.x + spriteRend.bounds.size.x/2;
        right = CameraScreen.current.ScreenSize.x - spriteRend.bounds.size.x / 2;
    }

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
    //    body.velocity += move;
        //transform.position += move * speed * Time.deltaTime;
		transform.Translate(move * speed * Time.deltaTime);
    }
}
