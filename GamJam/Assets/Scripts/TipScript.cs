using UnityEngine;
using System.Collections;

public class TipScript : MonoBehaviour {

    public GameObject tipWindow;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetButtonDown("Fire1"))
        {
            Time.timeScale = 1f;
            tipWindow.SetActive(false);
        }
	}
}
