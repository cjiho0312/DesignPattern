using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] public Light light;
    //[SerializeField] public ParticleSystem effect;
    [SerializeField] public Animator animator;
    [SerializeField] public GameObject bulletObject;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //effect = GetComponentInChildren<ParticleSystem>();
        light = GetComponentInChildren<Light>();
        light.gameObject.SetActive(false);

        Bullet b = bulletObject.GetComponent<Bullet>();
        b.isStandard = true;
    }

    public abstract void Shoot();

    public IEnumerator ShootLight()
    {
        light.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        light.gameObject.SetActive(false);
    }
}
