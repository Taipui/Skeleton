using UnityEngine;

using TW.Common;


namespace TW.Math.Test
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// MathHelperのAnimationCurve関連のテスト.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public class AnimationCurveTest : MonoBehaviour
    {
        //================================================================================
        // Fields.
        //================================================================================

        [SerializeField]                    private AnimationCurve Curve = default;
        [SerializeField]                    private float          Min   = 0.0f;
        [SerializeField]                    private float          Max   = 1.0f;
        [SerializeField, Range(0.0f, 1.0f)] private float          Value = 0.5f;

        //================================================================================
        // Methods.
        //================================================================================

        //--------------------------------------------------------------------------------
        // MonoBehaviour methods.
        //--------------------------------------------------------------------------------

        private void Update()
        {
            var ratio = MathHelper.GetValueByCurve(Curve, Value, Max, Min);
            Debug.Log(ratio);
        }
    }
}
