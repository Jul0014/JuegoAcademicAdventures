using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyPooling : MonoBehaviour
{
    public GameObject prefab;
	public int amount = 10;
	public int instantiateGap = 5;

    // Start is called before the first frame update
    void Start()
    {
        InitializePool();
		InvokeRepeating("GetEnemyFromPool", 1f, instantiateGap);
    }

	private void InitializePool() 
	{
		for (int i = 0; i < amount; i++) {
			AddEnemyToPool();
		}
	}

	private void AddEnemyToPool()
	{
		GameObject enemy = Instantiate(prefab, this.transform.position, Quaternion.identity, this.transform);
		enemy.SetActive(false);
	}

	private GameObject GetEnemyFromPool(){
		GameObject enemy = null;

		for (int i = 0; i < transform.childCount; i++)
		{
			if (!transform.GetChild(i).gameObject.activeSelf)
			{
				enemy = transform.GetChild(i).gameObject;
				enemy.transform.position = this.transform.position;
				enemy.transform.position = this.transform.position;
				enemy.SetActive(true);
				break;
			}
		}
		
		return enemy;
	}
}
