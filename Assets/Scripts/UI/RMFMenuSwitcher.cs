using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMFMenuSwitcher : MonoBehaviour
{
    public List<RMF_RadialMenu> menus = new List<RMF_RadialMenu>();
    public RotateObject rotateScript;
    public MenusController menusController;
    public int menuIndex;
    public RMF_RadialMenu dependsOn;
    // Start is called before the first frame update
    void Start()
    {
        dependsOn.OnVariableChange += UpdateActiveMenu;
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateActiveMenu();
    }

    private void UpdateActiveMenu(int newVal)
    {
        for (int i = 0; i < menus.Count; i++)
        {
            menus[i].gameObject.SetActive(false);
        }

        Debug.Log("Changing active submenu");
        menusController.radialMenus[menuIndex] = menus[newVal];
        rotateScript.degreeSnap = 360 / menus[newVal].elements.Count;
        transform.localRotation = Quaternion.identity;
        menusController.setCurrentActiveMenu(menusController.currentActiveMenu);

    }
}
