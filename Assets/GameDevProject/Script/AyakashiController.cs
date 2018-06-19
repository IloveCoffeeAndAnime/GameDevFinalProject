using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyakashiController : MonoBehaviour
{
    public float jumpForce = 1000f;
    public Transform groundCheck;
    public LayerMask ground;
    public GameObject cloud;

    private GameObject Boost;

    private Rigidbody2D rb2d;
    private Animator anim;

    private bool isGrounded = false;
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Debug.Log("Jump force: " + jumpForce);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.0F, ground);
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

        if (transform.position.x < -CameraScreen.current.ScreenSize.x ||
                transform.position.x > CameraScreen.current.ScreenSize.x ||
                transform.position.y < -CameraScreen.current.ScreenSize.y ||
                transform.position.y > CameraScreen.current.ScreenSize.y)
            Destroy(this.gameObject, 1f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collide");
        if (col.gameObject.tag == "Panel")
        {
            Debug.Log("Collide with panel");
            Jump();
        }
    }

    private void Jump()
    {
        rb2d.AddForce(new Vector2(0, jumpForce));
        Boost = Instantiate(cloud, transform.position, transform.rotation) as GameObject;

    }
}
