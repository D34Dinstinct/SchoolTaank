using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public Transform spawnPoint, player;
    private Rigidbody2D playerRig;

	// Use this for initialization
	void Start () {
        playerRig = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Respawn()
    {
        player.position = spawnPoint.position;
        playerRig.velocity = Vector3.zero;
    }
}
