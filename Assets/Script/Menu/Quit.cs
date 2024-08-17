using UnityEngine;
using UnityEngine.UI;

namespace Script.Menu
{
    public class Quit : MonoBehaviour
    {
        public Button quitGameButton;
        // Start is called before the first frame update
        void Start()
        {
            quitGameButton.onClick.AddListener(OnClicked);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void OnClicked()
        {
            Debug.Log("clicked " + quitGameButton.gameObject.name);
            Application.Quit();
        }
    }
}
