using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.XR.Interaction.Toolkit;

public class Play : MonoBehaviour
{
    private PlayableDirector m_playableDirector;
    private bool m_isReverse = false;
    private bool m_isPaused = false;

    void Start()
    {
        m_playableDirector = GetComponent<PlayableDirector>();
    }

    void Update()
    {
        if (m_isReverse && !m_isPaused)
        {
            double currentTime = m_playableDirector.time - Time.deltaTime;
            if (currentTime < 0)
            {
                currentTime = 0;
            }

            m_playableDirector.time = currentTime;
            m_playableDirector.Evaluate();

            if (currentTime == 0)
            {
                // Loop around
                m_playableDirector.time = m_playableDirector.playableAsset.duration - 0.01;
            }
        }
    }

    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        // Play/Pause
        if (args.interactor.CompareTag("RightController"))
        {
            if (!m_isReverse)
            {
                switch (m_playableDirector.state)
                {
                    case PlayState.Playing: 
                        m_playableDirector.Pause();
                        return;
                    case PlayState.Paused:
                        m_playableDirector.Resume();
                        return;
                }
            }
            else
            {
                m_isPaused = !m_isPaused;
                if (m_isPaused)
                {
                    m_playableDirector.Pause();
                }
            }
        }
        // Reverse/Un-reverse
        else if (args.interactor.CompareTag("LeftController"))
        {
            m_isReverse = !m_isReverse;
            m_isPaused = false; // always unpause when reversing
            if (m_isReverse)
            {
                m_playableDirector.Pause(); // pause PlayableDirector to allow for manual playback evaulation
            }
            else
            {
                m_playableDirector.Resume(); // give control back to PlayableDirector
            }
        }
    }
}
