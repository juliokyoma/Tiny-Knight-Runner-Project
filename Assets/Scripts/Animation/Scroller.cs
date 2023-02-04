using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    public Generator generator; // importando a velocidade dos espinhos pro ch�o ser a mesma
    public float VelScrolerGround; // velocidade que vai mover o ch�o

    // Update is called once per frame

    private void Start()
    {
        plus5();
    }
    private void FixedUpdate()
    {
       
        if (transform.position.x <= -62) // se estiver fora da tela
            {
                transform.position = new Vector3(62, 0); // teleportando o ch�o pra frente
            }
            transform.position += new Vector3(VelScrolerGround * Time.deltaTime * -1, 0); // movendo o ch�o pra tr�s
    }
    private void plus5()
    {
            VelScrolerGround += 0.1f;
            this.Wait(1.0f, (plus5));
    }
}
