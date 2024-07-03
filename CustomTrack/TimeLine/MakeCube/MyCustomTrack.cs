using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


namespace mixyaoCustomTimeLineForGJ2024
{
    [TrackColor(0.855f, 0.8623f, 0.8705f)]
    [TrackClipType(typeof(MyCustomClip))]
     [TrackClipType(typeof(MyEventClip))]
    [TrackBindingType(typeof(Transform))]
    public class MyCustomTrack : TrackAsset
    {
        public TrackSettings trackSettings; // Reference to the ScriptableObject

        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var playable = ScriptPlayable<MyCustomMixerBehaviour>.Create(graph, inputCount);
            var behaviour = playable.GetBehaviour();

            // Get the bound Transform from the graph's resolver and assign it to the behaviour
            var playableDirector = go.GetComponent<PlayableDirector>();
            if (playableDirector != null)
            {
                var boundTransform = playableDirector.GetGenericBinding(this) as Transform;
                behaviour.parentTrack = boundTransform;
            }

            return playable;
        }
    }
}