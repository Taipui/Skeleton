using UnityEngine;
using UnityEngine.Rendering;

namespace TW.PostProcessing
{
    public class Fade : VolumeComponent, IPostProcessComponent
    {
        public bool IsActive() => true;
        
        public ClampedFloatParameter Ratio = new ClampedFloatParameter(0f, 0f, 1f);
        
        public ColorParameter Color = new ColorParameter(new Color(0f, 0f, 0f, 0f));
    }
}
