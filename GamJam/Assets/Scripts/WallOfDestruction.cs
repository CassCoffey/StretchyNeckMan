using UnityEngine;
using System.Collections;

public class WallOfDestruction : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject.name == "Body")
        {
            Camera.main.GetComponent<GameManager>().StartGameOver();
        }
        Destroy(collision.gameObject);
    }
}
