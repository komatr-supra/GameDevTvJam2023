using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionable
{
    void ExecuteAction(Action onFinished, bool right = true);
}
