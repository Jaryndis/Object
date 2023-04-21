using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : Person
{
    public enum WeaponType
    {
        Melee = 2,
        Axe = 12,
        Sword = 22,
        Gun = 32,
        BowAndArrow = 42
    }
    // Start is called before the first frame update
    void Start()
    {
        PersonDetails();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Eat()
    {
        base.Eat();
    }
    void PersonDetails()
    {
        name = "Dog";

        Person personalPerson = new Person();
        Person myFriend = new Person();
        Person eldestSon = new Person();

        myFriend.name = "John";
        myFriend.age = 27;
        myFriend.address = "57, Wick Street";
        myFriend.height = 1.6f;

        eldestSon.name = "Mike";
        eldestSon.age = 25;
        eldestSon.address = "UK";
        eldestSon.height = 1.75f;

        eldestSon.Eat();

        //personalPerson.Walk();

        Debug.Log(personalPerson.name + " is " + personalPerson.age + " years old and lives at " + personalPerson.address);
    }
}
