using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu]
public class WeaponDatabase : ScriptableObject
{
    public Weapon[] weaponList;
    public int WeaponCount{
        get {
            return weaponList.Length;
        }
    }

    public Weapon GetWeapon(int index){
        return weaponList[index];
    }

}
