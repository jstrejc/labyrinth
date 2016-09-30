using UnityEngine;
using System.Collections;

public class DeathController : MonoBehaviour {

	public GameObject start;
	public GameObject explosion;
	public GameObject playerExplosion;

	private Vector3 offset;

	private AudioSource audioBang;

	// Use this for initialization
	void Start () {
		offset = new Vector3 (0, 1, 0);
		audioBang = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		audioBang.Play ();
		if (other.tag == "Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			other.transform.position = start.transform.position + offset;
			Rigidbody rb = other.GetComponent<Rigidbody> ();
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		} else {
			Destroy (other, 2f);
			Instantiate(explosion, other.transform.position, other.transform.rotation);
		}
	}
}
