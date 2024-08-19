using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveShop : MonoBehaviour
{
    // Start is called before the first frame update
    private bool ShopActivate = false;

    private int ActivationCooldown = 10;

    private int canBeActivate = 0;
    void Start()
    {
        ShopActivate = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShopActivate = gameObject.activeSelf;
        if (canBeActivate == 0)
        {
            if (Input.GetKey(KeyCode.I) && ShopActivate == true)
            {
                gameObject.SetActive(false);
                canBeActivate = ActivationCooldown;
            }
            if (Input.GetKey(KeyCode.I) && ShopActivate == false)
            {
                gameObject.SetActive(true);
                canBeActivate = ActivationCooldown;
            }
        }
        else
        {
            canBeActivate = canBeActivate - 1;
        }
           
    }
}
