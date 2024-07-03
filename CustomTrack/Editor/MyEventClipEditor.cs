using UnityEngine;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine.Timeline;

namespace mixyaoCustomTimeLineForGJ2024
{
    [CustomTimelineEditor(typeof(MyEventClip))]
    public class MyCustomEventEditor : ClipEditor
    {
        public override ClipDrawOptions GetClipOptions(TimelineClip clip)
        {
            var options = base.GetClipOptions(clip);

            MyEventClip myClip = clip.asset as MyEventClip;

            if (myClip != null && myClip.clipSettings != null)
            {
                Texture2D icon = myClip.clipSettings.icon != null
                    ? myClip.clipSettings.icon
                    : Resources.Load<Texture2D>(myClip.clipSettings.iconPath);
                if (icon != null)
                {
                    options.errorText = GetErrorText(clip);
                    options.hideScaleIndicator = true;
                    options.tooltip = "This is Test Clip";
                    options.highlightColor = myClip.clipSettings.color;
                    options.displayClipName = false;
                    options.icons = new Texture2D[] { icon };
                }
            }

            return options;
        }

        public override void DrawBackground(TimelineClip clip, ClipBackgroundRegion region)
        {
            MyEventClip myClip = clip.asset as MyEventClip;

            if (myClip != null && myClip.clipSettings != null)
            {
                // First render background color
                RenderBackGroundColor(myClip.clipSettings.color, region);

                // Second render background icon
                RenderBackGroundIcon(myClip.clipSettings.icon, myClip.clipSettings.size, myClip.clipSettings.iconPath,
                    region);
            }
        }

        void RenderBackGroundColor(Color clipColor, ClipBackgroundRegion region)
        {
            Color bgColor = clipColor;
            var bgSize = new Rect(region.position.x, region.position.y, region.position.width, region.position.height);
            EditorGUI.DrawRect(bgSize, bgColor);
        }

        void RenderBackGroundIcon(Texture2D clipIcon, float iconSize, string iconPath, ClipBackgroundRegion region)
        {
            Texture2D icon = clipIcon != null ? clipIcon : Resources.Load<Texture2D>(iconPath);
            if (icon != null)
            {
                // Calculate the desired icon size and position
                float iconWidth = iconSize; // Use a default size or define a custom size in MyCustomClip
                float iconHeight = iconSize; // Use a default size or define a custom size in MyCustomClip
                Rect iconRect = new Rect(region.position.x + (region.position.width - iconWidth) / 2,
                    region.position.y + (region.position.height - iconHeight) / 2,
                    iconWidth, iconHeight);
                // Draw the icon
                GUI.DrawTexture(iconRect, icon);
            }
        }
    }
}