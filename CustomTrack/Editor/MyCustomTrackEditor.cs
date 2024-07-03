using UnityEngine;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine.Timeline;
namespace mixyaoCustomTimeLineForGJ2024
{
[CustomTimelineEditor(typeof(MyCustomTrack))]
public class MyCustomTrackEditor : TrackEditor
{
    public override TrackDrawOptions GetTrackOptions(TrackAsset track, UnityEngine.Object binding)
    {
        var options = base.GetTrackOptions(track, binding);
        MyCustomTrack myTrack = track as MyCustomTrack;

        if (myTrack != null && myTrack.trackSettings != null)
        {
            // Use the custom track color
            options.trackColor = myTrack.trackSettings.trackColor;

            // Load the track icon from Resources
            if (myTrack.trackSettings.trackIcon == null && !string.IsNullOrEmpty(myTrack.trackSettings.trackIconPath))
            {
                myTrack.trackSettings.trackIcon = Resources.Load<Texture2D>(myTrack.trackSettings.trackIconPath);
            }

            options.icon = myTrack.trackSettings.trackIcon;
        }

        return options;
    }

    public override void OnCreate(TrackAsset track, TrackAsset copiedFrom)
    {
        track.name = "MyCustomTrack";
        base.OnCreate(track, copiedFrom);
    }
}
}