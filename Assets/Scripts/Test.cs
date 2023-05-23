using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            VFXCreator.Instance.CreateEffect(new Vector3(mousePos.x, mousePos.y, 0), VFXType.blood);
        }
        if(Input.GetMouseButtonDown(1))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            VFXCreator.Instance.CreateEffect(new Vector3(mousePos.x, mousePos.y, 0), VFXType.explosion);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            VFXCreator.Instance.CreateEffect(new Vector3(mousePos.x, mousePos.y, 0), VFXType.slash);
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            VFXCreator.Instance.CreateEffect(new Vector3(mousePos.x, mousePos.y, 0), VFXType.multislash);
        }
    }
}
