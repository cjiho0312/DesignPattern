using UnityEngine;

public class Robot : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        transform.position = new Vector3(0, 0, 10f);
    }

    private void Start()
    {
        animator.SetBool("isRunning", true);
    }

    private void Update()
    {
        Run();
    }

    private void Run()
    {
        transform.position += new Vector3(0, 0, -0.02f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Get Damaged");
            Destroy(gameObject);
        }
    }

}
