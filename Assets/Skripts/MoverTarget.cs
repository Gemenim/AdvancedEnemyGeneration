using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoverTarget : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    public void SetEndPosition(Vector3 position)
    {
        _endPosition = position;
    }

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _endPosition, _speed * Time.deltaTime);
        CheckPositoin();
    }

    private void CheckPositoin()
    {
        if (transform.position == _endPosition)
        {
            Vector3 temporaryPosition = _endPosition;
            _endPosition = _startPosition;
            _startPosition = temporaryPosition;
        }
    }
}
