using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollect : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentGems;
    public GemCounter gemCounter;
    void Start()
    {
        currentGems = 0;
		gemCounter.SetGems(currentGems);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ByObject(int price)
	{
		currentGems -= price;
		gemCounter.SetGems(currentGems);
	}

    public void AddGem(int value)
	{
		currentGems += value;
		gemCounter.SetGems(currentGems);
	}
}
