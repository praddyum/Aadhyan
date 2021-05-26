using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaceContent : MonoBehaviour {

    [SerializeField]
    ARRaycastManager raycastManager;
    [SerializeField]
    ARPlaneManager ARPlaneManager;
    [SerializeField]
    GraphicRaycaster raycaster;
    [SerializeField]
    GameObject PointerObj,Content,LockIcon;

    public bool isDeveloper = false;
    public bool isActive = false;
    private void Start()
    {
        if (!isDeveloper)
        {
            PointerObj.SetActive(false);
            Content.SetActive(false);
            LockIcon.SetActive(false);
        }
    }
    private void Update() {

        if (isActive) return;
        
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        Pose pose = hits[0].pose;
        
        if (hits.Count > 0)
        {
            transform.position = pose.position;
            transform.rotation = pose.rotation;

            if (!PointerObj.activeInHierarchy)
                PointerObj.SetActive(true);

        }

        if (Input.GetMouseButtonDown(0) && !IsClickOverUI())
        {
            isActive = true;

            Content.SetActive(true);
            Content.transform.rotation = pose.rotation;
            Content.transform.position = pose.position;

            LockIcon.SetActive(true);

            PointerObj.SetActive(false);
            ARPlaneManager.enabled = false;
        }
    }

    bool IsClickOverUI() {
        PointerEventData data = new PointerEventData(EventSystem.current) {
            position = Input.mousePosition
        };
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(data, results);
        return results.Count > 0;
    }
}
