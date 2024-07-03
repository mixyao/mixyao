using UnityEngine;

namespace mixyaoCustomTimeLineForGJ2024
{
    [CreateAssetMenu(fileName = "ClipSettings", menuName = "Custom Timeline/ClipSettings", order = 0)]
    public class ClipSettings : ScriptableObject
    {
        public ClipType clipType;

        [Header("Make Cube Settings")] //MakeCube--MyCustomClip
        public GameObject prefab;

        public AnimationClip animationClip;
        public bool justPutOut = false;
        public GameObject cube;

        [Header("Event Settings")] //EventInvoke--MyEventClip   Now,EventClip need not this
        [ReadOnly]
        public string message = "Need Not Do Now";

        [Header("Icon Settings")] // Always displayed//To All Clip
        public string iconPath;

        public Texture2D icon;
        public Color color = Color.gray;
        public float size = 16f;
    }

    public enum ClipType
    {
        MakeCube,
        Event
    }
}