using UnityEngine;
using System.Collections;

public class DinoAI : MonoBehaviour {

	public GameObject player;
	public GameObject laser;
	public int timeScaling;
	private float playerDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		playerDistance = -1*(transform.position.x - player.transform.position.x);
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (3 + playerDistance/5 + Time.deltaTime/timeScaling, 0);
	}
}
