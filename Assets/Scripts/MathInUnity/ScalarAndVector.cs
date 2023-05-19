using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalarAndVector : MonoBehaviour
{
    public Transform bot;

    public Vector2 position;
    public Vector2 velocity;
    public Vector3 direction;
    public float rotation;

    public float scalar;


    // Update is called once per frame
    void Update()
    {
        //bot.position = scalar * position;

        /*if(Input.GetKeyDown(KeyCode.V))
        {
            bot.GetComponent<Rigidbody>().velocity = velocity;
        }*/

        bot.rotation = Quaternion.Euler(0, 0, rotation);

        if(Input.GetKey(KeyCode.V))
        {
            bot.Translate(Vector2.right * velocity * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.M))
        {
            Debug.Log($"Distance from 0 - {position.magnitude}");
            Debug.Log($"Velocity magnitude is - {velocity.magnitude}");
            Debug.Log($"Direction magnitude is - {direction.magnitude}");
        }
    }
}
