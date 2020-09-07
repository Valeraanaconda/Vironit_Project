using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject textPanel, windowsPanel;
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;
        if (clickCount == 2)
            OnDoubleClick();
    }

    void OnDoubleClick()
    {
        textPanel.SetActive(true);
        windowsPanel.SetActive(false);
    }
}
