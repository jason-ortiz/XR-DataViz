using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.XR.Interaction.Toolkit;

public class Play : MonoBehaviour
{
    private PlayableDirector m_playableDirector;

    void Start()
    {
        m_playableDirector = GetComponent<PlayableDirector>();
    }

    void Update()
    {
    }

    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        if (args.interactor.CompareTag("RightController"))
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
    }

    /*[RequireComponent(typeof(PlayableDirector))]
public class ReversePlayback : MonoBehaviour {
    private PlayableDirector director;
 
    // Use this for initialization
    void Start() {
        director = GetComponent<PlayableDirector>();
        director.Stop();
        director.time = director.playableAsset.duration - 0.01;
        director.Evaluate();
    }
 
    // Update is called once per frame
    void Update() {
        double t = director.time - Time.deltaTime;
        if (t < 0)
            t = 0;
 
        director.time = t;
        director.Evaluate();
 
        if (t == 0) {
            director.Stop();
            enabled = false;
        }
    }
} */
}
