using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Loot")]
    public List<LootItem> lootTable = new List<LootItem>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(){

        foreach (LootItem lootItem in lootTable){
            if (Random.Range(0f, 100f) <= lootItem.dropChange){
                InstantiateLoot(lootItem.itemPrebab);
            }
        }
        
        gameObject.SetActive(false);
    }

    void InstantiateLoot(GameObject loot){
        
        if (loot){
            Instantiate(loot, transform.position, UnityEngine.Quaternion.identity);
        }
    }
}
