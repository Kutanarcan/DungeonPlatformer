using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogDisplayer : MonoBehaviour
{
    [SerializeField]
    Image speakerIcon;
    [SerializeField]
    TextMeshProUGUI dialogText;
    [SerializeField]
    Button continueButton;
    [SerializeField]
    Canvas dialogCanvas;

    public void SetConversationSettings(Sprite icon, string dialog)
    {
        speakerIcon.sprite = icon;
        dialogText.text = dialog;
    }

    public void SetContinueButtonActiveness(bool activeness)
    {
        continueButton.gameObject.SetActive(activeness);
    }

    public void OnContinueButtonPressed()
    {
        InGameEvents.OnDialogContinueButtonPressedFunction();
    }
    public void SetDialogBox(bool activeness)
    {
        dialogCanvas.gameObject.SetActive(activeness);
    }
}
