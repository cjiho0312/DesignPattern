using UnityEngine;

public interface State
{
    public abstract void Enter(Character character);
    public abstract void Execute (Character character);
    public abstract void Exit(Character character);
}
