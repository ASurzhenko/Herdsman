using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentAnimalFactory : AnimalFactory
{
    public AnimalData animalData;
    public CurrentAnimalFactory(AnimalData animalData) => (this.animalData) = (animalData);
    public override IAnimal GetAnimal()
    {
        CurrentAnimal animal = new CurrentAnimal(animalData.AnimalPrefab, animalData.animalReward, animalData.animalSpeed);
        return animal;
    }
}