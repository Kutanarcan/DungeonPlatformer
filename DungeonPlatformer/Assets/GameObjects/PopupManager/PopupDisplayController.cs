using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupDisplayController : MonoBehaviour
{
    [SerializeField]
    Canvas standartPopupCanvas;
    [SerializeField]
    Canvas InputControlPopUpCanvas;
    [SerializeField]
    TextMeshProUGUI standartMessageText;

    public void ShowStandartMessage(string message)
    {
        standartPopupCanvas.enabled = true;
        standartMessageText.text = message;
    }

    public void CloseStandartMessage()
    {
        standartPopupCanvas.enabled = false;
    }

    public void ShowInputControlMessage()
    {
        InputControlPopUpCanvas.enabled = true;
    }

    public void HideInputControlMessage()
    {
        InputControlPopUpCanvas.enabled = false;
    }
}
