using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public float timeScale;
    public Transform bot1;
    public Transform bot2;
    public Transform bot3, pointA, pointB, pointC;

    [Range(0f, 1f)]
    public float timer = 0;

    public bool isAuto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBot1();
        MoveBot2();
        MoveBot3();
        
        if(!isAuto)
        {
            return;
        }

        timer += timeScale * Time.deltaTime;
        if(timer > 1)
        {
            timer = 0;
        }
    }

    void MoveBot1()
    {
        bot1.position = Vector2.Lerp(pointA.position, pointB.position, timer);
    }

    void MoveBot2()
    {
        bot2.position = Vector2.Lerp(pointB.position, pointC.position, timer);
    }

    void MoveBot3()
    {
        bot3.position = Vector2.Lerp(bot1.position, bot2.position, timer);
    }
}
