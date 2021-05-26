using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DataViewer : MonoBehaviour
{
    [SerializeField]
    CanvasGroup StateNameCV;
    [SerializeField]
    TMP_Text StateNameTF;
    public bool isExpanded = false;

    [SerializeField]
    StatesData Current;

    [SerializeField]
    CanvasGroup FullBGCV, ArrowCV, MoreInfoCV;
    [SerializeField]
    RectTransform NameRT;
    [SerializeField]
    Vector2 NameInit, NameMoveTo;
    private void Start()
    {
        CollapseData();
        StateNameCV.alpha = 0f;
    }
    public void ShowName(StatesData data, Vector3 pos)
    {
        CollapseData();
        Current = data;
        
        StateNameCV.alpha = 1f;
        StateNameCV.blocksRaycasts = true;
       
        transform.position = pos;
        StateNameTF.text = Current.StateName;
    }

    public void ToggleStatus()
    {
        if (isExpanded)
        {
            CollapseData();
        }
        else
        {
            ShowMoreData();
        }
    }

    public void CollapseData()
    {
        isExpanded = false;
        MoreInfoCV.DOFade(0f, 0.3f);
        FullBGCV.DOFade(0f, 0.3f);
        ArrowCV.DOFade(1f, 0.3f);
        NameRT.DOAnchorPos(NameInit, 0.3f);
    }

    public void ShowMoreData()
    {
        isExpanded = true;
        MoreInfoCV.DOFade(1f, 0.3f);
        FullBGCV.DOFade(1f, 0.3f);
        ArrowCV.DOFade(0f, 0.3f);
        NameRT.DOAnchorPos(NameMoveTo, 0.3f);
    }

    public void Reset()
    {
        StateNameTF.text = "";
        CollapseData();
        
        StateNameCV.alpha = 0f;
        StateNameCV.blocksRaycasts = false;
    }
}
