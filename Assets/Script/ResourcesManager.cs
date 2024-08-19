using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI cristalQuantityText;
    [SerializeField]
    private TextMeshProUGUI electronicQuantityText;
    [SerializeField]
    private TextMeshProUGUI mineralsQuantityText;
    [SerializeField]
    private TextMeshProUGUI reinforcedQuantityText;
    
    private int cristalQuantity = 50;
    private int electronicQuantity = 50;
    private int mineralsQuantity = 50;
    private int reinforcedQuantity = 50;

    // Start is called before the first frame update
    void Start()
    {
        cristalQuantityText.text = cristalQuantity.ToString();
        electronicQuantityText.text = electronicQuantity.ToString();
        mineralsQuantityText.text = mineralsQuantity.ToString();
        reinforcedQuantityText.text = reinforcedQuantity.ToString();
    }

    // Update is called once per frame
    public IEnumerator UpdateCristal(int amount)
    {
        for(int i = 0; i < Mathf.Abs(amount); i++ ){
            cristalQuantity += (int)Mathf.Sign(amount);
            cristalQuantityText.text = cristalQuantity.ToString();
            yield return new WaitForSeconds(.02f);
        }
    }
    
    public IEnumerator UpdateElectronic(int amount)
    {
        for (int i = 0; i < Mathf.Abs(amount); i++)
        {
            electronicQuantity += (int)Mathf.Sign(amount);
            electronicQuantityText.text = electronicQuantity.ToString();
            yield return new WaitForSeconds(.02f);
        }
    }
    
    public IEnumerator UpdateMineral(int amount)
    {
        for (int i = 0; i < Mathf.Abs(amount); i++)
        {
            mineralsQuantity += (int)Mathf.Sign(amount);
            mineralsQuantityText.text = mineralsQuantity.ToString();
            yield return new WaitForSeconds(.02f);
        }
    }
    
    public IEnumerator UpdateReinforced(int amount)
    {
        for (int i = 0; i < Mathf.Abs(amount); i++)
        {
            reinforcedQuantity += (int)Mathf.Sign(amount);
            reinforcedQuantityText.text = reinforcedQuantity.ToString();
            yield return new WaitForSeconds(.02f);
        }
    }

}
