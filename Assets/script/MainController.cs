using System;
using System.Collections;
using System.Collections.Generic;
using script;
using UnityEngine;
using DG.Tweening;
public class MainController : MonoBehaviour
{
    private List<ChildControllers> _list = new List<ChildControllers>();

    [SerializeField] private ChildControllers childControllers;

    void Start()
    {
        
    }

    public void UpdateChild()
    {
        foreach (Ease t in Enum.GetValues(typeof(Ease)))
        {
            var child = Instantiate(childControllers, transform);
            child.UpdateEase(t);
            child.Run();
            _list.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
