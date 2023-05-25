using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSide : Skill
{
    public FlipSide(ActionHandler actionHandler, SkillConfiguration attackConfiguration) : base(actionHandler, attackConfiguration)
    {
    }

    public override Sprite SkillSprite => attackConfiguration.skillSprite;

    public override bool ExecuteAction()
    {
        //can flip?

        actionHandler.GetComponent<CharacterRotationHandler>().Rotate();

        actionHandler.StartCoroutine(DelayClear());
        return true;
    }
    private IEnumerator DelayClear()
    {
        yield return null;
        onFinished?.Invoke();
    }
}
