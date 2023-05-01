using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    Gun[] guns;
    float moveSpeed = 7;

    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    //aumenta a velocidade do Player
    bool speedUp;

    bool shoot;

    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
        foreach(Gun gun in guns)
        {
            gun.isActive = true;
        }
    }

    
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        //aumenta a velocidade do Player
        speedUp = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);

        shoot = Input.GetKeyDown(KeyCode.Space);

        if (shoot)
        {
            shoot = false;
            foreach(Gun gun in guns)
            {
                gun.Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        float moveAmount = moveSpeed * Time.fixedDeltaTime;

        //aumenta a velocidade do Player
        if(speedUp)
        {
            moveAmount *= 1.5f;
        }
        Vector2 move = Vector2.zero;
        
    if(moveUp)
    {
        move.y += moveAmount; 
    }

    if(moveDown)
    {
        move.y -= moveAmount; 
    }

    if(moveLeft)
    {
        move.x -= moveAmount;
    }

    if(moveRight)
    {
        move.x += moveAmount;
    }

    //conserta o movimento em diagonal do Player
    float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
    if (moveMagnitude > moveAmount)
    {
        float ratio = moveAmount / moveMagnitude;
        move *=ratio;
    }
    pos += move;

    //Cria boundaries para manter o Player dentro da tela do jogo
    if(pos.x <= 2.3f)
    {
        pos.x = 2.3f;
    }
    
    if(pos.x >= 17)
    {
        pos.x = 17;
    }

    if(pos.y <= -4.3f)
    {
        pos.y = -4.3f;
    }

    if(pos.y >= 4.5f)
    {
        pos.y = 4.5f;
    }
    
    transform.position = pos;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if(bullet != null)
        {
            if(bullet.isEnemy)
            {
            Destroy(gameObject);
            Destroy(bullet.gameObject);
            }
        }

        Destructable destructable = collision.GetComponent<Destructable>();
        if(destructable != null)
        {
            Destroy(gameObject);
            Destroy(destructable.gameObject);
        }
    }
}
