using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameoverScript : MonoBehaviour
{
	public GameObject highscore;
	public GameObject yourscore;
	public GameObject congrats;

	void Start()
    {
        GetComponent<AudioSource>().PlayDelayed(3);
		congrats.SetActive (false);
		highscore.GetComponent<Text> ().text = "Highscore: \n" + PlayerPrefs.GetInt ("HighScore");
		yourscore.GetComponent<Text> ().text = "Your Score: \n" + PlayerPrefs.GetInt ("LastScore");
		if (PlayerPrefs.GetInt ("LastScore") == PlayerPrefs.GetInt ("HighScore"))
			congrats.SetActive (true);
        PlayerPrefs.Save();
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