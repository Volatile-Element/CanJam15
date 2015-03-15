using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
    public double score;

    System.DateTime holdingTime, theTimeSecond;

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

        if (holdingTime.CompareTo(theTimeSecond).ToString() == "1" || holdingTime.CompareTo(theTimeSecond).ToString() == "0")
        {
            score += 1;
            theTimeSecond = holdingTime.AddSeconds(1);
            Debug.Log(score);
        }
	
	}

	public void penalty()
	{
		score += 20;
		Debug.Log (score);
	}
}
