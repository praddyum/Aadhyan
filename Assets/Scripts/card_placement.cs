using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class card_placement : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;  //The placement marker
    public GameObject scroll;
    public GameObject explore;
    public GameObject back;
    public GameObject backprev;
    public GameObject description;
    public GameObject[] objects;
    public GameObject[] animals;
    private card_placement positionIndicator;
    private int a=0;
    private int marker_spawned=0;
    private GameObject obj1;
    private GameObject obj2;
    void Start()
    {
        // get the components
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        // hide the scroll visual
        visual.SetActive(false);

        //hide scroll visual
        scroll.SetActive(false);
        explore.SetActive(false);
        back.SetActive(false);

        positionIndicator = FindObjectOfType<card_placement>();
        
    }

     void Update()
    {
        // shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        //if we hit an AR plane then update the position and rotation
        if(hits.Count > 0)
        {   description.SetActive(false);
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!visual.activeInHierarchy && a==0)
                visual.SetActive(true);
                marker_spawned=1;

        }
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && a==0 && marker_spawned==1){
                obj1 = Instantiate(objects[0], positionIndicator.transform.position, positionIndicator.transform.rotation);
                a=1;
                visual.SetActive(false);
                scroll.SetActive(true);
                explore.SetActive(true);
            }
    }

    public void card_change(int new_pos,int old_pos){
        obj2 = Instantiate(objects[new_pos], obj1.transform.position, obj1.transform.rotation);
        Destroy(obj1);
        obj1=obj2;
    }
    
    public void cardtoanimal(int new_pos){
        scroll.SetActive(false);
        explore.SetActive(false);
        back.SetActive(true);
        obj2 = Instantiate(animals[new_pos], obj1.transform.position, animals[new_pos].transform.rotation);
        Destroy(obj1);
        obj1=obj2;
        backprev.SetActive(false);
    }

    public void animaltocard(int new_pos){
        scroll.SetActive(true);
        backprev.SetActive(true);
        explore.SetActive(true);
        back.SetActive(false);
        obj2 = Instantiate(objects[new_pos], obj1.transform.position, objects[new_pos].transform.rotation);
        Destroy(obj1);
        obj1=obj2;
    }

}
