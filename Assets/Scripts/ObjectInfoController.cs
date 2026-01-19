using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ObjectInfoController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject panel;
    
    [SerializeField] private UnityEngine.UI.Image image;
    

    public void SetVisible(bool isVisible = true)
    {
        panel.SetActive(isVisible);

    }

    public void SetObjectInfo(SOObjectInfo info)
    {
        titleText.text = info.objectName;
        descriptionText.text = info.description;
        image.sprite = info.sprite;
    }
}
