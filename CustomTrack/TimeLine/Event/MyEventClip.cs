using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

namespace mixyaoCustomTimeLineForGJ2024
{
    [System.Serializable]
    public class MyEventClip : PlayableAsset
    {
        [Header("Event from Scene")] public ExposedReference<UnityEventHolder> unityEventHolder;
        public ClipSettings clipSettings; // 添加 ClipSettings 类型的字段

        [Header("Event from Assets")] public bool useAssetEvent = false;
        public UnityEvent onStart;
        public UnityEvent onEnd;
        public UnityEvent onPlay;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<MyEventBehaviour>.Create(graph);
            var behaviour = playable.GetBehaviour();

            if (useAssetEvent)
            {
                behaviour.onClipStart = onStart;
                behaviour.onClipEnd = onEnd;
                behaviour.onClipPlay = onPlay;
            }
            else
            {
                var resolver = graph.GetResolver();
                var eventHolder = unityEventHolder.Resolve(resolver);

                if (eventHolder != null)
                {
                    behaviour.onClipStart = eventHolder.onClipStart;
                    behaviour.onClipEnd = eventHolder.onClipEnd;
                    behaviour.onClipPlay = eventHolder.onClipPlay;
                }
                else
                {
                    Debug.LogWarning("UnityEventHolder reference not resolved. No events assigned.");
                }
            }

            return playable;
        }
    }
}