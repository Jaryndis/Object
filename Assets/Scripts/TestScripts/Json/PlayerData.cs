using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo playerInfo = new PlayerInfo();

        playerInfo.playerName = "Nuroh";
        playerInfo.playerAge = 24;
        playerInfo.isAlive = true;

        playerInfo.weapons = new string[] { "Sword", "Gun", "Bow", "Bullet" };

        playerInfo.newLoc.x = 10f;
        playerInfo.newLoc.y = 5f;

        string json = JsonUtility.ToJson(playerInfo);
        Debug.Log(json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//[System.Serializable]
public class PlayerInfo
{
    public string playerName;
    public int playerAge;
    public bool isAlive;

    public string[] weapons;

    public Location newLoc = new Location();
}

[System.Serializable]
public class Location
{
    public float x;
    public float y;
}