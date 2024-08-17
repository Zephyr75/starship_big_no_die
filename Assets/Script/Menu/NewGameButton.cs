using UnityEngine;
using UnityEngine.UI;

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

        // Update is called once per frame
        void Update()
        {
        
        }

        void OnClicked()
        {
            Debug.Log("clicked " + newGameButton.gameObject.name);
        }
    }
}
