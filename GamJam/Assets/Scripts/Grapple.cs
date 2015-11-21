using UnityEngine;
using System.Collections;

public class Grapple : MonoBehaviour
{
    public float force;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * force, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    
	}

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "grapple")
        {
            transform.parent = hit.transform;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}