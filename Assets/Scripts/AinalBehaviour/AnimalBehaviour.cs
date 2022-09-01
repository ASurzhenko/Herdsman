using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    private Dictionary<Type, IAnimalBehaviour> behavioursMap;
    public IAnimalBehaviour BehaviourCurrent{get; private set;}
    private float swithBehaviourTimer;
    private float swithTime;
    private void Start() {
        swithTime = UnityEngine.Random.Range(3f, 6f);
        InitBehaviours();
        SetBehaviourByDefault();
    }
    private void InitBehaviours()
    {
        behavioursMap = new Dictionary<Type, IAnimalBehaviour>();
        behavioursMap[typeof(AnimalBehaviourMoveLeft)] = new AnimalBehaviourMoveLeft();
        behavioursMap[typeof(AnimalBehaviourIdle)] = new AnimalBehaviourIdle();
        behavioursMap[typeof(AnimalBehaviourMoveRight)] = new AnimalBehaviourMoveRight();
        behavioursMap[typeof(AnimalBehaviourMoveUp)] = new AnimalBehaviourMoveUp();
        behavioursMap[typeof(AnimalBehaviourMoveDown)] = new AnimalBehaviourMoveDown();
        behavioursMap[typeof(AnimalBehaviourFollow)] = new AnimalBehaviourFollow();
    }
    private void SetBehaviour(IAnimalBehaviour newBehaviour)
    {
        if(BehaviourCurrent != null)
            BehaviourCurrent.Exit();

        BehaviourCurrent = newBehaviour;
        BehaviourCurrent.Enter(GetComponent<Animal>());
    }
    private void SetBehaviourByDefault()
    {
        SetBehaviourIdle();
    }
    public IAnimalBehaviour GetBehaviour<T>() where T : IAnimalBehaviour
    {
        var type = typeof(T);
        return behavioursMap[type];
    }
    private void Update() {
        if(BehaviourCurrent != null)
        {
            BehaviourCurrent.Update();

            if(BehaviourCurrent == GetBehaviour<AnimalBehaviourFollow>())
                return;

            swithBehaviourTimer += Time.deltaTime;
            if(swithBehaviourTimer >= swithTime)
            {
                swithTime = UnityEngine.Random.Range(3f, 6f);
                swithBehaviourTimer = 0;
                if(BehaviourCurrent != GetBehaviour<AnimalBehaviourIdle>())
                    SetBehaviourIdle();
                else
                    SetRandomMovementBehaviour();    
            }
        }    
    }
    private void SetRandomMovementBehaviour()
    {
        int rand = UnityEngine.Random.Range(0, 4);
        switch (rand)
        {
        case 0:
            SetBehaviourMoveLeft();
            break;
        case 1:
            SetBehaviourMoveRight();
            break;
        case 2:
            SetBehaviourMoveUp();
            break;
        default: SetBehaviourMoveDown();
            break;
        }
    }
    public void SetBehaviourIdle()
    {
        var behaviour = GetBehaviour<AnimalBehaviourIdle>();
        this.SetBehaviour(behaviour);
    }
    public void SetBehaviourMoveLeft()
    {
        var behaviour = GetBehaviour<AnimalBehaviourMoveLeft>();
        this.SetBehaviour(behaviour);
    }
    public void SetBehaviourMoveRight()
    {
        var behaviour = GetBehaviour<AnimalBehaviourMoveRight>();
        this.SetBehaviour(behaviour);
    }
    public void SetBehaviourMoveUp()
    {
        var behaviour = GetBehaviour<AnimalBehaviourMoveUp>();
        this.SetBehaviour(behaviour);
    }
    public void SetBehaviourMoveDown()
    {
        var behaviour = GetBehaviour<AnimalBehaviourMoveDown>();
        this.SetBehaviour(behaviour);
    }
    public void SetBehaviourFollow()
    {
        var behaviour = GetBehaviour<AnimalBehaviourFollow>();
        this.SetBehaviour(behaviour);
    }
}
