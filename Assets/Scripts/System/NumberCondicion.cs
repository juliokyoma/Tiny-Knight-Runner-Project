using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumberCondicion : MonoBehaviour
{
    float numBefore;
    float currentNumber;
    void Start()
    {
        
    }

    
    public void  IfNumberChangeDo(float Number, UnityAction action)
    {
        
       

        currentNumber = Number;
        
        
        if (numBefore != currentNumber)
        {
            action.Invoke();
            numBefore = currentNumber;
        }
        numBefore = currentNumber;
    }
    void Update()
    {
        
    }
}
