using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnemy : MonoBehaviour
{
    private Transform _target;
    private float _speed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
            Destroy(gameObject);
    }

    public void SetDirection(Transform target, float speed)
    {
        _speed = speed;
        _target = target;
    }
}
