using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour
{
    #region Fields
    private GameObject myWall;
    private int high = 0;
    private bool IsPlatformExist = false;
    private static bool isPlayerAtTheEndOfPlatform = false;
    private AudioSource redCubeAudio;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject wall;

    [SerializeField]
    private GameObject platformTrigger;
    #endregion

    #region Properties
    public static bool IsPlayerAtTheEndOfPlatform { set { isPlayerAtTheEndOfPlatform = true; } }
    #endregion

    #region Unity lifecycle region
    private void Start()
    {
        redCubeAudio = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {
        if (isPlayerAtTheEndOfPlatform)
        {
            if (Input.GetKeyDown(KeyCode.Q) || (Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began) )
            {
                high = 0;
            }
            if (Input.GetKey(KeyCode.Q) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary))
            {
                if (high == 0)
                {
                    myWall = Instantiate(wall);
                    myWall.transform.position = new Vector3(Generate.EndOfPrevPlatform, 0.5f, 1);
                    Generate.AddElement(myWall);
                    IsPlatformExist = true;
                }
                high++;
                myWall.transform.localScale = new Vector3(myWall.transform.localScale.x, high / 6, myWall.transform.localScale.z);
            }
        }
    }


    private void Update()
    {
        if (isPlayerAtTheEndOfPlatform)
        {
            if (Input.GetKeyUp(KeyCode.Q) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                if (IsPlatformExist)
                {
                    Generate.GenerateNextPlatformTrigger(myWall, platformTrigger, high / 6, redCubeAudio);
                    PlayerController.IsRun = true;
                    isPlayerAtTheEndOfPlatform = false;
                    IsPlatformExist = false;
                    high = 0;
                }
            }
        }
    }
    #endregion
}
