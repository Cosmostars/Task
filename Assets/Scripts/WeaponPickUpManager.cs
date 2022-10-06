using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUpManager : MonoBehaviour
{
    public GameObject player;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;

    void Update()
    {
       
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (col.gameObject == weapon1)
            {
                Debug.Log("COLLLISION");
                weapon1.SetActive(false);
            }
            else if (col.gameObject == weapon2)
            {
                Debug.Log("COLLLISION");
                weapon2.SetActive(false);
            }
            else if (col.gameObject == weapon3)
            {
                Debug.Log("COLLLISION");
                weapon3.SetActive(false);
            }
        }
    }
}

