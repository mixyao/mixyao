using UnityEngine;
using UnityEngine.Playables;
using System.Collections.Generic;

namespace mixyaoCustomTimeLineForGJ2024
{
    public class MyCustomMixerBehaviour : PlayableBehaviour
    {
        public Transform parentTrack;

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            int inputCount = playable.GetInputCount();

            for (int i = 0; i < inputCount; i++)
            {
                var inputPlayable = (ScriptPlayable<MyCustomBehaviour>)playable.GetInput(i);
                var inputBehaviour = inputPlayable.GetBehaviour();

                // Assign the parent track to each input behaviour
                inputBehaviour.parentTrack = parentTrack;

                if (parentTrack == null)
                {
                    Debug.LogWarning("parentTrack is null in MyCustomMixerBehaviour.");
                }
            }
        }
    }
}