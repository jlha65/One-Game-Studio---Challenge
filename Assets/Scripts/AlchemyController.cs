using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlchemyController : MonoBehaviour
{
    public MenusController menusController;
    public Slider slider;
    public ParticleSystem ps;
    public Image menuBlockPanel;
    public ConfirmPanelController confirmPanel;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Example res: Fusionados 16 Espada Amarilla de tipo 2
    public void executeAlchemyOperation(string value)
    {
        string res = "";
        //Main operation to do
        switch (menusController.radialMenuChoices[0])
        {
            case 0:
                res += "Fusionados ";
                break;
            case 1:
                res += "Descubiertos ";
                break;
            case 2:
                res += "Forjados ";
                break;
            default:
                res += "Mezclados ";
                break;
        }

        //Number chosen
        res += slider.value.ToString() + " ";

        //Object chosen
        res += value.ToString() + " ";

        //Color chosen
        switch (menusController.radialMenuChoices[1])
        {
            case 0:
                res += "Morada ";
                break;
            case 1:
                res += "Roja ";
                break;
            case 2:
                res += "Amarilla ";
                break;
            case 3:
                res += "Verde ";
                break;
            case 4:
                res += "Cyan ";
                break;
            default:
                res += "Azul ";
                break;
        }

        //Type chosen
        switch (menusController.radialMenuChoices[2] + 1)
        {
            case 1:
                res += "de tipo 1";
                break;
            case 2:
                res += "de tipo 2";
                break;
            default:
                res += "de tipo 3";
                break;
        }
        Debug.Log(res);

        //Lock UI for a few seconds
        StartCoroutine(ExecuteAfterTime(3.0f, res));

        //Play animation
        PlayAnimation();
    }

    //Animation for alchemy
    public void PlayAnimation()
    {
        ps.Play();
    }

    IEnumerator ExecuteAfterTime(float time, string res)
    {
        menuBlockPanel.gameObject.SetActive(true);
        confirmPanel.isFinished = true;
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        confirmPanel.gameObject.SetActive(true);
        text.text = res;
    }
}
