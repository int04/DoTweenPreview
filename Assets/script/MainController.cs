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

    public void UpdateChild()
    {
        foreach (Ease t in Enum.GetValues(typeof(Ease)))
        {
            var child = Instantiate(childControllers, childControllers.transform.parent);
            child.gameObject.SetActive(true);
            child.UpdateTime(_time);
            child.UpdateEase(t);
            child.Run();
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
