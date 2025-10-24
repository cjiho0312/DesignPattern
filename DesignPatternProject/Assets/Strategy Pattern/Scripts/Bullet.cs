using UnityEngine;

public class Bullet : MonoBehaviour
{
    float lifeTime;
    [SerializeField] float speed;
    public bool isStandard = false;

    private void Awake()
    {
        isStandard = false;
    }

    void Start()
    {
        lifeTime = 3;
        Debug.Log(gameObject.transform.position);
    }

    void Update()
    {
        if (!isStandard)
        {
            Destroy(gameObject, lifeTime);
            Shoot();
        }
    }

    void Shoot()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
