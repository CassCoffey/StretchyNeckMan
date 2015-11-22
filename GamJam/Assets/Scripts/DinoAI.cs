using UnityEngine;
using System.Collections;

public class DinoAI : MonoBehaviour {

	public GameObject player;
	public GameObject target;
	public GameObject currentTarget;
	public GameObject laserStart;
	public int timeScaling;
	private bool shooting;
	private bool shotFired;
	private bool targetAcquired;
	private float playerDistance;

	public float shootFrequency = 5;
	public float frequencyTime = 0;	
	public float targetDelay = 2;
	public float shootDelay = 5;
	public float shootTime = 0; 

	// Use this for initialization
	void Start () {
	
	}

	void Update(){
		if (targetAcquired) {
			GetComponent<LineRenderer> ().SetPosition (0, laserStart.transform.position);
			GetComponent<LineRenderer> ().SetPosition (1, 50 * (currentTarget.transform.position - laserStart.transform.position).normalized + laserStart.transform.position);
			GetComponent<LineRenderer> ().material.mainTextureScale = new Vector2 (Vector2.Distance (currentTarget.transform.position, laserStart.transform.position), 1);
		} 
		else {
			GetComponent<LineRenderer> ().SetPosition (0, laserStart.transform.position);
			GetComponent<LineRenderer> ().SetPosition (1, 50 * (player.transform.position - laserStart.transform.position).normalized + laserStart.transform.position);
			GetComponent<LineRenderer> ().material.mainTextureScale = new Vector2 (Vector2.Distance (player.transform.position, laserStart.transform.position), 1);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (shooting) {
			GetComponent<LineRenderer> ().enabled = true;
			shootTime += Time.deltaTime;
			if (shootTime >= targetDelay && !targetAcquired) {
				currentTarget = (GameObject)GameObject.Instantiate (target, player.transform.position, Quaternion.identity);
				targetAcquired = true;
			}
			if (shootTime >= shootDelay - 1 && !shotFired) {
				GetComponent<LineRenderer> ().SetColors (new Color (255, 255, 255, 255), new Color (255, 255, 255, 255));
				GetComponent<LineRenderer> ().SetWidth (1, 1);
			}
			if (shootTime >= shootDelay) {
				shotFired = true;
				shooting = false;
				targetAcquired = false;
				shootTime = 0;
				shootFrequency = 0;
				GetComponent<LineRenderer> ().SetWidth (0.1f, 0.1f);
				GetComponent<LineRenderer> ().SetColors (new Color (255, 255, 255, 120), new Color (255, 255, 255, 120));
				GetComponent<LineRenderer> ().enabled = false;

			}
		} 
		else {
			frequencyTime += Time.deltaTime;
			if(frequencyTime >= shootFrequency){
				shooting = true;
				shotFired = false;
			}
		}
		playerDistance = -1*(transform.position.x - player.transform.position.x);
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (3 + playerDistance/5 + Time.deltaTime/timeScaling, 0);
	}
}
