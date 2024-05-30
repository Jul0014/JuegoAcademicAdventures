using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelected : MonoBehaviour
{
    public WeaponDatabase weaponDB;
    private int selectedOption = 0;
    private GameObject currentWeapon;

    void Start()
    {
        Load();
        UpdateWeapon(selectedOption);
    }

    private void UpdateWeapon(int selectedOption)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon); // Remove the current weapon
        }

        Weapon weapon = weaponDB.GetWeapon(selectedOption);
        if (weapon != null && weapon.gameWeapon != null)
        {
            currentWeapon = Instantiate(weapon.gameWeapon, transform.position, transform.rotation); // Instantiate the new weapon
            currentWeapon.transform.parent = transform; // Optional: parent the weapon to the player
        }

        string weaponName = weapon.weaponName;

        if (weaponName == "Lápiz          Azul"){
            currentWeapon.transform.position = new Vector3(currentWeapon.transform.position.x + 0.5f, currentWeapon.transform.position.y, currentWeapon.transform.position.z);
        }
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOptionW", 0); // Default to 0 if key doesn't exist
    }
}
