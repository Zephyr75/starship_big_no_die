using UnityEngine;
using UnityEngine.UI;

public class NewGameButton : MonoBehaviour
{
    public Button newGameButton;
    
    // Start is called before the first frame update
    void Start()
    {
        newGameButton.onClick.AddListener(onClicked);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onClicked()
    {
        Debug.Log("clicked " + newGameButton.gameObject.name);
    }
}
