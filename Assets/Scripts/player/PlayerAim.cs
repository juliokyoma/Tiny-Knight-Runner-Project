using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerAim : MonoBehaviour
{
    public Vector3 mousePosition;
    public float closeMouse;
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       mousePosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
       transform.RotateAround(this.transform.parent.position, Vector3.forward, 1f);
       transform.LookAt(mousePosition);


        //transform.Rotate(-5 * Time.deltaTime, 0,0);
        // input.mousePosition.x, Input.mousePosition.y, 5
      
    }
}
