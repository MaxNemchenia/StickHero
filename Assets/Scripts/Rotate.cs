using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    #region Fields
    private bool isRotate;
    private static bool isGameEnded=false;
    private float smooth = 9.0f;
    private float doorOpenAngle = 90.0f;
    private Vector3 defaultAngle;
    private Vector3 currentAngle;
    private AudioSource rotateAudio;
    #endregion

    #region Properties
    public static bool IsGameEnded { set { isGameEnded = value; } }
    #endregion

    #region Unity lifecycle region
    private void Start()
    {
        rotateAudio = GetComponent<AudioSource>();
        defaultAngle = transform.eulerAngles;
        currentAngle = new Vector3(defaultAngle.x, defaultAngle.y, doorOpenAngle);
    }


    private void Update()
    {
        if (isRotate)
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, currentAngle, Time.deltaTime * smooth);
        }
        if (!isGameEnded & (Input.GetKeyUp(KeyCode.Q) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            isRotate = !isRotate;
            rotateAudio.Play();
        }
    }
    #endregion
}
