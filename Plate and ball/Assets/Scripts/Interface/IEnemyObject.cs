using System;
using UnityEngine;

public interface IEnemyObject 
{
    event Action ObjectDestroy;
    void ApplyDamage();
    AudioSource GetAudioSource();
}
