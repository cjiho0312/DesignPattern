using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnEnable()
    {
        EventManager.Subscribe(Condition.START, EnableAnimator);
        EventManager.Subscribe(Condition.PAUSE, DisableAnimator);
    }

    public void EnableAnimator()
    {
        animator.enabled = true;
    }

    public void DisableAnimator()
    {
        animator.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.Publish(Condition.START);            
        }
        else
        {
            EventManager.Publish(Condition.PAUSE);
        }
    }

    private void OnDisable()
    {
        EventManager.UnSubscribe(Condition.START, EnableAnimator);
        EventManager.UnSubscribe(Condition.PAUSE, DisableAnimator);
    }
}
