using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RessourcesMananger : MonoBehaviour
{
    // Start is called before the first frame update

    public static RessourcesMananger instance;

    public TextMeshProUGUI cristalQuantityText;
    public TextMeshProUGUI electronicQuantityText;
    public TextMeshProUGUI mineralsQuantityText;
    public TextMeshProUGUI reinforcedQuantityText;
    
    private int cristalQuantity = 100;
    private int electronicQuantity = 100;
    private int mineralsQuantity = 100;
    private int reinforcedQuantity = 100;

    private void Avake()
    {
        instance = this; 
    }
    void Start()
    {
        cristalQuantityText.text = cristalQuantity.ToString();
        electronicQuantityText.text = electronicQuantity.ToString();
        mineralsQuantityText.text = mineralsQuantity.ToString();
        reinforcedQuantityText.text = reinforcedQuantity.ToString();
    }

    // Update is called once per frame
    public void AddCristal(int nbRessources)
    {
        for(int i =0; i< nbRessources; i++ ){
            cristalQuantity += 1;
            cristalQuantityText.text = cristalQuantity.ToString();
        }
    }
    
    public void AddElectronic(int nbRessources)
    {
        for (int i = 0; i < nbRessources; i++)
        {
            electronicQuantity += 1;
            electronicQuantityText.text = electronicQuantity.ToString();
        }
    }
    
    public void AddMineral(int nbRessources)
    {
        for (int i = 0; i < nbRessources; i++)
        {
            mineralsQuantity += 1;
            mineralsQuantityText.text = mineralsQuantity.ToString();
        }
    }
    
    public void Addreinforced(int nbRessources)
    {
        for (int i = 0; i < nbRessources; i++)
        {
            reinforcedQuantity += 1;
            reinforcedQuantityText.text = reinforcedQuantity.ToString();
        }
    }
}
