using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public static GameManager instance;
    public GameObject selectedEntity;
    public event System.Action onSelect;
    public event System.Action onUnselect;
    public GameObject busStop;
    public GameObject bus;
    public Vector2 destination;
    public Vector2 destinationMin;
    public Vector2 destinationMax;
    private float startTime = 180f;
    [SerializeField] TMP_Text timerText;

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

        selectedEntity = this.gameObject;
    }

  

    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(startTime / 60);
        float seconds = Mathf.FloorToInt(startTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    
        if (startTime < 4f)
        {
            timerText.color = Color.red;
           
        }

        if (startTime <= 0)
        {
         
            SceneManager.LoadScene("Lose", LoadSceneMode.Single);
            //SceneManager.LoadScene("Win", LoadSceneMode.Single);

        }

        if (Input.GetMouseButtonDown(0)){
            Collider2D hit  = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if(hit != null){ print("hitting " + hit.gameObject.name); }
            if(hit != null && hit.gameObject != selectedEntity){
                if(onUnselect != null){onUnselect();}
                selectedEntity = hit.gameObject;
                if(onSelect != null){onSelect();}
            } else{
                if(onUnselect != null){onUnselect();}
                selectedEntity = this.gameObject;
            }
        }
        if(Vector2.Distance(player.transform.position, destination) < 0.5f){
            destination = new Vector2(Random.Range(destinationMin.x, destinationMax.x), Random.Range(destinationMin.x, destinationMax.x));
        }
        
    }
}
