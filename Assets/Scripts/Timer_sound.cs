using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_sound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SoundTimer", 176f);
    }

    void SoundTimer()
    {
        FindObjectOfType<AudioManager>().Play("timer");
    }
}
