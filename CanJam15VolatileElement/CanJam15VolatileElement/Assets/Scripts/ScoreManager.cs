using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
    public double score;

    System.DateTime holdingTime, theTimeSecond;
    bool updateScore = true;

	// Use this for initialization
	void Start () 
    {
        score = 0;

        holdingTime = System.DateTime.Now;
        theTimeSecond = holdingTime.AddSeconds(1);
	}
	
	// Update is called once per frame
	void Update () 
    {
        holdingTime = System.DateTime.Now;

        if (holdingTime.CompareTo(theTimeSecond).ToString() == "1" && updateScore|| holdingTime.CompareTo(theTimeSecond).ToString() == "0" && updateScore)
        {
            score += 1;
            theTimeSecond = holdingTime.AddSeconds(1);
        }
	
	}

    public void stopScore()
    {
        updateScore = false;
    }

    public void startScore()
    {
        updateScore = true;
    }

	public void penalty()
	{

	}
}
