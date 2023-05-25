using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action onFightStart;
    void Start()
    {
        //test wait for 1 sec to start fight
        StartCoroutine(Delay());
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        TurnSystem.Instance.StartFight();
    }
    
}
