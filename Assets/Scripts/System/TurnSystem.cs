using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TurnSystem : MonoBehaviour
{
    [SerializeField] private int nexSceneIndex = 1;
    public int roundNumber = 0;
    public static TurnSystem Instance;
    public Action onTurnChanged;
    public List<ActionHandler> characters;
    public ActionHandler currentCharacter;
    public Action<int> onRoundChanged;
    public Action onActionPOintChange;
    private int index;
    public Skill[] CharacterSkills => currentCharacter.GetSkills();
    


    private void LoadNextScene()
    {
        SceneManager.LoadScene(nexSceneIndex);
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        ActionHandler.onDead = CharacterDie;
    }
    private void NextRound()
    {
        ++roundNumber;
        onRoundChanged?.Invoke(roundNumber);
    }
    public void StartFight()
    {
        //this is start of the fight... so maybe another method and triggers to start fight?
        NextRound();
        characters.AddRange(FindObjectsOfType<ActionHandler>());
        currentCharacter = characters[index];
        currentCharacter.CharacterActive(true);
        currentCharacter.onTurnEnd = EndTurn;
        currentCharacter.onActionPointsChange = TurnCheck;
        onTurnChanged?.Invoke();
    }
    public void EndTurn()
    {
        StartCoroutine(NextCharacter());
    }

    private IEnumerator NextCharacter()
    {
        yield return new WaitForSeconds(1f);
        currentCharacter.onTurnEnd = null;
        currentCharacter.CharacterActive(false);
        if(!UpdateIndex()) 
        {
            LoadNextScene();
            yield break;
        }
        currentCharacter = characters[index];
        currentCharacter.CharacterActive(true);
        currentCharacter.onActionPointsChange = TurnCheck;
        currentCharacter.onTurnEnd = EndTurn;
        onTurnChanged?.Invoke();
        //NextRound();
    }

    private bool UpdateIndex()
    {
        //test!!!!!
        if(characters.Count == 1)
        {
            index = 0;
            return false;
        }


        if(index + 1 < characters.Count)
        {
            index++;
        }
        else
        {
            index = 0;
            NextRound();
        }
        return true;
    }
    //check if combat is finished
    private void TurnCheck()
    {
        onActionPOintChange?.Invoke();
        //is player dead?

        //test
        
    }
    private void CharacterDie(ActionHandler diedCharacter)
    {
        Debug.Log("character deleted");
        characters.Remove(diedCharacter);
        Destroy(diedCharacter.gameObject);
    }
}
