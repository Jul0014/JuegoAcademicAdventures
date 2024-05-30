using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class WeaponUIManager : MonoBehaviour
{
    public WeaponDatabase weaponDB;
    public TextMeshProUGUI weaponText;
    public TextMeshProUGUI weaponTextDescription;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOptionW")){
            selectedOption = 0;
        } else {
            Load();
        }
        UpdateWeapon(selectedOption);
    }

    public void NextOption(){
        selectedOption++;

        if (selectedOption >= weaponDB.WeaponCount){
            selectedOption = 0;
        }

        UpdateWeapon(selectedOption);
        Save();
    }

    public void BackOption(){
        selectedOption--;
        
        if (selectedOption < 0){
            selectedOption = weaponDB.WeaponCount - 1;
        }

        UpdateWeapon(selectedOption);
        Save();
    }

    private void UpdateWeapon(int selectedOption){
        Weapon weapon = weaponDB.GetWeapon(selectedOption);
        artworkSprite.sprite = weapon.weaponSprite;
        weaponText.text = weapon.weaponName;
        weaponTextDescription.text =  weapon.weaponDescription;
    }
    
    private void Load(){
        selectedOption = PlayerPrefs.GetInt("selectedOptionW");
    }

    private void Save(){
        PlayerPrefs.SetInt("selectedOptionW", selectedOption);
    }

    public void ChangeScene(int sceneID){
        SceneManager.LoadScene(sceneID);
    }
}
