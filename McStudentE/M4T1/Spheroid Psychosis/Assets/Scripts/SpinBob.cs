using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBob : MonoBehaviour {

	public float amplitude;
	public float bobSpeed;
	public float spinSpeed;
	public float adjust; 
	private float tempVal;
	private Vector3 tempPos;

	void Start () 
	{
		tempVal = transform.position.y;
		tempPos = transform.position;
	}

	void Update () 
	{
		transform.Rotate (new Vector3 (spinSpeed, 0, 0) * Time.deltaTime);

		tempPos.y = tempVal + adjust + amplitude * Mathf.Sin (bobSpeed * Time.time);

		transform.position = tempPos;
	}
}
