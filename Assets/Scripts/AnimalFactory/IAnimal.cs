using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimal
{
    GameObject GetAnimalPrefab();
    float GetAnimalSpeed();
    int GetAnimalRewardScores();
}
