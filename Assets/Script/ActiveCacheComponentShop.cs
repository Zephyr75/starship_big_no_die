using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveCacheComponentShop : MonoBehaviour
{
    private bool canBuy;
    public GameObject[] cacheResource;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cacheResource.Length; i++)
        {
            if (cacheResource[i].GetComponent<Image>().enabled == true)
            {
                canBuy = false;
            }
        }

        if (canBuy == false)
        {
            gameObject.GetComponent<Image>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
        
    }
}
