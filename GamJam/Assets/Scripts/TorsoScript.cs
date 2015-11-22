using UnityEngine;
using System.Collections;

public class TorsoScript : MonoBehaviour
{
    public GameObject gore;

	public void Pop()
    {
        Instantiate(gore, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);

        Camera.main.GetComponent<GameManager>().StartGameOver();
    }
}
