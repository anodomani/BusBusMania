using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    GameManager GM;
    LineRenderer lineRenderer;
    SpriteRenderer spriteRenderer;
    public Vector2 targetPosition;
    public float moveSpeed;
    public Sprite baseSprite;
    public Sprite heldSprite;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.instance;
        lineRenderer = GetComponent<LineRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            spriteRenderer.sprite = heldSprite;
        } else{
            lineRenderer.SetPosition(1, targetPosition);
            spriteRenderer.sprite = baseSprite;
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
