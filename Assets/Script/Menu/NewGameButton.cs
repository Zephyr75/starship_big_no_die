using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Script.Menu
{
    public class NewGameButton : MonoBehaviour
    {
        public Button newGameButton;
    
        // Start is called before the first frame update
        void Start()
        {
            newGameButton.onClick.AddListener(OnClicked);
        
        
        }

        void OnClicked()
        {
            SceneManager.LoadScene("Main");
            Debug.Log("clicked " + newGameButton.gameObject.name);
        }
    }
}
