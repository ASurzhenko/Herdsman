using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Animal")]
public class AnimalData : ScriptableObject
{
    public GameObject AnimalPrefab;
    public int animalReward;
    public float animalSpeed;
}
