using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public Button quitGameButton;
    // Start is called before the first frame update
    void Start()
    {
        quitGameButton.onClick.AddListener(onClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onClicked()
    {
        Debug.Log("clicked " + quitGameButton.gameObject.name);
        Application.Quit();
    }
}
