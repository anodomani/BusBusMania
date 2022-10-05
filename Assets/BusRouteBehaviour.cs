using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusRouteBehaviour : MonoBehaviour
{
    GameManager GM;
    LineRenderer lineRenderer;
    public List<Transform> stopsOnRoute;
    public List<Transform> nodesOnRoute;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.instance;
        lineRenderer = GetComponent<LineRenderer>();
        //set line
        for (int i = 0; i < transform.childCount; i++){
            nodesOnRoute.Add(transform.GetChild(i));
            if(transform.GetChild(i).tag == "Stop"){
                stopsOnRoute.Add(transform.GetChild(i));
            }
        }
        lineRenderer.positionCount = nodesOnRoute.Count + 1;
        GameObject newBus = Instantiate(GM.bus, GM.transform);
        newBus.GetComponent<BusBehaviour>().busRouteBehaviour = this;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < nodesOnRoute.Count; i++){
            lineRenderer.SetPosition(i, nodesOnRoute[i].position);
        }
        lineRenderer.SetPosition(nodesOnRoute.Count, nodesOnRoute[0].position);
    }
}
