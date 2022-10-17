using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    GameManager GM;
    public TMP_Text toolTip;
    public List<string> toolTips;
    public TMP_Text scoreDisplay;
    public GameObject destinationMarker;

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
        GM = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        destinationMarker.transform.position = GM.destination.transform.position;
        scoreDisplay.text = GM.score.ToString();
        toolTip.transform.position = Input.mousePosition;
        /*
        if(GM.selectedEntity != GM.gameObject){
            toolTip.transform.position = Camera.main.WorldToScreenPoint(GM.selectedEntity.transform.position);
        } else { toolTip.transform.position = Input.mousePosition; }
        */
        toolTip.text = "";
        foreach(string i in toolTips){
            toolTip.text += i;
        }
    }
}
