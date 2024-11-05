using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button[] menuButtons;
    private int currentIndex = 0;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(menuButtons[currentIndex].gameObject);
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0)
        {
            ChangeSelection(-1);
        }
        else if (verticalInput < 0)
        {
            ChangeSelection(1);
        }

        if (Input.GetButtonDown("Submit"))
        {
            ExecuteButtonAction();
        }
    }

    private void ChangeSelection(int direction)
    {
        currentIndex += direction;
        if (currentIndex < 0) currentIndex = menuButtons.Length - 1;
        if (currentIndex >= menuButtons.Length) currentIndex = 0;

        EventSystem.current.SetSelectedGameObject(menuButtons[currentIndex].gameObject);
    }

    private void ExecuteButtonAction()
    {
        menuButtons[currentIndex].onClick.Invoke();
    }
}
