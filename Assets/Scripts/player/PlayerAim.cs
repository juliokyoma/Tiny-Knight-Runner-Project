using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerAim : MonoBehaviour
{
   

    public Vector2 mousePosition;
    public Vector2 vector2PlayerPosition;
    public Vector2 aimPosition;
    public float closeMouse;
    public float angle;
    public float angleplayermouse;
    private void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        vector2PlayerPosition = this.transform.parent.position;
        aimPosition = mousePosition - vector2PlayerPosition;

        
        angle = Mathf.Atan2(aimPosition.y, aimPosition.x) * Mathf.Rad2Deg * 90f ;
        
        
            RotateAim();

        //RotateAim();
        //transform.LookAt(mousePosition);
       //transform.Rotate(-5 * Time.deltaTime, 0,0);
        // input.mousePosition.x, Input.mousePosition.y, 5
      
    }
    void RotateAim()
    {
        transform.RotateAround(this.transform.parent.position, Vector3.forward, angle);
    }
    void uptadeMouseposition()
    {
        
    }
}
