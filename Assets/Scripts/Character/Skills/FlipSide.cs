using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSide : Skill
{
    public FlipSide(ActionHandler actionHandler, SkillConfiguration attackConfiguration) : base(actionHandler, attackConfiguration)
    {
    }

    public override Sprite SkillSprite => attackConfiguration.skillSprite;

    public override void ExecuteAction()
    {
        actionHandler.GetComponent<CharacterRotationHandler>().Rotate();
        onFinished?.Invoke();
    }
}
