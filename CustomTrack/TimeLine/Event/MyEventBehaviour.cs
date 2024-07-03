using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

namespace mixyaoCustomTimeLineForGJ2024
{
    public class MyEventBehaviour : PlayableBehaviour
    {
        public UnityEvent onClipStart; // 定义剪辑开始时调用的事件
        public UnityEvent onClipEnd; // 定义剪辑结束时调用的事件
        public UnityEvent onClipPlay; // Clip在播放时一直调用

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            onClipStart?.Invoke(); // 播放时触发剪辑开始事件
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            onClipPlay?.Invoke();
            base.ProcessFrame(playable, info, playerData);
        }


        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            onClipEnd?.Invoke(); // 暂停时触发剪辑结束事件
        }
    }
}