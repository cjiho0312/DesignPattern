using System.Collections;
using UnityEngine;

public class GunB : Weapon
{
    public override void Shoot()
    {
        Instantiate(bulletObject);

        animator.SetTrigger("Shoot");
        StartCoroutine(ShootLight());
        Debug.Log("GunB Shoot");
    }
}
