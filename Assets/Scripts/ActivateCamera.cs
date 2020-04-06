using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ActivateCamera : MonoBehaviour
{
    CinemachineVirtualCamera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }

    public void Activate()
    {
        _camera.Priority = 20;
    }

    public void DeActivate()
    {
        _camera.Priority = 0;
    }
}
