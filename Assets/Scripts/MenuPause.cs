using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPause;
    [SerializeField] private AudioSource backgroundMusic;

    private float originalVolume;
    private void Start()
    {
        if (backgroundMusic != null)
        {
            originalVolume = backgroundMusic.volume; 
        }
    }
    public void Pausa()
    {
        Time.timeScale = 0f;
        buttonPause.SetActive(false);
        menuPause.SetActive(true);

    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
    }
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }

    public void ApagarAudio()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = 0f;
        }
    }

    public void RestaurarAudio()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = originalVolume;
        }
    }
}