using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public readonly string EDITION_MODE = "Editing";
    public readonly string PLAYING_MODE = "Playing";
    public string currentMode;

    [SerializeField] private GameObject litter;
    [SerializeField] private Text UI_CurrentModeText;

    public void toggleMode()
    {
        if (currentMode == EDITION_MODE) currentMode = PLAYING_MODE;
        else if (currentMode == PLAYING_MODE) currentMode = EDITION_MODE;
        UI_CurrentModeText.text = currentMode;
    }

    private void Start()
    {
        currentMode = EDITION_MODE;
    }

}
