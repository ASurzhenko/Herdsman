using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public float Speed{get; private set;}
    public int Reward{get; private set;}
    public AnimalBehaviour Behaviour{get; private set;}
    public Transform target;
    private CircleCollider2D myCollider;
    private void Awake() {
        myCollider = GetComponent<CircleCollider2D>();
        Behaviour = GetComponent<AnimalBehaviour>();
    }
    public void SetUp(IAnimal animal)
    {
        Speed = animal.GetAnimalSpeed();
        Reward = animal.GetAnimalRewardScores();
    }
    private void Update() {
          

        if(!Visability.IsTargetVisible(transform.position))
        {
            ChangeDirection();
        }   
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "MainHero")
        {
            if(PlayerData.CanAddAnimal)
            {
                myCollider.isTrigger = false;
                target = other.transform;
                PlayerData.AddAnimal(this);
                Behaviour.SetBehaviourFollow();
            }
        }
        if(other.tag == "Yard" && target != null)
        {
            PlayerData.SetScores(Reward);
            PlayerData.RemoveAnimal(this);
            VFXEffector.Instance.CoinEffect(transform.position);
            ResetAnimal();
        }
        if(other.tag == "MoveBack" && target == null)
        {
            ChangeDirection();
        }
    }
    private void ChangeDirection()
    {
        if(Behaviour.BehaviourCurrent == Behaviour.GetBehaviour<AnimalBehaviourMoveLeft>())
            Behaviour.SetBehaviourMoveRight();
        else if(Behaviour.BehaviourCurrent == Behaviour.GetBehaviour<AnimalBehaviourMoveRight>())
            Behaviour.SetBehaviourMoveLeft();
        else if(Behaviour.BehaviourCurrent == Behaviour.GetBehaviour<AnimalBehaviourMoveUp>())
            Behaviour.SetBehaviourMoveDown();  
        else if(Behaviour.BehaviourCurrent == Behaviour.GetBehaviour<AnimalBehaviourMoveDown>())
            Behaviour.SetBehaviourMoveUp();      
    }
    private void ResetAnimal()
    {
        Behaviour.SetBehaviourIdle();
        target = null;
        myCollider.isTrigger = true;
        gameObject.SetActive(false);
    }
}
