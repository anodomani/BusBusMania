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
    public GameObject inside;
    public GameObject currentTarget;

    Vector2 baseScale, targetScale;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.instance;
        lineRenderer = GetComponent<LineRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GM.onUnselect += Unselect;
        targetPosition = transform.position;
        baseScale = transform.localScale;
        targetScale = baseScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(inside != null){targetScale = baseScale * 0.8f;} else{targetScale = baseScale;}
        transform.localScale = Vector2.Lerp(transform.localScale, targetScale, 0.5f);
        if(currentTarget != null){
            if(Vector2.Distance(transform.position, currentTarget.transform.position) < 1){
                inside = currentTarget;
                currentTarget = null;
            }
        }
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
        if(GM.selectedEntity == this.gameObject){
            //transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            inside = null;
            lineRenderer.SetPosition(1, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
            spriteRenderer.sprite = heldSprite;
        } else{
            lineRenderer.SetPosition(1, targetPosition);
            spriteRenderer.sprite = baseSprite;
        }
        if(inside != null){
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position);
            transform.position = inside.transform.position + new Vector3(0, 1, 0);
        }
    }

    void FixedUpdate(){
        //move towards target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);
    }
    
    public void Unselect(){
        if(GM.selectedEntity == this.gameObject){
            AudioManager.Instance.Play("pickup");
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        }
    }
}
