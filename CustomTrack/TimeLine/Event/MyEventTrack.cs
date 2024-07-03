using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace mixyaoCustomTimeLineForGJ2024
{
    [TrackColor(0.8f, 0.8f, 0.2f)]
    [TrackClipType(typeof(MyEventClip))]
    public class MyEventTrack : TrackAsset
    {

        public TrackSettings trackSettings; // Reference to the ScriptableObject

        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var playable = ScriptPlayable<MyEventMixerBehaviour>.Create(graph, inputCount);
            return playable;
        }
    }
}