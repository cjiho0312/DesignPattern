using System.Collections;
using UnityEngine;

public class GunC : Weapon
{
    public override void Shoot()
    {
        Instantiate(bulletObject);

        animator.SetTrigger("Shoot");
        StartCoroutine(ShootLight());
        Debug.Log("GunC Shoot");
    }
}
