using UnityEngine;
using System.Collections;

public class Chimney : MonoBehaviour
{
    public GameObject particle;
    private bool presented = false;
	public GameManager gameScript;

	void Start(){
		gameScript = Camera.main.GetComponent<GameManager>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "present" && !presented)
        {
            Destroy(other.gameObject);
            particle.SetActive(true);
            presented = true;
			gameScript.numPresents++;
        }
    }
}