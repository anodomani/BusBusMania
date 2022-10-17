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
    public GameObject destination;
    public Bounds destinationBounds;
    public GameObject destinationsContainer;
    public List<Transform> destinations;
    private float startTime = 180f;
    [SerializeField] TMP_Text timerText;
    public int score;

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
        /*
        for(int i = 0; i < destinationsContainer.transform.childCount; i++){
            print(i + ", " + destinationsContainer);
            destinations.Add(transform.GetChild(i));
        }
        */
        RandomizeDestination();
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
            SceneManager.LoadScene("LosePC", LoadSceneMode.Single);
        }
        if(score > 5){
            SceneManager.LoadScene("WinPC", LoadSceneMode.Single);
        }
        if(Input.GetMouseButtonDown(0)){
            Collider2D[] hit  = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if(hit.Length > 0){
                AudioManager.Instance.Play("click");
                foreach(Collider2D i in hit){
                    print("hitting " + i.gameObject.name); 
                    if(i != null && i.gameObject != selectedEntity){
                        if(onUnselect != null){onUnselect();}
                        selectedEntity = i.gameObject;
                        if(onSelect != null){onSelect();}
                        if(i.gameObject == player){
                            break;
                        }
                    }
                }
            }
            else{
                if(onUnselect != null){onUnselect();}
                selectedEntity = this.gameObject;
            }
        }
        if(Vector2.Distance(player.transform.position, destination.transform.position) < 2.5f){
            AudioManager.Instance.Play("success");
            score++;
            RandomizeDestination();
        }
    }
    
    public void RandomizeDestination(){
        destination = destinations[Random.Range(0, destinations.Count)].gameObject;
        /*
        destination.transform.position = new Vector2(Random.Range(destinationBounds.min.x, destinationBounds.max.x), Random.Range(destinationBounds.min.y, destinationBounds.max.y));
        while(Vector2.Distance(player.transform.position, destination.transform.position) < 4){
            destination.transform.position = new Vector2(Random.Range(destinationBounds.min.x, destinationBounds.max.x), Random.Range(destinationBounds.min.y, destinationBounds.max.y));
        }
        */
    }
}
