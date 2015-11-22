using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int totalScore; //Score of presents + Max distance gone 
	public int numPresents = 0; //Score of presents
	float maxDistance; //Max distance gone


	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Menu");
        }
    }

	void FixedUpdate () {
		if (transform.position.x > maxDistance) {
			maxDistance = transform.position.x;
		}

		totalScore = numPresents*100 + (int)maxDistance*20;
	}

    public void StartGameOver()
    {
        GetComponent<Grayscale>().enabled = true;
        Time.timeScale = 0.5f;

        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 1f;
        GetComponent<Grayscale>().enabled = false;
        Application.LoadLevel("GameOver");
    }
}
