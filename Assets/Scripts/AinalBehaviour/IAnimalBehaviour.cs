using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimalBehaviour
{
    void Enter(Animal animal);
    void Exit();
    void Update();
}
