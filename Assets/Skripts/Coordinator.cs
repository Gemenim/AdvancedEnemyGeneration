using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinator : MonoBehaviour
{
    private MoverTarget[] _moverTargets;
    private float _maxCoordinataX = 6.9f;
    private float _maxCoordinataY = 4.45f;
    private float _minCoordinataX = -9.9f;
    private float _minCoordinataY = 4.45f;

    private void Awake()
    {
        _moverTargets = GetComponentsInChildren<MoverTarget>();

        foreach (MoverTarget moverTarget in _moverTargets)
        {
            float positionX = Random.Range(_maxCoordinataX, _minCoordinataX);
            float positionY = Random.Range(_maxCoordinataY, _minCoordinataY);
            Vector3 position = new Vector3(positionX, positionY, 0);
            moverTarget.SetEndPosition(position);
        }
    }
}
