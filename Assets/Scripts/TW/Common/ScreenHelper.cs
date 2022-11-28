using UnityEngine;


namespace TW.Common
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// 画面に関するヘルパークラス.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public static class ScreenHelper
    {
        //================================================================================
        // Properties.
        //================================================================================

        /// <summary>
        /// 画面の横幅.
        /// </summary>
        public static float ScreenWidth => Screen.width;

        /// <summary>
        /// 画面の縦幅.
        /// </summary>
        public static float ScreenHeight => Screen.height;

        /// <summary>
        /// 画面の半分の横幅.
        /// </summary>
        public static float HalfScreenWidth => ScreenWidth / 2.0f;

        /// <summary>
        /// 画面の半分の縦幅.
        /// </summary>
        public static float HalfScreenHeight => ScreenHeight / 2.0f;

        /// <summary>
        /// アスペクト比.
        /// </summary>
        public static Vector2 AspectRate => MathHelper.GetAspectRate(ScreenWidth, ScreenHeight);

        /// <summary>
        /// 小さい方を1としたアスペクト比.
        /// </summary>
        public static Vector2 NormalizedAspectRate => MathHelper.GetNormalizedAspectRate(ScreenWidth, ScreenHeight);
    }
}
