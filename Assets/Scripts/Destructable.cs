using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Destructable : MonoBehaviour
{
    //ETAPA 1A: local dentro da tela onde o inimigo pode ser destruido
    bool canBeDestroyed = false;
    public int scoreValue = 100;
    
    void Start()
    {
        Level.instance.AddDestructable();
    }

    void Update()
    {
        //Etapa 3Afinal: local dentro da tela onde o inimigo pode ser destruido
        if(transform.position.x < 18.0f && !canBeDestroyed)
        {
            canBeDestroyed = true;
            Gun[] guns = transform.GetComponentsInChildren<Gun>();
            foreach (Gun gun in guns)
            {
                gun.isActive = true;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ETAPA 2A: local dentro da tela onde o inimigo pode ser destruido
        if (!canBeDestroyed)
        {
            return;
        }
        Bullet bullet = collision.GetComponent<Bullet>();

        if (bullet != null)
        {   //ETAPA 2Bfinal: para que o tire do inimigo nao o mate quando sair
            if(!bullet.isEnemy)
            {
                
            }
            Level.instance.AddScore(scoreValue);
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
    }

    private void onDestroy()
    {
        Level.instance.RemoveDestructable();
    }
}
