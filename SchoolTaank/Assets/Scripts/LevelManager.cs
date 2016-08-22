using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public Transform spawnPoint, player;
    private Rigidbody2D playerRig;
    public GameObject deathParticles, spawnParticles;
    private SpriteRenderer playerSpr;
    public float respawnTime;

	// Use this for initialization
	void Start () {
        playerRig = player.GetComponent<Rigidbody2D>();
        playerSpr = player.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    //Wait before spawn
    public IEnumerator RespawnCo()
    {
        Instantiate(deathParticles, player.position, player.rotation);
        playerSpr.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        player.position = spawnPoint.position;
        playerRig.velocity = Vector3.zero;
        Instantiate(spawnParticles, spawnPoint.position, spawnPoint.rotation);
        playerSpr.enabled = true;
    }
}
