using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSliderText : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "Value: " + slider.value.ToString();
    }
}
