using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] List <Weapon> weaponList;
    int weaponIndex;
    public Weapon weapon;

    void Start()
    {
        weaponIndex = 0;
        weapon = weaponList[weaponIndex];

        foreach(Weapon weapon in weaponList)
        {
            weapon.gameObject.SetActive(false);
        }

        weaponList[0].gameObject.SetActive(true);

        Debug.Log("Weapon Manager Start");
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            WeaponChange();
        }
    }

    void WeaponChange()
    {
        weaponList[weaponIndex].gameObject.SetActive(false);

        weaponIndex++;

        weaponIndex = weaponIndex % weaponList.Count;

        weapon = weaponList[weaponIndex];

        weapon.gameObject.SetActive(true);
        

        Debug.Log("Current Gun : " + weaponList[weaponIndex].name);
    }
}
