using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    #region Fields
    private Animator animator;

    [SerializeField]
    private GameObject player;
    #endregion

    #region Unity lifecycle region
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            Destroy(animator);
        }
    }


    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 8, 8, -10f);
    }
    #endregion
}
