using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBehaviour : MonoBehaviour
{
    UIManager UM;
    Vector2 baseScale;
    Vector2 targetScale;
    public BusRouteBehaviour parentRoute;
    PlayerBehaviour playerBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        UM = UIManager.instance;
        playerBehaviour = GameManager.instance.player.GetComponent<PlayerBehaviour>();
        parentRoute = GetComponentInParent<BusRouteBehaviour>();
        baseScale = transform.localScale;
        targetScale = baseScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector2.Lerp(transform.localScale, targetScale, 0.5f);
    }

    void OnMouseEnter(){
        if(GameManager.instance.selectedEntity == GameManager.instance.player){
            playerBehaviour.currentTarget = this.gameObject;
        }
        targetScale = baseScale * 1.25f;
        UM.toolTips.Add(parentRoute.stopID);
    }

    void OnMouseOver(){
        //print("onMouseStay");
        
    }

    void OnMouseExit(){
        if(GameManager.instance.selectedEntity == GameManager.instance.player && playerBehaviour.currentTarget == this.gameObject){
            playerBehaviour.currentTarget = null;
        }
        targetScale = baseScale;
        UM.toolTips.Remove(parentRoute.stopID);
    }
}
