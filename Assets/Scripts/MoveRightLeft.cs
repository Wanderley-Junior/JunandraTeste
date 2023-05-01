using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightLeft : MonoBehaviour
{
    public float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //dados insuficientes, mudar de posicao...mas para qual posicao
        Vector2 pos = transform.position;

        //mudar a posicao no eixo de x para a esquerda, por isso, o sinal de menos
        pos.x -= moveSpeed * Time.deltaTime;
        
        if(pos.x < -3)
        {
            Destroy(gameObject);
        }

        //para que a posicao seja atualizada a cada frame, tem que escrever isso
        transform.position = pos;
    }
}