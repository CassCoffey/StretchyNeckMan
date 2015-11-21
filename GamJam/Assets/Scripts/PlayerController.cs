using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float movePower;

    public GameObject grappleFab;

    private float fx;
    private bool grappling = false;
    private GameObject grappleActive;
	
	// Update is called once per frame
	void Update ()
    {
        CheckInput();
	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(fx * movePower, 0));

        if (grappling)
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, grappleActive.transform.position);
            GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(Vector2.Distance(grappleActive.transform.position, transform.position), 1);
        }
    }

    private void CheckInput()
    {
        fx = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Fire1"))
        {
            if (grappling)
            {
                Destroy(grappleActive);
                grappling = false;
                GetComponent<LineRenderer>().enabled = false;
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, transform.position);
            }
            else
            {
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 direction = Input.mousePosition - pos;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                grappleActive = (GameObject)Instantiate(grappleFab, transform.position, Quaternion.AngleAxis(angle - 90f, Vector3.forward));

                grappling = true;
                GetComponent<LineRenderer>().enabled = true;
            }
        }
    }
}