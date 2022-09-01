using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    public static int Scores{get; private set;}
    public static event Action<int> OnPlayerScoresChange;
    public static List<Animal> Animals{get; private set;}
    public static bool CanAddAnimal => Animals == null || Animals.Count < 5;
    public static void SetScores(int scores)
    {
        Scores += scores;
        OnPlayerScoresChange?.Invoke(Scores);
    } 
    public static void AddAnimal(Animal animal)
    {
        if(Animals == null)
            Animals = new List<Animal>();

        foreach (var item in Animals)
        {
            if(item == animal)
                return;
        }    

        Animals.Add(animal);    
    }
    public static void RemoveAnimal(Animal animal)
    {
        Animals.Remove(animal);
    }
}
