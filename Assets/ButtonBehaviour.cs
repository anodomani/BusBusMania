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

    public void RecenterCameraDestination(){
        cameraBehaviour.transform.position = new Vector3(GameManager.instance.destination.transform.position.x, GameManager.instance.destination.transform.position.y, Camera.main.transform.position.z);
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
