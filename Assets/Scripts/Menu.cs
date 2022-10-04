using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string level;
    public void PlayGame()
    {
        SceneManager.LoadScene(level);
    }
}
