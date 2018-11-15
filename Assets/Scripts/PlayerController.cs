using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    #region Fields
    private int sleep = 0;
    private float speed = 10f;
    private Rigidbody2D rb;
    private Animator animator;
    private static bool isRun = false;
    private static float moveX = 0f;
    #endregion

    #region Properties
    public static bool IsRun { set { isRun = value; } }
    public static float MoveX { set { moveX = value; } }
    #endregion

    #region Unity lifecycle region
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            Destroy(animator);
        }
    }


    void Update()
    {
        if (isRun)
        {
            sleep++;
            if (sleep > 50)
            {
                moveX = 2f;
                sleep = 0;
                isRun = false;
            }
        }
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
    }
    #endregion
}
