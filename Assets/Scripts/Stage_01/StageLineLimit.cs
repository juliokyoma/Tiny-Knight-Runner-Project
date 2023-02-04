using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLineLimit : MonoBehaviour
{
    // Start is called before the first frame update
    public DestroyPlayer destroyPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            destroyPlayer.PlayerDie();
        }
    }
}
