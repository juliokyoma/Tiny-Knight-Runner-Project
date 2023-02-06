using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerAim : MonoBehaviour
{
    private GameObject player;

    public Vector3 mousePosition;
    public Vector3 vector3PlayerPosition;
    public Vector3 aimPosition;
    public float closeMouse;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        vector3PlayerPosition = Camera.main.ScreenToWorldPoint(this.transform.parent.position); 
        mousePosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);

        aimPosition.z = Vector3.Angle(vector3PlayerPosition, mousePosition);
        //transform.RotateAround(this.transform.parent.position, vec, 1);

        transform.LookAt(mousePosition,Vector3.forward);


        //transform.LookAt(mousePosition);
      

        //transform.Rotate(-5 * Time.deltaTime, 0,0);
        // input.mousePosition.x, Input.mousePosition.y, 5
      
    }
}
