using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class Ball : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb;
    public float maxInitialAngle = 0.67f;
    public float moveSpeed = 1f;
    public float startY = 4f;

    private float startX = 0f;
    private void Start()
    {
        InitialPush();
    }

    private void InitialPush()
    {
        //notes: This is a Ternary Operator - If u don't remember look it up!
        Vector2 dir = Random.value > 0.5f ? Vector2.left : Vector2.right;
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb.linearVelocity = dir * moveSpeed;
    }

    private void ResetBall()
    {
        float posY = Random.Range(-startY, startY);
        Vector2 pos = new Vector2(startX, posY);
        /*Note: Using a transform like this affects
         the object holding the script
         -to transform an object not holding the script
         Define a GameObject or Transform*/
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone)
        {
            gameManager.OnScoreZoneReached(scoreZone.id);
            ResetBall();
            InitialPush();
        }
    }
}
