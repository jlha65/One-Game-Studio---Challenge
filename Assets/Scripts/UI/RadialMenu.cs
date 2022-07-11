using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class RadialMenu : MonoBehaviour
{
    public List<RadialMenuElement> radialMenuElements;

    public bool updateLayout; //"run" or "generate" for example
    public float padding = 0.002f; //Padding between buttons in radial menu
    public bool isFocused = false;
    private int activeElement = -1;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLayout();
    }

    // Update is called once per frame
    void Update()
    {
        //Don't do anything if this menu isn't focused
        if(isFocused)
        {
            //This is run in the editor to update the position of the buttons
            if (updateLayout)
                UpdateLayout();

            //In order to get the active element
            var stepLength = 360f / radialMenuElements.Count;
            var mouseAngle = NormalizeAngle(Vector3.SignedAngle(Vector3.up, Input.mousePosition - transform.position, Vector3.forward) + stepLength / 2f);
            activeElement = (int)(mouseAngle / stepLength);
            for (int i = 0; i < radialMenuElements.Count; i++)
            {
                if (i == activeElement)
                    radialMenuElements[i].image.color = new Color(1f, 1f, 1f, 0.75f);
                else
                    radialMenuElements[i].image.color = new Color(1f, 1f, 1f, 0.5f);
            }
            //Debug.Log(activeElement);

            if (Input.GetMouseButtonDown(0))
            {
                radialMenuElements[activeElement].gameObject.SetActive(false);
            }
        } else
        {
            activeElement = -1;
        }
        
    }

    void UpdateLayout () {
        //Generate layout depending on how many elements radial menu has

        for (int i = 0; i < radialMenuElements.Count; i++)
        {
            RadialMenuElement element = radialMenuElements[i];
            element.image.fillAmount = 1.0f / radialMenuElements.Count - padding;
            Vector3 eulerRotation = element.image.transform.rotation.eulerAngles;
            element.image.transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, (360.0f + 360.0f / radialMenuElements.Count) * i+1);
        }
    }

    private float NormalizeAngle(float angle) => (angle + 360f) % 360f;
}
