using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitpointController : MonoBehaviour
{
    public float waitTime = 1f;

    public ActorControllerEvent onActorEnter;
    public ActorControllerEvent onActorExit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log($"name: {collider.gameObject.name} - tag: {collider.gameObject.tag}");

        if (collider.gameObject.tag == "Actor")
        {
            var actor = collider.gameObject.GetComponent<ActorController>();

            onActorEnter.Invoke(actor);

            actor.Stop();
        }
    }

    internal Vector3 GetPosition()
    {
        return transform.position;
    }
}

[System.Serializable]
public class ActorControllerEvent : UnityEvent<ActorController>
{
}
