using UnityEngine;
using System.Collections;

public class GiraffeClick : MonoBehaviour
{
    public float force;

    private bool locked;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0) && locked)
        {
            locked = false;
        }
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            locked = true;
        }
    }

    void FixedUpdate()
    {
        if (locked)
        {
            Vector2 mouse = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            GetComponent<Rigidbody2D>().AddForce((mouse - position) * force);
        }
    }
}
