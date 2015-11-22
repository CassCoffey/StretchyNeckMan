using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

    public GameObject origin;

	// Use this for initialization
	void Start ()
    {
        UnityEngine.Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

        if (origin != null)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(origin.transform.position);
            Vector3 direction = Input.mousePosition - pos;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle - 90, origin.transform.forward);
        }
	}
}
