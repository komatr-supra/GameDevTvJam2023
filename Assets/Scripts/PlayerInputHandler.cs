using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private SimpleAnimationSO animationIdle;
    private Mover mover;
    private bool inProgress;
    
    private void Awake()
    {
        mover = GetComponent<Mover>();
    }
    private void Update() {
        if(inProgress) return;

        if(Input.GetKeyDown(KeyCode.D))
        {
            inProgress = true;
            mover.Move(true, Idle);
            GetComponent<CharacterRotationHandler>().RotateToDirection(true);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            inProgress = true;
            mover.Move(false, () => Idle());
            GetComponent<CharacterRotationHandler>().RotateToDirection(false);
        }
    }
    private void Idle()
    {
        inProgress = false;
        GetComponent<SimpleAnimator>().SetAnimation(animationIdle);
    }
}
