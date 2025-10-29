using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Collider AttackArea;
    Animator animator;
    bool isAttacking;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        if (AttackArea == null)
        {
            AttackArea = GetComponentInChildren<Collider>();
        }
        
        AttackArea.enabled = false;
        isAttacking = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        AttackArea.enabled = true;

        animator.SetTrigger("isAttack");
        yield return new WaitForSeconds(0.3f);

        AttackArea.enabled = false;
        isAttacking = false;
    }
}
