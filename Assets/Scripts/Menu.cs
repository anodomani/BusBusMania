using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Base Scene", LoadSceneMode.Single);
    }

    public void Reset()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
