using UnityEngine;
using System.Collections.Generic;

public class Generate : MonoBehaviour
{
    #region Fields
    private static List<GameObject> objects = new List<GameObject>();
    private static int startPlatform = 0;
    private static int lengthOfPlatform = 0;
    private static int endPlatform = 0;
    private static int endOfPrevPlatform = 0;
    #endregion

    #region Properties
    public static int EndOfPrevPlatform { get { return endOfPrevPlatform; } }
    #endregion

    #region Public methods region
    public static void GeneratePlatform(GameObject cube, GameObject redCube)
    {
        startPlatform = endPlatform + Random.Range(1, 8);
        lengthOfPlatform = Random.Range(1, 4) * 2 + 3;
        endOfPrevPlatform = endPlatform;
        endPlatform = startPlatform + lengthOfPlatform;
        Vector3 position = new Vector3(startPlatform, 0, 0);
        objects.Add((GameObject)Instantiate(cube, position, Quaternion.identity));
        objects[objects.Count - 1].transform.localScale = new Vector3(lengthOfPlatform, 1, 1);
        Vector3 redCubePosition = new Vector3(startPlatform + (lengthOfPlatform / 2) + 0.5f, 0, -1f);
        objects.Add((GameObject)Instantiate(redCube, redCubePosition, Quaternion.identity));
    }


    public static void NextPlatformTrigger(GameObject endOfPlatform)
    {
        Vector3 position1 = new Vector3(endPlatform - 1.4f, 0, 0);
        objects.Add((GameObject)Instantiate(endOfPlatform, position1, Quaternion.identity));
    }


    public static void GenerateNextPlatformTrigger(GameObject myWall, GameObject platformTrigger, float high, AudioSource audio)
    {
        if (myWall.transform.position.x + high <= endPlatform)
        {
            NextPlatformTrigger(platformTrigger);
        }
        if (myWall.transform.position.x + high <= startPlatform + lengthOfPlatform / 2 + 1 && myWall.transform.position.x + high >= startPlatform + lengthOfPlatform / 2)
        {
            PointsController.ChangeScore();
            audio.Play();
        }
    }


    public static void AddElement(GameObject addObject)
    {
        objects.Add(addObject);
    }


    public static void DeleteElements()
    {
        foreach (Object obj in objects)
        {
            Destroy(obj);
        }
        endPlatform = 0;
    }
    #endregion
}
