using UnityEngine;
using System.Collections;

public class Chimney : MonoBehaviour
{
    public GameObject particle;
    private bool presented = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collider");

        if (other.tag == "present" && !presented)
        {
            Destroy(other.gameObject);
            particle.SetActive(true);
            presented = true;
        }
    }
}