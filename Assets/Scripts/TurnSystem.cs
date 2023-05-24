using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public ActionHandler[] characters;
    private ActionHandler currentCharacter;
    private int index;
    void Start()
    {
        //this is start of the fight... so maybe another method and triggers to start fight?
        
        characters = FindObjectsOfType<ActionHandler>();
        currentCharacter = characters[index];
        currentCharacter.CharacterActive(true);
        currentCharacter.onTurnEnd = NextCharacter;
    }
    private void NextCharacter()
    {
        currentCharacter.onTurnEnd = null;
        currentCharacter.CharacterActive(false);
        index = ++index < characters.Length ? index : 0;
        currentCharacter = characters[index];
        currentCharacter.CharacterActive(true);
        currentCharacter.onTurnEnd = NextCharacter;
    }
    
}
