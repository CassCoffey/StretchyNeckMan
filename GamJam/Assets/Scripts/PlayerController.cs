using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    float movePower;
	
	// Update is called once per frame
	void Update ()
    {
        float fx = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(fx, 0));
	}
}
