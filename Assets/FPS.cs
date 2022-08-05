using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private float m_avgFrameRate;

    public void Update()
    {
        m_avgFrameRate = Time.frameCount / Time.time;
        Debug.Log($"avgFrameRate: {m_avgFrameRate}");
    }
}
