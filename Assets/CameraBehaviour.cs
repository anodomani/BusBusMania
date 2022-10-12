using UnityEngine;
using System.Collections;
 
public class CameraBehaviour : MonoBehaviour
{
    public int cameraDragSpeed = 200;
 
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            float speed = cameraDragSpeed * Time.deltaTime;
            Camera.main.transform.position -= new Vector3(Input.GetAxis("Mouse X") * speed, Input.GetAxis("Mouse Y") * speed, 0);
        }
    }
}