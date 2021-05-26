using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Gaze : MonoBehaviour
{
    [SerializeField]
    StatesData Current,FocusedState;
    [SerializeField]
    GazeLock Lock;
    [SerializeField]
    DataViewer Viewer;

    [SerializeField]
    Material Default, Focused,Selected;
    private void Update()
    {
        if (Lock.isGazeLocked) return;
        
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag(Tags.STATE_TAG))
            {
                OpenInfo(go.GetComponent<StatesData>());
            }
        }
        else
        {
            CloseAll();
        }
    }

    void OpenInfo(StatesData data)
    {
        if (FocusedState == data) return;

        if (FocusedState != null && Current!=FocusedState)
        {
            FocusedState.gameObject.GetComponent<MeshRenderer>().material = Default;
        }
        
        FocusedState = data;
        FocusedState.gameObject.GetComponent<MeshRenderer>().material = Focused;
        Lock.StartWait(data.transform.localPosition);
    }

    void ResetCurrent()
    {
        if (Current != null)
        {
            Current.gameObject.GetComponent<MeshRenderer>().material = Default;
        }
        Current = FocusedState;
        if (Current != null)
        {
            Current.gameObject.GetComponent<MeshRenderer>().material = Selected;
        }
    }

    public void DisplayStateName()
    {
        ResetCurrent();
        Viewer.ShowName(Current, Current.transform.position);
    }

    void CloseAll()
    {
        Lock.Reset();
        Viewer.Reset();

        if (Current != null)
        {
            Current.gameObject.GetComponent<MeshRenderer>().material = Default;
            Current = null;
        }
        if(FocusedState != null)
        {
            FocusedState.gameObject.GetComponent<MeshRenderer>().material = Default;
            FocusedState = null;
        }
    }
}
