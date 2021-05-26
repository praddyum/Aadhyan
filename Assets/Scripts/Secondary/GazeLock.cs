using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GazeLock : MonoBehaviour
{
    public bool isGazeLocked = false;
    public GameObject Lock, Unlock;

    [Header("Indicator")]
    [SerializeField]
    Gaze Gaze;
    [SerializeField]
    GameObject IndicatorContainer;
    [SerializeField]
    Animator GpsAnimator;
    [SerializeField]
    float rotTime = 0.5f;
    [SerializeField]
    Transform Gps;
    [SerializeField]
    Vector3 Init, MoveTo,rot;

    public bool GpsRunning = false;
    public void ToggleStatus()
    {
        isGazeLocked = !isGazeLocked;
        Status(isGazeLocked);
    }

    public void Status(bool b)
    {
        Lock.SetActive(b);
        Unlock.SetActive(!b);
    }

    public void StartWait(Vector3 pos)
    {
        CancelInvoke();
        IndicatorContainer.SetActive(true);
        IndicatorContainer.transform.localPosition = pos;
        Gps.localPosition = Init;

        if (!GpsRunning)
        {
            GpsAnimator.SetTrigger(AnimationTags.GPS_ROTATE_START);
        }

        GpsRunning = true;
        Invoke(nameof(WaitDone), 2f);
    }

    public void WaitDone()
    {
        ToggleStatus();
        GpsAnimator.ResetTrigger(AnimationTags.GPS_ROTATE_START);
        GpsAnimator.SetTrigger(AnimationTags.GPS_ROTATE_STOP);
        GpsRunning = false;
        Gps.DOLocalMove(MoveTo, 0.5f);
        StartCoroutine(ShowData());
    }

    IEnumerator ShowData()
    {
        yield return new WaitForSeconds(0.8f);
        Gaze.DisplayStateName();
        Reset();
    }

    public void Reset()
    {
        CancelInvoke();
        IndicatorContainer.SetActive(false);
    }
}
