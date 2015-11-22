using UnityEngine;
using System.Collections;

public class NeckMenuScript : MonoBehaviour {

	public GameObject neckStart;
	public GameObject neckEnd;
	
	// Update is called once per frame
	void Update () {
	
		GetComponent<LineRenderer>().SetPosition(0, neckStart.transform.position);
		GetComponent<LineRenderer>().SetPosition(1, neckEnd.transform.position);
		GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(Vector2.Distance(neckEnd.transform.position, neckStart.transform.position), 1);
	}
}
