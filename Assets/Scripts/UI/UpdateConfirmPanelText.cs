using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateConfirmPanelText : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(string text)
    {
        textMeshProUGUI.text = text;
    }
}
