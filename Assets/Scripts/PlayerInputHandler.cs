using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private SimpleAnimationSO animationIdle;
    private ActionHandler actionHandler;
    private bool inProgress;
    
    private void Awake()
    {
        actionHandler = GetComponent<ActionHandler>();
    }
    private void Update() {
        if(inProgress) return;

        if(Input.GetKeyDown(KeyCode.D))
        {
            inProgress = true;
            var action = actionHandler.GetMoveAction();
            action.ExecuteAction(Idle);
            GetComponent<CharacterRotationHandler>().RotateToDirection(true);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            
        }
    }
    private void Idle()
    {
        inProgress = false;
        GetComponent<SimpleAnimator>().SetAnimation(animationIdle);
    }
}
