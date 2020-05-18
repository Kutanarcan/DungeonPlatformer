using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance { get; private set; }
    [SerializeField]
    PopupDisplayController popupDisplayController;

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ShowStandartPopup(string message)
    {
        popupDisplayController.ShowStandartMessage(message);
    }

    public void ShowInputControlMessage()
    {
        popupDisplayController.ShowInputControlMessage();
    }

    public void HideInputControlMessage()
    {
        popupDisplayController.HideInputControlMessage();
    }
}
