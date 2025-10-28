using UnityEngine;
using UnityEngine.TextCore.Text;

public class PickUp : MonoBehaviour, State
{
    public void Enter(Character character)
    {
        character.animator.SetTrigger("isPicking");
    }

    public void Execute(Character character)
    {
        AnimatorStateInfo animatorStateinfo = character.animator.GetCurrentAnimatorStateInfo(0);

        if (animatorStateinfo.IsName("isPicking") && animatorStateinfo.normalizedTime < 1.0f || character.animator.IsInTransition(0))
        {
            character.SetState(new Idle());
        }
    }

    public void Exit(Character character)
    {
        
    }

}
