using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigonometry : MonoBehaviour
{
    public Transform bot;

    public Vector2 startPos;
    public Vector2 amplitude;
    public Vector2 frequency;

    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sine();
        //Cos();
        //Tan();

        //Elipse();
    }

    void Sine()
    {
        float xpos = startPos.x = Time.timeSinceLevelLoad;
        float ypos = startPos.y + amplitude.y * Mathf.Sin(frequency.y * Time.timeSinceLevelLoad);

        bot.position = new Vector2(xpos, ypos);
    }

    void Cos()
    {
        float xpos = startPos.x = Time.timeSinceLevelLoad;
        float ypos = startPos.y + amplitude.y * Mathf.Cos(frequency.y * Time.timeSinceLevelLoad);

        bot.position = new Vector2(xpos, ypos);
    }

    void Tan()
    {
        float xpos = startPos.x = Time.timeSinceLevelLoad;
        float ypos = startPos.y + amplitude.y * Mathf.Tan(frequency.y * Time.timeSinceLevelLoad);

        bot.position = new Vector2(xpos, ypos);
    }

    void Elipse()
    {
        float xpos = startPos.x + amplitude.x * Mathf.Sin(frequency.x * Time.timeSinceLevelLoad);
        float ypos = startPos.y + amplitude.y * Mathf.Cos(frequency.x * Time.timeSinceLevelLoad);

        bot.position = new Vector2(xpos, ypos);

    }
}
