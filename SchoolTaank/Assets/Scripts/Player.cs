using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float moveSpeed, jumpPower, floorCheckRad;
    public Transform floorCheck;
    public LayerMask isFloor;

    private bool onFLoor, jumped;
    private Rigidbody2D player;
    private Animator anim;

	// Use this for initialization
	void Start () {

        player = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
	}
	
    void FixedUpdate()
    {
        onFLoor = Physics2D.OverlapCircle(floorCheck.position, floorCheckRad, isFloor);
    }

	// Update is called once per frame
	void Update () {

        if (onFLoor) {
            jumped = false;
            anim.SetBool("isJumping", false);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            player.velocity = new Vector2(moveSpeed, player.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
            
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            player.velocity = new Vector2(-moveSpeed, player.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onFLoor)
        {
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && !jumped && !onFLoor)
        {
            Jump();
            jumped = true;
        }
        anim.SetFloat("speed", Mathf.Abs(player.velocity.x));
    }

    public void Jump()
    {
        player.velocity = new Vector2(player.velocity.x, jumpPower);
        anim.SetBool("isJumping", true);
    }
}
