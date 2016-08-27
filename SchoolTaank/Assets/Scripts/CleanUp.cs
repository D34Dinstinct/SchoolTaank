using UnityEngine;
using System.Collections;

public class CleanUp : MonoBehaviour {

    private ParticleSystem particles;


	// Use this for initialization
	void Start () {
        particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (particles.isPlaying)
            return;
        Destroy(gameObject);
	
	}
}
