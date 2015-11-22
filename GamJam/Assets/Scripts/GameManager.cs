using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int totalScore; //Score of presents + Max distance gone 
	int numPresents; //Score of presents
	float maxDistance; //Max distance gone


	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.x > maxDistance) {
			maxDistance = transform.position.x;
		}

		totalScore = numPresents + (int)maxDistance*20;
	}
}
