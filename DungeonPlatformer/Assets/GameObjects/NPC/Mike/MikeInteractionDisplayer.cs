using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikeInteractionDisplayer : MonoBehaviour
{
    Canvas interactionCanvas;

    void Awake()
    {
        interactionCanvas = GetComponent<Canvas>();
    }

    public void ShowInteractionCanvas()
    {
        interactionCanvas.enabled = true;
    }

    public void HideInteractionCanvas()
    {
        interactionCanvas.enabled = false;
    }
}
