using UnityEngine;
using System.Collections;

public class DinoAI : MonoBehaviour {

	public GameObject player;
	public GameObject target;
	public GameObject laserStart;
	public int timeScaling;
	private bool shooting;
	private float playerDistance;

	// Use this for initialization
	void Start () {
	
	}

	void Update(){
		GetComponent<LineRenderer>().SetPosition(0, laserStart.transform.position);
		GetComponent<LineRenderer>().SetPosition(1, 50*(player.transform.position - laserStart.transform.position).normalized + laserStart.transform.position);
		GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(Vector2.Distance(player.transform.position, laserStart.transform.position), 1);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		playerDistance = -1*(transform.position.x - player.transform.position.x);
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (3 + playerDistance/5 + Time.deltaTime/timeScaling, 0);
	}
}
