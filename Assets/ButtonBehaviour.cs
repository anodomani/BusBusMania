using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public void RecenterCamera(){
        Camera.main.transform.position = new Vector3(GameManager.instance.player.transform.position.x, GameManager.instance.player.transform.position.y, Camera.main.transform.position.z);
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
