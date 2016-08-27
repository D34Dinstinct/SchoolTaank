using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Transform spawnPoint, player;
    private Rigidbody2D playerRig;
    public GameObject deathParticles, spawnParticles;
    private SpriteRenderer playerSpr;
    public float respawnTime;
    public static int score;
    public Text scoreText;
    public int deathPoints;
    public bool checkPoint;


	// Use this for initialization
	void Start () {
        score = 0;
        playerRig = player.GetComponent<Rigidbody2D>();
        playerSpr = player.GetComponent<SpriteRenderer>();
	}
	

	// Update is called once per frame
	void Update () {
	    if(score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;
	}

    public static void AddPoints(int points)
    {
        score += points;
    }

    public static void Reset()
    {
        score = 0;
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
        AddPoints(deathPoints);
        yield return new WaitForSeconds(respawnTime);
        player.position = spawnPoint.position;
        playerRig.velocity = Vector3.zero;
        Instantiate(spawnParticles, spawnPoint.position, spawnPoint.rotation);
        playerSpr.enabled = true;
    }
}
