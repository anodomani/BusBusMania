using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject selectedEntity;
    public event System.Action onSelect;
    public event System.Action onUnselect;
    public GameObject busStop;
    public GameObject bus;

    void Awake(){
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Collider2D hit  = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if(hit != null){ print("hitting " + hit.gameObject.name); }
            if(hit != null && hit.gameObject != selectedEntity){
                if(onUnselect != null){onUnselect();}
                selectedEntity = hit.gameObject;
                if(onSelect != null){onSelect();}
            } else{
                if(onUnselect != null){onUnselect();}
                selectedEntity = null;
            }
        }
    }
}
