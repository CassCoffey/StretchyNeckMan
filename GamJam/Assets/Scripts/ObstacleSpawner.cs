using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject target;

    public GameObject[] topObstacles;
    public GameObject[] botObstacles;

    public float topFrequency;
    public float topVariance;
    public float botFrequency;
    public float botVariance;

    public float xOffset;
    public float topY;
    public float botY;

    private float topDistance = 0;
    private float botDistance = 0;
    private float startLoc;
    private float furthestLoc;

    private float nextTopDist;
    private float nextBotDist;

    void Start()
    {
        startLoc = target.transform.position.x;
        furthestLoc = startLoc;
        nextTopDist = findNextDist(topFrequency, topVariance);
        nextBotDist = findNextDist(botFrequency, botVariance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
	    if (target.transform.position.x > furthestLoc)
        {
            topDistance += target.transform.position.x - furthestLoc;
            botDistance += target.transform.position.x - furthestLoc;

            if (topObstacles.Length > 0 && topDistance > nextTopDist)
            {
                topDistance -= nextTopDist;
                Instantiate(topObstacles[Random.Range(0, topObstacles.Length)], new Vector3(target.transform.position.x + xOffset, topY, -2), Quaternion.identity);
                nextTopDist = findNextDist(topFrequency, topVariance);
            }

            if (botObstacles.Length > 0 && botDistance > nextBotDist)
            {
                botDistance -= nextBotDist;
                Instantiate(botObstacles[Random.Range(0, botObstacles.Length)], new Vector3(target.transform.position.x + xOffset, botY, -2), Quaternion.identity);
                nextBotDist = findNextDist(botFrequency, botVariance);
            }

            furthestLoc = target.transform.position.x;
        }
	}

    private float findNextDist(float baseDis, float variance)
    {
        float var = Random.Range(-variance, variance);
        return baseDis + var;
    }
}
