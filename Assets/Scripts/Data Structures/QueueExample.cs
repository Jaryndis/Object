using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueExample : MonoBehaviour
{
    public GameObject testPrefab;
    public Queue<GameObject> queue = new Queue<GameObject>();

    GameObject tempObj;
    Vector2 lastEnquedPostition = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            tempObj = Instantiate(testPrefab, transform);
            tempObj.transform.position = new Vector2(lastEnquedPostition.x + 1, 0);

            tempObj.name = "QUEUED-" + queue.Count;
            tempObj.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            queue.Enqueue(tempObj);
            lastEnquedPostition = tempObj.transform.position;

            Debug.Log("Enqued " + tempObj.name);
        }


        if(Input.GetKeyDown(KeyCode.X))
        {
            var removedObj = queue.Dequeue();
            Destroy(removedObj);
            Debug.Log("Dequed from the queue :" + removedObj);
        }
    }
}
