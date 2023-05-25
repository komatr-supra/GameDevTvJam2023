using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public static TurnSystem Instance;
    public Action onTurnChanged;
    public ActionHandler[] characters;
    public ActionHandler currentCharacter;
    private int index;
    public Skill[] CharacterSkills => currentCharacter.GetSkills();
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void StartFight()
    {
        //this is start of the fight... so maybe another method and triggers to start fight?
        
        characters = FindObjectsOfType<ActionHandler>();
        currentCharacter = characters[index];
        currentCharacter.CharacterActive(true);
        currentCharacter.onTurnEnd = NextCharacter;
        onTurnChanged?.Invoke();
    }
    private void NextCharacter()
    {
        currentCharacter.onTurnEnd = null;
        currentCharacter.CharacterActive(false);
        index = ++index < characters.Length ? index : 0;
        currentCharacter = characters[index];
        currentCharacter.CharacterActive(true);
        currentCharacter.onTurnEnd = NextCharacter;
        onTurnChanged?.Invoke();
    }
    
}
