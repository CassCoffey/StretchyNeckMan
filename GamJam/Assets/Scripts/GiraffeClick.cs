using UnityEngine;
using System.Collections;

public class GiraffeClick : MonoBehaviour
{
    private bool locked;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<Collider2D>().bounds.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            locked = true;
        }

        if (Input.GetMouseButtonUp(0) && locked)
        {
            locked = false;
        }
	}

    void FixedUpdate()
    {
        if (locked)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
