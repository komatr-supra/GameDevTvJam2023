using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonCreator : MonoBehaviour
{
    [SerializeField] private GameObject skillPrefab;
    private void Start()
    {
        TurnSystem.Instance.onTurnChanged += UpdateSkillButtons;
    }
    private void UpdateSkillButtons()
    {
        for (int childIndex = transform.childCount - 1; childIndex >= 0 ; childIndex--)
        {
            Destroy(transform.GetChild(childIndex).gameObject);
        }

        var newSkills = TurnSystem.Instance.CharacterSkills;
        foreach (var item in newSkills)
        {
            var button = Instantiate(skillPrefab, transform);
            button.GetComponent<Image>().sprite = item.SkillSprite;
            button.GetComponent<Button>().onClick.AddListener(() => TurnSystem.Instance.currentCharacter.PerformAction(item)); 
            //Debug.Log("image added "+ item.SkillSprite);
        }
    }
    private void OnDestroy()
    {
        TurnSystem.Instance.onTurnChanged -= UpdateSkillButtons;
    }
}
