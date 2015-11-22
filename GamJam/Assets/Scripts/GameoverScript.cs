using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameoverScript : MonoBehaviour
{
	public GameObject highscore;
	public GameObject yourscore;
	public GameObject congrats;

	void Start(){
		congrats.SetActive (false);
		highscore.GetComponent<Text> ().text = "Highscore: \n" + PlayerPrefs.GetInt ("Highscore");
		yourscore.GetComponent<Text> ().text = "Your Score: \n" + PlayerPrefs.GetInt ("Lastscore");
		if (PlayerPrefs.GetInt ("Lastscore") == PlayerPrefs.GetInt ("Highscore"))
			congrats.SetActive (true);
	}

	// Update is called once per frame
	void Update ()
    {
	    if (Input.anyKey)
        {
            Application.LoadLevel("Menu");
        }
	}
}