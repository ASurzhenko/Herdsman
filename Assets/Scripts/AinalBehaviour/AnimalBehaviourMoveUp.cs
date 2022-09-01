using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviourMoveUp : IAnimalBehaviour
{
    private Animal animal;
    private AnimalBehaviour behaviour => animal.Behaviour;
    public void Enter(Animal animal)
    {
        this.animal = animal;
    }

    public void Exit()
    {
    }

    public void Update()
    {
        if(animal != null && behaviour.BehaviourCurrent == behaviour.GetBehaviour<AnimalBehaviourMoveUp>())
        {
            animal.transform.position += animal.transform.up * animal.Speed * Time.deltaTime;
        }
    }
}