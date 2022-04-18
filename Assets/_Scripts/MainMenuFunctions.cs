using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
    public GameObject menu;
    public GameObject option;
    public AudioSource clickSound;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        option.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPressed()
    {
        clickSound.Play();
        SceneManager.LoadScene("SampleScene");
    }

    public void OptionPressed()
    {
        clickSound.Play();

        menu.SetActive(false);
        option.SetActive(true);
    }

    public void BackPressed()
    {
        clickSound.Play();

        menu.SetActive(true);
        option.SetActive(false);
    }

    public void QuitPressed()
    {
        clickSound.Play();

        Application.Quit();
    }    
}
