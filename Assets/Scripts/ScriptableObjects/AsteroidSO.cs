using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Asteroid")]

public class AsteroidSO : ScriptableObject
{
    [SerializeField] private int _waveNum;
    [SerializeField] private int _bulletsNeeded;
    [SerializeField] private float _speed;

    public int WaveNum => _waveNum;

    public int BulletsNeeded => _bulletsNeeded;

    public float Speed => _speed; 
}
