using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject target;
    public GameObject mountains;

    public GameObject[] topObstacles;
    public GameObject[] botObstacles;

    public float topFrequency;
    public float topVariance;
    public float botFrequency;
    public float botVariance;

    public float xOffset;
    public float topMaxY;
    public float topMinY;
    public float botY;

    private float topDistance = 0;
    private float botDistance = 0;
    private float startLoc;
    private float furthestLoc;
    private float previousLoc;

    private float nextTopDist;
    private float nextBotDist;

    void Start()
    {
        startLoc = target.transform.position.x;
        furthestLoc = startLoc;
        previousLoc = startLoc;
        nextTopDist = findNextDist(topFrequency, topVariance);
        nextBotDist = findNextDist(botFrequency, botVariance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mountains != null)
        {
            mountains.GetComponent<Image>().material.mainTextureOffset = new Vector2((float)mountains.GetComponent<Image>().material.mainTextureOffset.x + (((float)target.transform.position.x - (float)previousLoc)/100f), (float)mountains.GetComponent<Image>().material.mainTextureOffset.y);
            previousLoc = target.transform.position.x;
        }

	    if (target.transform.position.x > furthestLoc)
        {
            topDistance += target.transform.position.x - furthestLoc;
            botDistance += target.transform.position.x - furthestLoc;

            if (topObstacles.Length > 0 && topDistance > nextTopDist)
            {
                topDistance -= nextTopDist;
                Instantiate(topObstacles[Random.Range(0, topObstacles.Length)], new Vector3(target.transform.position.x + xOffset, Random.Range(topMinY, topMaxY), -2), Quaternion.identity);
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
