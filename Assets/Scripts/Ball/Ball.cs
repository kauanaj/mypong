using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 speedBall = new Vector2(1, 1);
    private Vector2 _startSpeed;

    public string keyToCheck = "Player";

    [Header("Randomization Speed Ball")]
    public Vector2 randSpeedY = new Vector2(1, 3);
    public Vector2 randSpeedX = new Vector2(1, 3);

    private Vector2 _startBallPosition;
    public bool _canMove = false;

    private void Awake()
    {
        _startBallPosition = transform.position;
        _startSpeed = speedBall;
    }

    void Update()
    {
        if (!_canMove) return;

        transform.Translate(speedBall);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == keyToCheck) 
        {
            OnPlayerCollision();
        }
        else
        {
            speedBall.y *= -1;
        }
    }

    private void OnPlayerCollision() 
    {
        speedBall.x *= -1;
        float rand = Random.Range(randSpeedX.x, randSpeedX.y);

        if(speedBall.x < 0) 
        {
            rand = -rand;
        }

        speedBall.x = rand;

        rand = Random.Range(randSpeedY.x, randSpeedY.y);
        speedBall.y = rand;
    }

    public void ResetBall() 
    {
        transform.position = _startBallPosition;
        speedBall = _startSpeed;
    }

    public void CanMove(bool state) 
    {
        _canMove = state;
    }
}
