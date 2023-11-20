using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnemy : MonoBehaviour
{
    private Transform _transform;
    private Transform _target;
    private float _speed;

    public void SetDirection(Transform target, float speed)
    {
        _speed = speed;
        _target = target;
    }

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _target.position, _speed * Time.deltaTime);

        if (_transform.position == _target.position)
            Destroy(gameObject);
    }
}
