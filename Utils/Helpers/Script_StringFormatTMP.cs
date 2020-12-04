﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Formats TMP strings
/// 
/// Set useDynamicDisplay to see formatting as dev'ing
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class Script_StringFormatTMP : MonoBehaviour
{
    [SerializeField] private bool useDynamicDisplay;
    [SerializeField] private bool alwaysUpdate;
    [TextArea(3,10)]
    [SerializeField] private string dynamicText;
    
    void Start()
    {
        string unformattedStr = GetComponent<TextMeshProUGUI>().text; 
        GetComponent<TextMeshProUGUI>().text = Script_Utils.FormatString(unformattedStr);
    }

    void OnValidate()
    {
        if (useDynamicDisplay)  DynamicDisplay();
    }

    void Update()
    {
        if (alwaysUpdate)
        {
            if (useDynamicDisplay)  DynamicDisplay();
            else                    FormatTMPText();
        }
    }

    private void FormatTMPText()
    {
        string unformattedStr = GetComponent<TextMeshProUGUI>().text; 
        GetComponent<TextMeshProUGUI>().text = Script_Utils.FormatString(unformattedStr);   
    }

    private void DynamicDisplay()
    {
        GetComponent<TextMeshProUGUI>().text = Script_Utils.FormatString(dynamicText);
    }
}
