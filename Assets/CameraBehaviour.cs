using UnityEngine;
using System.Collections;
 
public class CameraBehaviour : MonoBehaviour
{
    public int cameraDragSpeed = 200;
    public int cameraZoomScrollSpeed = 10;
    public bool followPlayer;
    public float cameraZoomMin, cameraZoomMax;
 
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            followPlayer = false;
            float speed = cameraDragSpeed * Time.deltaTime;
            //if(GameManager.instance.destinationBounds.Contains(Camera.main.transform.position - new Vector3(Input.GetAxis("Mouse X") * speed, Input.GetAxis("Mouse Y") * speed * Time.deltaTime, 0))){}
            Camera.main.transform.position -= new Vector3(Input.GetAxis("Mouse X") * speed * (Camera.main.orthographicSize/20), Input.GetAxis("Mouse Y") * speed * (Camera.main.orthographicSize/20), 0);   
        }
        if(followPlayer == true){
            Camera.main.transform.position = Vector3.Lerp(transform.position, new Vector3(GameManager.instance.player.transform.position.x, GameManager.instance.player.transform.position.y), 0.1f);
        }
        if((Camera.main.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * cameraZoomScrollSpeed) > cameraZoomMin && (Camera.main.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * cameraZoomScrollSpeed) < cameraZoomMax){
            Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * cameraZoomScrollSpeed;
        }
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -10);
    }
}