using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    GameManager GM;
    LineRenderer lineRenderer;
    public Vector2 targetPosition;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.instance;
        lineRenderer = GetComponent<LineRenderer>();
        GM.onUnselect += Unselect;
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
        if(GM.selectedEntity == this.gameObject){
            
            //transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            lineRenderer.SetPosition(1, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
        } else{
            lineRenderer.SetPosition(1, targetPosition);
        }
    }

    void FixedUpdate(){
        //move towards target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);
    }
    
    public void Unselect(){
        if(GM.selectedEntity == this.gameObject){
            FindObjectOfType<AudioManager>().Play("pickup");
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        }
    }
}
