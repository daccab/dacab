using UnityEngine;
using System.Collections;

public class heroScript : MonoBehaviour {
    public float speed = 10f;

    bool facingRight = true;

    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    Rigidbody2D rig;

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        float move;
        move = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(move * speed, rig.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            rig.AddForce(new Vector2(0, 700f));
        }
        if ((move < 0) && facingRight)
            Flip();
        else
            if ((move > 0) && !facingRight)
            Flip();
	}
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
