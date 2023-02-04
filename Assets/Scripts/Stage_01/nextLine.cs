using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLine : MonoBehaviour
{
    Generator generator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            generator.GenerateSpike();
            Destroy(gameObject);
            Debug.Log("esta colidindo com spike");
        }
    }

}
