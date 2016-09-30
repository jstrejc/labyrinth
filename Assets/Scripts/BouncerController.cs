using UnityEngine;
using System.Collections;

public class BouncerController : MonoBehaviour {

	public float strength;

	private AudioSource audioBounce;

	// Use this for initialization
	void Start () {
		audioBounce = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			Rigidbody rb = collision.gameObject.GetComponent<Rigidbody> ();

			Vector3 normal = (rb.transform.position - transform.position);
			normal.y = 0.0f;
			normal = normal.normalized;

			audioBounce.Play ();
			rb.AddForce (normal * strength);
		}
	}
}
