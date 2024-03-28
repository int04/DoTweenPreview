using System;
using System.Collections;
using System.Collections.Generic;
using script;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MainController : MonoBehaviour
{
    private List<ChildControllers> _list = new List<ChildControllers>();
    [SerializeField] private ChildControllers childControllers;

    private float _time = 1f;

    void Awake()
    {
        childControllers.gameObject.SetActive(false);
    }
    void Start()
    {
        UpdateChild();
    }

    // <summary>
    // because WebGL dont support Enum.GetValues(typeof(Ease)), so i have to create a list of Ease
    // </summary>
    private Ease[] _easeArray = new Ease[]
    {
        Ease.Unset,
        Ease.Linear,
        Ease.InSine,
        Ease.OutSine,
        Ease.InOutSine,
        Ease.InQuad,
        Ease.OutQuad,
        Ease.InOutQuad,
        Ease.InCubic,
        Ease.OutCubic,
        Ease.InOutCubic,
        Ease.InQuart,
        Ease.OutQuart,
        Ease.InOutQuart,
        Ease.InQuint,
        Ease.OutQuint,
        Ease.InOutQuint,
        Ease.InExpo,
        Ease.OutExpo,
        Ease.InOutExpo,
        Ease.InCirc,
        Ease.OutCirc,
        Ease.InOutCirc,
        Ease.InElastic,
        Ease.OutElastic,
        Ease.InOutElastic,
        Ease.InBack,
        Ease.OutBack,
        Ease.InOutBack,
        Ease.InBounce,
        Ease.OutBounce,
        Ease.InOutBounce,
        Ease.Flash,
        Ease.InFlash,
        Ease.OutFlash,
        Ease.InOutFlash,
        Ease.INTERNAL_Zero,
        Ease.INTERNAL_Custom
    };

    public void UpdateChild()
    {
        //foreach(Ease t in  Enum.GetValues(typeof(Ease))) // using for edtior or app, dont support webGL :d
        foreach (Ease t in _easeArray)
        {
            var child = Instantiate(childControllers, childControllers.transform.parent);
            child.UpdateTime(_time);
            child.UpdateEase(t);
            child.Run(t);
            child.gameObject.SetActive(true);
            _list.Add(child);
        }

    }

    // <summary>
    // the form update
    // </summary>
    [SerializeField] private TMP_InputField inputTime;

    public void UpdateTime()
    {
        _time = float.Parse(inputTime.text);
        foreach (var child in _list)
        {
            Destroy(child.gameObject);
        }
        _list.Clear();
        UpdateChild();
    }
}
