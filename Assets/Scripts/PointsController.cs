using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointsController : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private Text pointText;
    private static Text txt;
    private static int score = 0;
    private static int record;
    #endregion
   
    #region Properties
    public static int GetScore { get { return score; } }
    public static int GetRecord { get { return record; } }
    #endregion
    
    #region Unity lifecycle region
    private void Start()
    {
        txt = pointText;
    }


    private void Update()
    {
        if (score > record)
        {
            PlayerPrefs.SetInt("record", score);
            PlayerPrefs.Save();
        }
        record = PlayerPrefs.GetInt("record");
    }
    #endregion

    #region Public methods region
    public static void RefreshPoints()
    {
        txt.text = score.ToString();
    }


    public static void ChangeScore()
    {
        score++;
        RefreshPoints();
    }


    public static void ResetScore()
    {
        score = 0;
        RefreshPoints();
    }
    #endregion
}