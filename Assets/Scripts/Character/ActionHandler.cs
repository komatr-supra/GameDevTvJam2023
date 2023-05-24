using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    //public is for test
    public IActionable[] actions;
    //test
    public IActionable selectedAction;
    private void Awake()
    {
        actions = GetComponents<IActionable>();
    }
    public void PerformAction(IActionable action, Action onComplete, bool right = true)
    {
        action.ExecuteAction(onComplete, right);
    }
    public IActionable GetMoveAction()
    {
        foreach (var item in actions)
        {
            if (item is Mover) return item;
        }
        return default;
    }
}
