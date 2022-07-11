using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanelController : MonoBehaviour
{
    public GameObject menuBlockPanel;
    public bool isFinished = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseConfirmPanel()
    {
        gameObject.SetActive(false);
        menuBlockPanel.SetActive(false);
        isFinished = false;
    }
}
