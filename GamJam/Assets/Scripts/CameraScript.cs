using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject target;
	public float followSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.transform.position.x, followSpeed*Time.deltaTime), transform.position.y, transform.position.z);
	}
}
