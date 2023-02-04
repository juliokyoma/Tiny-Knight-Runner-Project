using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class spr_Spike : MonoBehaviour
{
    public Generator generator;
    public PlayerLife playerLife;
    void Update()
    {
        transform.Translate(Vector2.left * generator.CurrentSpeedSpike * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("nextLine"))
        {
            generator.GenerateNextSpikeWihtGap();
          
          
        }
        if (collision.gameObject.CompareTag("FinishLine"))
        {
            Destroy(gameObject );
        }
       
        if (collision.gameObject.CompareTag("Player"))
        {
            playerLife.takeDamage(1);
        }
        
    }
}
    
