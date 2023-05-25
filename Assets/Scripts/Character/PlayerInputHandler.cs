using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private ActionHandler actionHandler;

    private void Awake()
    {
        actionHandler = GetComponent<ActionHandler>();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            //var action = actionHandler.GetMoveAction();
            //if(!actionHandler.TryPerformAction(action)) return;
            //GetComponent<CharacterRotationHandler>().RotateToDirection(true);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //var action = actionHandler.GetMoveAction();
            //if(!actionHandler.TryPerformAction(action, false)) return;
            //GetComponent<CharacterRotationHandler>().RotateToDirection(false);
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
           var action = actionHandler.GetAction<ShootAttack>();
        actionHandler.PerformAction(action);
        }
    }
    
}
