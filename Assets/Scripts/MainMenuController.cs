using UnityEngine;
using System.Collections;
using System;

public class MainMenuController : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private GameObject mainMenuPanel;

    [SerializeField]
    private GameObject cube;

    [SerializeField]
    private GameObject redCube;

    [SerializeField]
    private Animator startPlayerAnimation;

    [SerializeField]
    private Animator startCameraAnimation;
    #endregion

    #region Event handlers region
    public void OnPlayButton()
    {
        if (startPlayerAnimation != null)
        {
            startPlayerAnimation.SetTrigger("Start");
        }
        if (startCameraAnimation != null)
        {
            startCameraAnimation.SetTrigger("Start");
        }
        mainMenuPanel.SetActive(false);
        Generate.GeneratePlatform(cube, redCube);
        Stick.IsPlayerAtTheEndOfPlatform = true;
    }


    public void OnSoundButton(bool isSoundActive)
    {
       if(AudioListener.volume>0)
        {
            AudioListener.volume = 0;
        }
       else
        {
            AudioListener.volume = 1;
        }
    }

    #endregion
}
