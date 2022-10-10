using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBehaviour : MonoBehaviour
{
    Vector2 baseScale;
    Vector2 targetScale;
    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
        targetScale = baseScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector2.Lerp(transform.localScale, targetScale, 0.5f);
    }

    void OnMouseEnter(){
        targetScale = baseScale * 1.25f;
    }

    void OnMouseExit(){
        targetScale = baseScale;
    }
}
