using UnityEngine;
using System.Collections;

public class Chimney : MonoBehaviour
{
    public GameObject particle;
    private bool presented = false;
	public GameObject gameScript;

	void Start(){
		gameScript = GameObject.FindGameObjectsWithTag ("Body");
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collider");

        if (other.tag == "present" && !presented)
        {
            Destroy(other.gameObject);
            particle.SetActive(true);
            presented = true;
			gameScript.GetComponent<GameManager>().numPresents++;
        }
    }
}