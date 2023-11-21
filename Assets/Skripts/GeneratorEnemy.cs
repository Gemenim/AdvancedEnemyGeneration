using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorEnemy : MonoBehaviour
{
    [SerializeField] private MoverEnemy _enemy;
    [SerializeField] private float _cooldown;

    private Target _target;
    private bool _isActiv = false;
    private float _speedEnemy = 2.0f;

    public bool IsActiv => _isActiv;

    public void TurnOn()
    {
        _isActiv = true;
    }

    public void SetTarget(Target target)
    {
        _target = target;
    }

    private void Start()
    {      
        var creatEnemyJob = CreatEnemy();
        StartCoroutine(creatEnemyJob);
    }

    private IEnumerator CreatEnemy()
    {
        while (true)
        {
            if (_isActiv)
            {
                var newEnemy = Instantiate(_enemy, transform.position, Quaternion.identity);
                newEnemy.SetDirection(_target.transform, _speedEnemy);
                _isActiv = false;
            }

            var coldown = new WaitForSeconds(_cooldown);
            yield return coldown;
        }
    }
}
