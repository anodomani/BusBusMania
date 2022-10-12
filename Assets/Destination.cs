using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public Vector2 scaleBounds = new Vector2(4, 20);
    Vector2 baseScale, targetScale;

    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        targetScale = baseScale;
        if(Camera.main.orthographicSize > targetScale.x && Camera.main.orthographicSize/30 < targetScale.y){
            targetScale = targetScale * (Camera.main.orthographicSize/30);
        }
        transform.localScale = targetScale;
    }
}
