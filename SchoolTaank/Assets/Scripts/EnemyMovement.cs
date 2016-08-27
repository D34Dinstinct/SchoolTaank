using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    private Rigidbody2D enemyRig;
    public float moveSpeed, wallCheckRad;
    public bool walkRight;
    public Transform wallCheck;
    public LayerMask wall;
    private bool isWall;

	// Use this for initialization
	void Start () {
        enemyRig = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        isWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRad, wall);

        if (isWall)
        {
            walkRight = !walkRight;
        }
        if(walkRight)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            enemyRig.velocity = new Vector2(moveSpeed, enemyRig.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            enemyRig.velocity = new Vector2(-moveSpeed, enemyRig.velocity.y);
        }
	
	}
}
