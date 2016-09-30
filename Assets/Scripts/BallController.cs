using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	public Text countText;
	public float speed;
	public int count;

	private Rigidbody rb;
	private int currentCount;
	private AudioSource audioBang;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		currentCount = 0;
		SetCountText ();
		audioBang = GetComponent<AudioSource> ();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal") + Input.acceleration.x;
		float moveVertical = Input.GetAxis ("Vertical") + Input.acceleration.y;

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Coin")) {
			audioBang.Play ();
			currentCount++;
			SetCountText ();

			if (currentCount >= count) {
				//TODO Win game
			}
		}
	}

	void SetCountText () {
		countText.text = "Coins: " + currentCount + "/" + count;
	}
}
