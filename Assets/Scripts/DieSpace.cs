using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DieSpace : MonoBehaviour
{
    #region Fields
    private AudioSource dieAudio;

    [SerializeField]
    private GameObject respawn;

    [SerializeField]
    private GameObject cube;

    [SerializeField]
    private GameObject redCube;

    [SerializeField]
    private Text score;

    [SerializeField]
    private Text records;

    [SerializeField]
    private GameObject deadMenuPanel;

    [SerializeField]
    private GameObject mainMenuPanel;
    #endregion

    #region Unity lifecycle region
    private void Start()
    {
        dieAudio = GetComponent<AudioSource>();
    }
    #endregion

    #region Event handlers region
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int scoreInt = PointsController.GetScore;
            int recordInt = PointsController.GetRecord;
            score.text = "Score: " + scoreInt.ToString();
            records.text = "Record: " + recordInt.ToString();
            deadMenuPanel.SetActive(true);
            other.transform.position = respawn.transform.position;
            PlayerController.MoveX = 0f;
            dieAudio.Play();
            Rotate.IsGameEnded = true;
        }
    }


    public void OnPlayButton()
    {
        deadMenuPanel.SetActive(false);
        Generate.DeleteElements();
        PointsController.ResetScore();
        Generate.GeneratePlatform(cube, redCube);
        Stick.IsPlayerAtTheEndOfPlatform = true;
        Rotate.IsGameEnded = false;
    }


    public void OnHomeButton()
    {
        deadMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        Generate.DeleteElements();
        PointsController.ResetScore();
        Rotate.IsGameEnded = false;
    }
    #endregion
}
