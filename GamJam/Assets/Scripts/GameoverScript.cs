using UnityEngine;
using System.Collections;

public class GameoverScript : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
	    if (Input.anyKey)
        {
            Application.LoadLevel("Menu");
        }
	}
}