using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentAnimal : IAnimal
{
    private GameObject animalPrefab;
    private int animalReward;
    private float animalSpeed;
    public CurrentAnimal(GameObject animalPrefab, int animalReward, float animalSpeed) => 
        (this.animalPrefab, this.animalReward, this.animalSpeed) = (animalPrefab, animalReward, animalSpeed);
    public GameObject GetAnimalPrefab() => animalPrefab;
    public int GetAnimalRewardScores() => animalReward;
    public float GetAnimalSpeed() => animalSpeed;
}
