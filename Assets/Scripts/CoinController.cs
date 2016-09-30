using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	private Vector3 position;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation *= Quaternion.Euler (new Vector3 (90f, 0f, 0f) * Time.deltaTime);
		transform.position = position + new Vector3(0f, Mathf.Sin (Time.realtimeSinceStartup) * 0.05f, 0f);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Destroy (gameObject);
			Instantiate(explosion, transform.position, transform.rotation);
		}
	}
}
