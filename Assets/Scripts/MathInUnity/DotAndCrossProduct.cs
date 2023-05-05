using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DotAndCrossProduct : MonoBehaviour
{
    public TrailRenderer bot1Line;
    public TrailRenderer bot2Line;
    public TrailRenderer crossProductLine;

    public Transform bot1, bot2;

    public bool isNormalize;

    public TMP_Text crossValue;

    Vector3 crossProduct;

    float dotProduct;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dotProduct = Vector2.Dot(bot1.position, bot2.position);
        Debug.Log($"Dot product = {dotProduct}");


        if (!isNormalize)
        {
            crossProduct = Vector3.Cross(bot1.position, bot2.position);
        }
        else
        {
            crossProduct = Vector3.Cross(bot1.position.normalized, bot2.position.normalized);
        }

        crossValue.SetText($"Cross : {crossProduct}");
    }
}
