using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float speed = 10f;

    float currentWalkSpeed;

    bool isWalking;
    bool isPicking;
    bool isPressSpace;


    private void Awake()
    {
        if (animator != null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Start()
    {
        currentWalkSpeed = 0;
        isWalking = false;
        isPicking = false;
        isPressSpace = false;
    }

    private void Update()
    {
        Walk();
        PickUp();
    }

    public void Walk()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");

        if ((H != 0 || V != 0) && !isPicking)
        {
            if (currentWalkSpeed < 10)
            {
                currentWalkSpeed += Time.deltaTime * speed;
            }
            else if (currentWalkSpeed > 10)
            {
                currentWalkSpeed = 10f;
            }

            isWalking = true;
            animator.SetFloat("isWalking", currentWalkSpeed);
        }
        else if (currentWalkSpeed > 0)
        {
            currentWalkSpeed -= Time.deltaTime * speed * 5f;

            isWalking = true;
            animator.SetFloat("isWalking", currentWalkSpeed);
        }
        else if (currentWalkSpeed < 0)
        {
            currentWalkSpeed = 0;

            isWalking = false;
            animator.SetFloat("isWalking", currentWalkSpeed);
        }
    }


    public void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isWalking && !isPicking && !isPressSpace)
        {
            animator.SetTrigger("isPicking");
            isPressSpace = true;

        }
        if (isPressSpace && animator.GetCurrentAnimatorStateInfo(0).IsName("pickup"))
        {
            isPicking = true;
        }
        else if (isPicking && animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            isPicking = false;
            isPressSpace = false;
        }
    }
}
