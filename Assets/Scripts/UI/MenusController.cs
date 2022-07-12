using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenusController : MonoBehaviour
{
    private int m_currentActiveMenu = 0;
    public int currentActiveMenu
    {
        get { return m_currentActiveMenu; }
        set
        {
            if (m_currentActiveMenu != value)
            {
                m_currentActiveMenu = value;
                if (OnVariableChange != null)
                {
                    OnVariableChange(m_currentActiveMenu);
                    Debug.Log("Variable changed: " + OnVariableChange.ToString());
                }
            }  
        }
    }

    public delegate void OnVariableChangeDelegate(int newVal);
    public event OnVariableChangeDelegate OnVariableChange;

    //The menu objects are stored here
    public List<RMF_RadialMenu> radialMenus = new List<RMF_RadialMenu>();

    //The handles for menu objects are stored here (rotation wheels)
    public List<RotateObject> radialMenuHandles = new List<RotateObject>();

    //The current choices made for each menu are stored here
    public List<int> radialMenuChoices = new List<int> { -1, -1, -1, -1 };
    void Start()
    {
        radialMenuChoices = new List<int> { -1, -1, -1, -1 };

        updateRadialMenuRotationAngles();
        setCurrentActiveMenu(0);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < radialMenuHandles.Count; i++)
        {
            if (i == currentActiveMenu)
            {
                radialMenuHandles[i].isActive = true;
                radialMenuHandles[i].gameObject.GetComponent<Image>().enabled = true;
            } else
            {
                radialMenuHandles[i].isActive = false;
                radialMenuHandles[i].gameObject.GetComponent<Image>().enabled = false;
            }
        }
    }

    public void setCurrentActiveMenu(int index)
    {
        currentActiveMenu = index;
        resetMenus();
        radialMenus[currentActiveMenu].gameObject.SetActive(true);

        List<Button> buttonsInMenu = new List<Button>(radialMenus[currentActiveMenu].gameObject.GetComponentsInChildren<Button>());
        foreach (Button button in buttonsInMenu)
        {
            button.interactable = true;
        }

        if (currentActiveMenu + 1 < radialMenus.Count)
        {
            radialMenus[currentActiveMenu + 1].gameObject.SetActive(true);
            radialMenus[currentActiveMenu + 1].gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

            List<Button> buttonsInNextMenu = new List<Button>(radialMenus[currentActiveMenu + 1].gameObject.GetComponentsInChildren<Button>());
            foreach (Button button in buttonsInNextMenu)
            {
                button.interactable = false;
            }
        }
    }

    public void decreaseCurrentActiveMenu()
    {
        if (currentActiveMenu - 1 >= 0)
            setCurrentActiveMenu(currentActiveMenu - 1);
    }

    public void setRadialMenuChoice(int choice)
    {
        radialMenuChoices[choice / 10 - 1] = choice % 10;
    }

    public void updateRadialMenuRotationAngles()
    {
        for (int i = 0; i < radialMenuHandles.Count; i++)
        {
            radialMenuHandles[i].degreeSnap = 360 / radialMenus[i].elements.Count;
        }
    }

    public void rotateCurrentMenuLeft()
    {
        rotateCurrentMenu(-radialMenuHandles[currentActiveMenu].degreeSnap);
    }

    public void rotateCurrentMenuRight()
    {
        rotateCurrentMenu(radialMenuHandles[currentActiveMenu].degreeSnap);
    }

    public void rotateCurrentMenu(int degrees)
    {
        radialMenuHandles[currentActiveMenu].transform.rotation = 
            Quaternion.Euler(
                radialMenuHandles[currentActiveMenu].transform.rotation.eulerAngles.x,
                radialMenuHandles[currentActiveMenu].transform.rotation.eulerAngles.y,
                radialMenuHandles[currentActiveMenu].transform.rotation.eulerAngles.z + degrees);
    }

    public void resetMenus()
    {
        foreach (RMF_RadialMenu menu in radialMenus)
        {
            menu.gameObject.SetActive(false);
            menu.gameObject.transform.localScale = Vector3.one;
        }
    }
}
