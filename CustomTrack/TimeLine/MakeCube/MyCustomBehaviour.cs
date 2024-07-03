using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

namespace mixyaoCustomTimeLineForGJ2024
{
    // Defines the behavior for MyCustomClip, handling instantiation and animation playback during Timeline playback
    public class MyCustomBehaviour : PlayableBehaviour
    {
        public Transform parentTrack;
        public GameObject prefab;
        public AnimationClip animationClip;
        public bool justPutOut;
        public GameObject cube;
        private GameObject instance;
        private GameObject cubeInstance;
        private PlayableGraph playableGraph;
        private AnimationClipPlayable animationPlayable;
    
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            if (!Application.isPlaying)
            {
                return;
            }
    
            if (parentTrack == null)
            {
                Debug.LogError("parentTrack is null in MyCustomBehaviour.OnBehaviourPlay.");
                return;
            }
    
            if (prefab == null) return;
    
            instance = GameObject.Instantiate(prefab, parentTrack);
            instance.transform.localPosition = Vector3.zero;
    
            if (!justPutOut && animationClip != null)
            {
                Animator animator = instance.GetComponent<Animator>();
    
                if (cube != null)
                {
                    cubeInstance = GameObject.Instantiate(cube);
                    cubeInstance.transform.SetParent(instance.transform);
                    cubeInstance.transform.localPosition = Vector3.zero;
                }
    
                if (animator != null)
                {
                    playableGraph = PlayableGraph.Create();
                    animationPlayable = AnimationClipPlayable.Create(playableGraph, animationClip);
                    var output = AnimationPlayableOutput.Create(playableGraph, "Animation", animator);
                    output.SetSourcePlayable(animationPlayable);
                    playableGraph.Play();
                }
            }
        }
    
        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            if (!Application.isPlaying)
            {
                return;
            }
    
            if (instance != null)
            {
                GameObject.Destroy(instance);
                instance = null;
            }
    
            if (playableGraph.IsValid())
            {
                playableGraph.Destroy();
            }
        }
    
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if (!Application.isPlaying)
            {
                return;
            }
    
            if (animationClip != null && instance != null && animationPlayable.IsValid())
            {
                double clipDuration = playable.GetDuration();
                float animationLength = animationClip.length;
                float playbackSpeed = animationLength / (float)clipDuration;
    
                animationPlayable.SetSpeed(playbackSpeed);
            }
        }
    }

}
