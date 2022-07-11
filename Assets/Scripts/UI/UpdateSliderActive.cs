using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSliderActive : MonoBehaviour
{
    public int indexWhereActive;
    public MenusController menusController;
    // Start is called before the first frame update
    void Start()
    {
        menusController.OnVariableChange += OnActiveMenuChange;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnActiveMenuChange(int newVal)
    {
        Debug.Log(newVal);
        if (newVal == indexWhereActive)
        {
            gameObject.SetActive(true);
        } else
        {
            gameObject.GetComponent<Slider>().value = 1;
            gameObject.SetActive(false);
        }
    }
}
