using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityAuditor : MonoBehaviour
{
    [SerializeField] private Transform _targetsArray;

    private EnemyGenerator[] _enemyGenerators;
    private Target[] _targets;
    private float _cooldown = 2;

    private void Awake()
    {
        _enemyGenerators = GetComponentsInChildren<EnemyGenerator>();
        _targets = _targetsArray.GetComponentsInChildren<Target>();
        SetTargets();
    }

    private void Start()
    {
        var chooseSpawnerJob = ChooseSpawner();
        StartCoroutine(chooseSpawnerJob);
    }

    private void SetTargets()
    {
        if (_targets.Length == _enemyGenerators.Length)
        {
            for (int i = 0; i < _enemyGenerators.Length; i++)
                _enemyGenerators[i].SetTarget(_targets[i]);
        }
        else if (_targets.Length > _enemyGenerators.Length)
        {
            foreach (EnemyGenerator enemyGenerator in _enemyGenerators)
            {
                int randomIndex = UnityEngine.Random.Range(0, _targets.Length);
                enemyGenerator.SetTarget(_targets[randomIndex]);
            }
        }
        else if (_targets.Length < _enemyGenerators.Length && _targets.Length > 0)
        {
            for (int i = 0; i < _enemyGenerators.Length; i++)
            {
                if (i < _targets.Length)
                    _enemyGenerators[i].SetTarget(_targets[i]);
                else
                    _enemyGenerators[i].SetTarget(_targets[i - _targets.Length]);
            }
        }
    }

    private IEnumerator ChooseSpawner()
    {
        while (true)
        {
            if (CheckActivity())
            {
                int randomIndex = UnityEngine.Random.Range(0, _enemyGenerators.Length);
                _enemyGenerators[randomIndex].TurnOn();
            }

            var cooldown = new WaitForSeconds(_cooldown);
            yield return cooldown;
        }
    }

    private bool CheckActivity()
    {
        bool isVerified = true;

        foreach (EnemyGenerator enemyGenerator in _enemyGenerators)
        {
            if (enemyGenerator.IsActiv)
            {
                isVerified = false;
                break;
            }
        }

        return isVerified;
    }
}