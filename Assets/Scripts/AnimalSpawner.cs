using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private AnimalData[] animalDatas;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private float SpawnIntervalMin, SpawnIntervalMax;
    private Vector2 cubeSize;
    private Vector2 cubeCenter;
    private List<GameObject> animalsPool = new List<GameObject>();
    private int maxAnimalAmount = 8;
    private void Awake()
    {
        Transform cubeTrans = bc.GetComponent<Transform>();
        cubeCenter = cubeTrans.position;

        // Multiply by scale because it does affect the size of the collider
        cubeSize.x = cubeTrans.localScale.x * bc.size.x;
        cubeSize.y = cubeTrans.localScale.y * bc.size.y;
    }
    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while(true)
        {
            if(CanSpawn())
            {
                CurrentAnimalFactory animalFactory = new CurrentAnimalFactory(animalDatas[(Random.Range(0, animalDatas.Length))]);
                IAnimal animal = animalFactory.GetAnimal();
                GameObject animalObject = GetAnimalFromPool(animal);
                animalObject.transform.position = GetRandomPosition();
                if(Visability.IsTargetVisible(animalObject.transform.position))
                {
                    animalObject.SetActive(true);
                    Animal animalBehaviour = animalObject.GetComponent<Animal>();
                    animalBehaviour.SetUp(animal);
                }
            }
            yield return new WaitForSeconds(Random.Range(SpawnIntervalMin, SpawnIntervalMax));
        }
    }
    private Vector2 GetRandomPosition()
    {
        Vector2 randomPosition = new Vector2(Random.Range(-cubeSize.x / 2 + 0.5f, cubeSize.x / 2 - 0.5f), Random.Range(-cubeSize.y / 2 + 0.5f, cubeSize.y / 2 - 0.5f));
        return cubeCenter + randomPosition;
    }
    private GameObject GetAnimalFromPool(IAnimal animal)
    {
        for (int i = 0; i < animalsPool.Count; i++)
        {
            if(!animalsPool[i].activeInHierarchy)
            {
                return animalsPool[i];
            }
        }

        GameObject animalObject = Instantiate(animal.GetAnimalPrefab());
        animalsPool.Add(animalObject);
        return animalObject;
    }
    private bool CanSpawn()
    {
        return animalsPool.Count == 0 || animalsPool.Select(x => x).Where(x => x.activeInHierarchy).ToArray().Length < maxAnimalAmount;
    }
}
