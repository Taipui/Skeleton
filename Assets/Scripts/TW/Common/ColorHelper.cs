using UnityEngine.UI;


namespace TW.Common
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// 色に関するヘルパークラス.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public static class ColorHelper
    {
        //================================================================================
        // Methods.
        //================================================================================

        //--------------------------------------------------------------------------------
        // Public methods.
        //--------------------------------------------------------------------------------

        /// <summary>
        /// Alphaを設定する.
        /// </summary>
        /// <param name="image">Image.</param>
        /// <param name="alpha">アルファ値.</param>
        public static void SetAlpha(MaskableGraphic image, float alpha)
        {
            var color   = image.color;
            color.a     = alpha;
            image.color = color;
        }
    }
}
