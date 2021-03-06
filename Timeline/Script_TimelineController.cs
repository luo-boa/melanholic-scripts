﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Script_TimelineController : MonoBehaviour
{
    public List <PlayableDirector> playableDirectors;
    public List <TimelineAsset> timelines;

    /// <summary>
    /// used when the gameObject is the playerDirector 
    /// </summary>
    public void PlayableDirectorPlay(int i)
    {
        playableDirectors[i].Play();
    }

    public void PlayAllPlayables()
    {
        foreach (PlayableDirector playable in playableDirectors)
        {
            playable.Play();
        }
    }

    public void StopAllPlayables()
    {
        foreach (PlayableDirector playable in playableDirectors)
        {
            if (playable.state == PlayState.Playing)
            {
                print($"playable {playable} is playing, stopping now.");
                playable.time = 0f;
                playable.Stop();
            }
        }
    }

    /// <summary>
    /// used when we have multiple timelines we want to manage
    /// e.g. KTVApproach, KTV Exit
    /// </summary>
    public PlayableDirector PlayableDirectorPlayFromTimelines(int playableDirectorIdx, int timelineIdx)
    {
        TimelineAsset selectedAsset;

        if (timelines.Count <= timelineIdx)     selectedAsset = timelines[timelines.Count - 1];
        else                                    selectedAsset = timelines[timelineIdx];

        print("playing asset: " + selectedAsset);
        playableDirectors[playableDirectorIdx].Play(selectedAsset);

        return playableDirectors[playableDirectorIdx];
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Script_TimelineController))]
public class Script_TimelineControllerTester : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        Script_TimelineController timelineController = (Script_TimelineController)target;
        if (GUILayout.Button("Test Binding"))
        {
            // timelineController.BindTimelineTracks(timelineController.timelines[1]);
        }
    }
}
#endif

