using UnityEngine;
using System.Collections;

public class Cleanup : MonoBehaviour
{
    public float destroyTime;

	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, destroyTime);
	}
}
