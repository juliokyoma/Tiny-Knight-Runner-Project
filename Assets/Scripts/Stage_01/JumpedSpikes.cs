using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpedSpikes : MonoBehaviour
{
    
    public ScoreCounter scoreCounter;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scoreCounter.PlusPoints(100);
        }
    }
}
