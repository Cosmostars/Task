using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject sword;
    public GameObject spear;
    public GameObject bomb;
    public GameObject activeWeapon;
    private bool selectedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        selectedWeapon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Debug.Log("1 pressed");
            sword.SetActive(true);
            activeWeapon = sword;

            spear.SetActive(false);
            bomb.SetActive(false);

        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Debug.Log("2 pressed");
            sword.SetActive(false);
            bomb.SetActive(false);

            spear.SetActive(true);
            activeWeapon = spear;

        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Debug.Log("3 pressed");
            sword.SetActive(false);
            spear.SetActive(false);

            bomb.SetActive(true);
            activeWeapon = bomb;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropWeapon();
        }
    }

    void DropWeapon()
    {
        if (!selectedWeapon)
        {
            //Destroy(activeWeapon);
            activeWeapon.SetActive(false);
        }
    }
}
