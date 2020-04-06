using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActorController : MonoBehaviour
{
    public WaitpointController[] waitpoints;
    public float loopTime = 0.5f;
    public float startTime = 3;

    Rigidbody _rigidBody;
    Animator _animator;
    NavMeshAgent _agent;

    WaitpointController _currentWaitpoint;
    int _waitPoint = -1;
    float _nextTime = -1;
    bool _waitNext = true;
    bool _stopped = false;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

        _nextTime = Time.time + startTime;
        _waitNext = true;

        StartCoroutine(MainLoop());
    }

    IEnumerator MainLoop() 
    {
        while (true)
        {
            yield return new WaitForSeconds(loopTime);

            if (!_stopped && _waitNext && _nextTime < Time.time && waitpoints.Length > 0)
            {
                _waitNext = false;
                _waitPoint++;
                _currentWaitpoint = waitpoints[_waitPoint];
                _agent.destination = _currentWaitpoint.GetPosition();
            }
        }

    }

    internal void Stop()
    {
        _agent.destination = transform.position;
        
        _rigidBody.velocity = new Vector3(0f, 0f, 0f);
        _rigidBody.angularVelocity = new Vector3(0f, 0f, 0f);

        _stopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log($"Walking = {(_rigidBody.velocity.magnitude > 0.001f)}");

        _animator.SetBool("Walking", !_waitNext && !_stopped);
    }

    // void OnAnimatorMove()

    internal void NextWaitpoint(float waitTime)
    {
        _nextTime = Time.time + waitTime;
        _waitNext = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"name: ${collision.gameObject.name} - tag: ${collision.gameObject.tag}");
    }
}
