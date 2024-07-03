using UnityEngine;

namespace mixyaoCustomTimeLineForGJ2024
{
    [CreateAssetMenu(fileName = "TrackSettings", menuName = "Custom Timeline/TrackSettings", order = 1)]
    public class TrackSettings : ScriptableObject
    {
        // Custom properties for track background color and icon
        public Color trackColor = Color.gray;
        public Texture2D trackIcon;
        public string trackIconPath; // Path to load the track icon from Resources
    }
}