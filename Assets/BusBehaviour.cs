using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusBehaviour : MonoBehaviour
{
    public float moveSpeed;
    public float easedMovement;
    public BusRouteBehaviour busRouteBehaviour;
    public int currentTargetIndex;
    public Transform currentStop;
    public int layOverTime;
    public int maxLayOverTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTargetIndex = Random.Range(0, busRouteBehaviour.nodesOnRoute.Count-1);
        transform.position = busRouteBehaviour.nodesOnRoute[currentTargetIndex].transform.position;
    }

    void Update(){
        //easedMovement = EasingFunction.EaseInSine(moveSpeed * 0.5f, moveSpeed, Vector2.Distance(transform.position, currentStop.transform.position));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position == busRouteBehaviour.nodesOnRoute[currentTargetIndex].transform.position){

            if(busRouteBehaviour.stopsOnRoute.Contains(busRouteBehaviour.nodesOnRoute[currentTargetIndex])){
                currentStop = busRouteBehaviour.nodesOnRoute[currentTargetIndex];
                if(transform.position == currentStop.position){
                    if(layOverTime < 1){
                        if(Vector2.Distance(this.gameObject.transform.position, GameManager.instance.player.transform.position) < 1f){
                            print("picking up player ");
                            GameManager.instance.player.GetComponent<PlayerBehaviour>().inside = this.gameObject;
                        }
                        if(currentTargetIndex < busRouteBehaviour.nodesOnRoute.Count-1){
                            FindObjectOfType<AudioManager>().Play("bus_stop");
                            currentTargetIndex++;
                        }else{
                            currentTargetIndex = 0;
                        }
                    }else{
                        layOverTime--;
                    }
                }
            }else{
                if(currentTargetIndex < busRouteBehaviour.nodesOnRoute.Count-1){
                    currentTargetIndex++;
                }else{
                    currentTargetIndex = 0;
                }
            }
        } else{
            transform.position = Vector2.MoveTowards(transform.position, busRouteBehaviour.nodesOnRoute[currentTargetIndex].transform.position, moveSpeed);
            //transform.position = new Vector2(Mathf.SmoothStep(transform.position.x, currentStop.position.x, 0.5f), Mathf.SmoothStep(transform.position.y, currentStop.position.y, 1f));
            layOverTime = maxLayOverTime;
        }
        Vector2 direction = busRouteBehaviour.nodesOnRoute[currentTargetIndex].transform.position - transform.position;
        transform.up = direction;
    }
}
