using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityAuditor : MonoBehaviour
{
    [SerializeField] private GameObject _targetsArray;

    private GeneratorEnemy[] _enemyGenerator;
    private Target[] _targets;
    private float _cooldown = 2;

    private void Awake()
    {
        _enemyGenerator = GetComponentsInChildren<GeneratorEnemy>();
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
        for (int i = 0; i < _enemyGenerator.Length; i++)
        {
            _enemyGenerator[i].SetTarget(_targets[i]);
        }
    }

    private IEnumerator ChooseSpawner()
    {
        while (true)
        {
            if (CheckActivity())
            {
                int randomIndex = UnityEngine.Random.Range(0, _enemyGenerator.Length);
                _enemyGenerator[randomIndex].TurnOn();
            }

            var cooldown = new WaitForSeconds(_cooldown);
            yield return cooldown;
        }
    }

    private bool CheckActivity()
    {
        bool isVerified = true;

        foreach (GeneratorEnemy enemyGenerator in _enemyGenerator)
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