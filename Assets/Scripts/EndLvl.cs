using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndLvl : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private GameObject cube;

    [SerializeField]
    private GameObject redCube;

    private bool isTrigger = false;
    #endregion

    #region Unity lifecycle region
    private void Update()
    {
        if (isTrigger)
        {
            PointsController.ChangeScore();
            PlayerController.MoveX = 0f;
            Generate.GeneratePlatform(cube, redCube);
            BoxCollider2D box = GetComponent<BoxCollider2D>();
            Stick.IsPlayerAtTheEndOfPlatform = true;
            box.enabled = false;
            isTrigger = false;
        }
    }
    #endregion

    #region Event handlers region
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTrigger = true;
        }
    }
    #endregion
}
