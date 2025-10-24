using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GunA : Weapon
{
    public override void Shoot()
    {
        Instantiate(bulletObject);

        animator.SetTrigger("Shoot");
        StartCoroutine(ShootLight());
        Debug.Log("GunA Shoot");
    }
}
