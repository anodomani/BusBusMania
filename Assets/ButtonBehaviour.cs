using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    CameraBehaviour cameraBehaviour;

    public void Start(){
        cameraBehaviour = Camera.main.GetComponent<CameraBehaviour>();
    }
    public void RecenterCamera(){
        cameraBehaviour.followPlayer = true;
    }

    public void ExitVehicle(){
        GameManager.instance.player.GetComponent<PlayerBehaviour>().inside = null;
    }
    public void ZoomIn(){
        Camera.main.orthographicSize += 1;
    }
    public void ZoomOut(){
        Camera.main.orthographicSize -= 1;
    }
}
