using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] transforms;
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float waitingTime = 5;
    private int _countOfElements;
    private Transform _unitTransform;
    private int _index = 0;
    private float _walkingTime;

    private void Start()
    {
        _unitTransform = transform;
        _countOfElements = transforms.Length;
    }

    private void CheckPosition()
    {
        if (_unitTransform.position == transforms[_index].position)
        {
            _walkingTime += Time.deltaTime;
            if (_walkingTime >= waitingTime)
            {
                _index++;
                _walkingTime = 0;
            }
        }

        if (_index == _countOfElements)
        {
            _index = 0;
            _walkingTime = 0;
        }
    }

    private void Update()
    {
        _unitTransform.LookAt(transforms[_index]);
        var position = Vector3.MoveTowards(_unitTransform.position, transforms[_index].position,
            movementSpeed * Time.deltaTime);
        _unitTransform.position = position;
        CheckPosition();
    }
}