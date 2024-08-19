using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCacheRessorce : MonoBehaviour
{
    // Start is called before the first frame update

    
    public TextMeshProUGUI resourcePossessedStr;
    public TextMeshProUGUI coutResourceStr;

    private float resourcesPossessedFloat; 
    private float coutResourceFloat; 

    // Update is called once per frame
    void Update()
    {
        resourcesPossessedFloat = float.Parse(resourcePossessedStr.text);
        coutResourceFloat = float.Parse(coutResourceStr.text);
        
        if (resourcesPossessedFloat < coutResourceFloat )
        {
            gameObject.GetComponent<Image>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
    }
}
