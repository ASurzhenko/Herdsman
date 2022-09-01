using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviourFollow : IAnimalBehaviour
{
    Animal animal;
    public void Enter(Animal animal)
    {
        this.animal = animal;
    }

    public void Exit()
    {
    }

    public void Update()
    {
        if(animal.target != null)
        {
            if(Vector2.Distance(animal.transform.position, animal.target.position) > 0.5f)
                animal.transform.position = Vector2.MoveTowards(animal.transform.position, animal.target.position, animal.Speed * Time.deltaTime);
        }   
    }
}
