using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public Rigidbody2D rig_enemy;
    public float speed;
    public float enemy_direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rig_enemy.velocity = new Vector2 (enemy_direction * speed, 0);
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("colision_enemy") && enemy_direction == 1 )
        {
            enemy_direction = -1;   
        }   
        else if (other.gameObject.CompareTag("colision_enemy")) 
        {
            enemy_direction = 1;
        }
    }
} 