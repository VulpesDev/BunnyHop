using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard_Text : MonoBehaviour
{
    Camera m_Camera;
    private void Start()
    {
        m_Camera = Camera.main;
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
