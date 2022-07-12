using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    //Sound: https://freesound.org/people/Sjonas88/sounds/538548/
    public AudioSource switchSelectionSoundSource;
    public AudioSource selectionSoundSource;

    public MenusController menusController;
    public List<RMF_RadialMenu> radialMenus = new List<RMF_RadialMenu>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (RMF_RadialMenu menu in radialMenus)
        {
            menu.OnVariableChange += PlaySwitchSelectionSound;
        }

        menusController.OnVariableChange += PlaySelectionSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySwitchSelectionSound(int newVal)
    {
        switchSelectionSoundSource.Play();
    }

    public void PlaySelectionSound(int newVal)
    {
        selectionSoundSource.Play();
    }
}
