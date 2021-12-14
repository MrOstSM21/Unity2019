using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyObject 
{
    event Action ObjectDestroy;
    void ApplyDamage();
}
