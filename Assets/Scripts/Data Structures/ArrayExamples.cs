using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayExamples : MonoBehaviour
{
    public GameObject testPrefab;

    public GameObject[] testArray;
    public int[] testIntArrays;

    public GameObject[] array = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        array[0] = Instantiate(testPrefab, transform);
        array[0].transform.position = new Vector2(0, 0);

        array[1] = Instantiate(testPrefab, transform);
        array[1].transform.position = new Vector2(1, 0);

        /*array[2] = Instantiate(testPrefab, transform);
        array[2].transform.position = new Vector2(2, 0);*/
    }

    // Update is called once per frame
    void Update()
    {
        //Pick random object and change the colour to a random colour.
        if(Input.GetKeyDown(KeyCode.R))
        {
            array[Random.Range(0, array.Length)].GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        }

        //Delete the first element of the array when the "0" key is pressed
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Destroy(array[0].gameObject);
            Debug.Log(array[0].name);
        }

        //Add object to the first element
        if(Input.GetKeyDown(KeyCode.W))
        {
            array[0] = Instantiate(testPrefab, transform);
            array[0].transform.position = new Vector2(0, 0);
        }
    }
}
