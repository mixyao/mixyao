using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
namespace mixyaoCustomTimeLineForGJ2024
{
    [System.Serializable]

    public class MyCustomClip : PlayableAsset, ITimelineClipAsset
    {
        //public ExposedReference<Transform> parentTrack;
        public ClipSettings clipSettings; // 添加 ClipSettings 类型的字段

        public ClipCaps clipCaps => ClipCaps.None;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<MyCustomBehaviour>.Create(graph);
            var behaviour = playable.GetBehaviour();

            //behaviour.parentTrack = parentTrack.Resolve(graph.GetResolver());
            if (clipSettings != null)
            {
                behaviour.prefab = clipSettings.prefab;
                behaviour.animationClip = clipSettings.animationClip;
                behaviour.cube = clipSettings.cube;
                behaviour.justPutOut = clipSettings.justPutOut;
            }

            return playable;
        }
    }
}