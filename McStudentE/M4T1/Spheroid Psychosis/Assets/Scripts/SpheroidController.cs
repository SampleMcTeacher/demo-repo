using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpheroidController : MonoBehaviour {

	public float speed;
	public float bottom;
	public Text numCoinsText;
	public Text completedText;
	public Text timerText;
	public int totalCoins;

	private Rigidbody rigBod;
	private int numCoins;

	void Start ()
	{
		rigBod = GetComponent<Rigidbody>();
		numCoins = 0;
		CountNumCoinsText ();
		completedText.text = "";
	} 

	void FixedUpdate ()
	{
		float rollHorizontal = Input.GetAxis ("Horizontal");
		float rollVertical = Input.GetAxis ("Vertical");

		Vector3 roll = new Vector3 (rollHorizontal, 0.0f, rollVertical);

		timerText.text = Time.time.ToString ("0.00");

		rigBod.AddForce (roll * speed);

		if (transform.position.y < bottom)
		{  

			transform.position = new Vector3 (0, 1f, 0);

			rigBod.velocity = new Vector3 (0, 0, 0);

			rigBod.angularVelocity = new Vector3 (0, 0, 0);
		} 
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Coin"))
		{
			other.gameObject.SetActive (false);
			numCoins = numCoins + 1;
			CountNumCoinsText ();
		}
	}

	void CountNumCoinsText ()
	{
		numCoinsText.text = "Coins collected: " + numCoins.ToString ();
		if (numCoins >= totalCoins)
		{
			completedText.text = "Level Completed!  Time: " + Time.time.ToString ("0.00");
		}
	}
}