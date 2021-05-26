using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefMovement : MonoBehaviour
{
    [SerializeField] private Transform _chest;
    [SerializeField] private  Transform _endPoint;
    [SerializeField] private float _speed;
    
    private Transform _target;

    private void Start()
    {
        _target = _chest;
    }

    private void Update()
    {
        Move(_target);
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.TryGetComponent<Chest>(out Chest chest))
        {
            _target = _endPoint;
        }
    }

    private void Move(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed*Time.deltaTime);  
    }
}