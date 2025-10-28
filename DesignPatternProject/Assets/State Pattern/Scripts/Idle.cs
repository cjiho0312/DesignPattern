using UnityEngine;

public class Idle : MonoBehaviour, State
{
    public void Enter(Character character)
    {
        character.animator.SetInteger("isWalking", 0);
    }

    public void Execute(Character character)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.SetState(new PickUp());
        }

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            character.SetState(new Walk());
        }
    }

    public void Exit(Character character)
    {
        
    }
}
