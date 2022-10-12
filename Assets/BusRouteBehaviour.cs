using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusRouteBehaviour : MonoBehaviour
{
    GameManager GM;
    LineRenderer lineRenderer;
    public List<Transform> stopsOnRoute;
    public List<Transform> nodesOnRoute;
    public string stopID;
    public Color routeColor;
    public int busesOnRoute = 1;
    float baseScale, targetScale;
    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.instance;
        lineRenderer = GetComponent<LineRenderer>();
        stopsOnRoute = new List<Transform>();
        nodesOnRoute = new List<Transform>();
        //set line
        for (int i = 0; i < transform.childCount; i++){
            nodesOnRoute.Add(transform.GetChild(i));
            if(transform.GetChild(i).tag == "Stop"){
                stopsOnRoute.Add(transform.GetChild(i));
            }
        }
        lineRenderer.startColor = routeColor;
        lineRenderer.endColor = routeColor;
        lineRenderer.positionCount = nodesOnRoute.Count + 1;
        
        for(int i = 0; i < busesOnRoute; i++){
            GameObject newBus = Instantiate(GM.bus, GM.transform);
            newBus.GetComponent<BusBehaviour>().currentTargetIndex = (int)(1);
            newBus.GetComponent<SpriteRenderer>().color = routeColor;
            newBus.GetComponent<BusBehaviour>().busRouteBehaviour = this;
        }
        
        for(int i = 0; i < nodesOnRoute.Count; i++){
            lineRenderer.SetPosition(i, nodesOnRoute[i].position);
        }
        lineRenderer.SetPosition(nodesOnRoute.Count, nodesOnRoute[0].position);

        baseScale = lineRenderer.startWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if(stopsOnRoute.Contains(GameManager.instance.selectedEntity.transform)){
            targetScale = baseScale * 2;
        }else{
            targetScale = baseScale;
        }
        lineRenderer.startWidth = Mathf.Lerp(lineRenderer.startWidth, targetScale, 0.5f);
        lineRenderer.endWidth = Mathf.Lerp(lineRenderer.endWidth, targetScale, 0.5f);
    }

    void OnDrawGizmos(){
        nodesOnRoute = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++){
            nodesOnRoute.Add(transform.GetChild(i));
        }
        Gizmos.color = routeColor;
        for(int i = 0; i < nodesOnRoute.Count - 1; i++){
            Gizmos.DrawLine(nodesOnRoute[i].position, nodesOnRoute[i+1].position);
        }
    }
}
