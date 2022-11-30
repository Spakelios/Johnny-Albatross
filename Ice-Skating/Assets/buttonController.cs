using UnityEngine;
using UnityEngine.UI;
 
public class buttonController : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    void Update()
    {
        if (name == "woah0")
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                _button.onClick.Invoke();
            }
        }

        if (name == "woah1")
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                _button.onClick.Invoke();
            }
        }
        
    }
}