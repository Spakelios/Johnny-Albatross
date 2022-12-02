using UnityEngine;
using UnityEngine.UI;
 
public class ButtonPress : MonoBehaviour
{
    public KeyCode key;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            _button.onClick.Invoke();
        }
    }
}