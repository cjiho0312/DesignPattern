using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] public Animator animator;
    State currentState;

    private void Awake()
    {
        if (animator != null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Start()
    {
        currentState = new Idle();
    }

    private void Update()
    {
        currentState.Execute(this);
    }

    public void SetState(State state)
    {
        currentState.Exit(this);
        this.currentState = state;
        currentState.Enter(this);
    }

}
