using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoicesPanelController : MonoBehaviour
{
    public MenusController menusController;
    public ConfirmPanelController confirmPanelController;
    public List<Texture> texturesList1 = new List<Texture>();
    public List<Color> colorsList1 = new List<Color>();
    public List<Color> colorsList2 = new List<Color>();
    public List<Texture> texturesList2 = new List<Texture>();
    public List<Texture> texturesList3 = new List<Texture>();
    public List<Texture> texturesList4 = new List<Texture>();
    public List<RawImage> images = new List<RawImage>();
    public TextMeshProUGUI text;
    Dictionary<int, string> romanNumbersDictionary = new() {
    {
        0,
        "I"
    }, {
        1,
        "II"
    }, {
        2,
        "III"
    }
};
    // Start is called before the first frame update
    void Start()
    {
        foreach (RawImage image in images)
        {
            image.enabled = false;
            text.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (menusController.currentActiveMenu > 0)
        {
            images[0].enabled = true;
            images[0].texture = texturesList1[menusController.radialMenuChoices[0]];
        } else
        {
            images[0].enabled = false;
        }

        if (menusController.currentActiveMenu > 1)
        {
            images[1].enabled = true;
            images[1].color = colorsList1[menusController.radialMenuChoices[1]];
        }
        else
        {
            images[1].enabled = false;
        }

        if (menusController.currentActiveMenu > 2)
        {
            text.enabled = true;
            text.color = colorsList2[menusController.radialMenuChoices[2]];
            text.text = romanNumbersDictionary[menusController.radialMenuChoices[2]];
        }
        else
        {
            text.enabled = false;
        }

        if (confirmPanelController.isFinished)
        {
            images[2].enabled = true;

            switch (menusController.radialMenuChoices[2])
            {
                case 0:
                    images[2].texture = texturesList2[menusController.radialMenuChoices[3] - 1];
                    break;
                case 1:
                    images[2].texture = texturesList3[menusController.radialMenuChoices[3] - 1];
                    break;
                default:
                    images[2].texture = texturesList4[menusController.radialMenuChoices[3] - 1];
                    break;
            }
        }
        else
        {
            images[2].enabled = false;
        }
    }
}
