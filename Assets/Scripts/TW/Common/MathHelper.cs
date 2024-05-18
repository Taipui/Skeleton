using UnityEngine;


namespace TW.Common
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// 数学に関するヘルパークラス.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public static class MathHelper
    {
        //================================================================================
        // Methods.
        //================================================================================

        //--------------------------------------------------------------------------------
        // Public methods.
        //--------------------------------------------------------------------------------
    
        /// <summary>
        /// 最大公約数を取得する(int版).
        /// </summary>
        /// <param name="x">パラメータ.</param>
        /// <param name="y">パラメータ.</param>
        /// <returns>最大公約数.</returns>
        public static int Gcd(int x, int y)
        {
            if ((x == 0) || (y == 0))
            {
                return x;
            }

            return Gcd(y, x % y);
        }

        /// <summary>
        /// 最大公約数を取得する(float版).
        /// </summary>
        /// <param name="x">パラメータ.</param>
        /// <param name="y">パラメータ.</param>
        /// <returns>最大公約数.</returns>
        public static int Gcd(float x, float y) => Gcd((int)x, (int)y);

        /// <summary>
        /// アスペクト比を取得する.
        /// </summary>
        /// <param name="width">幅.</param>
        /// <param name="height">高さ.</param>
        /// <returns>アスペクト比.</returns>
        public static Vector2 GetAspectRate(float width, float height)
        {
            var gcd = Gcd(width, height);
            if (gcd == 0)
            {
                return Vector2.zero;
            }

            return new Vector2(width / gcd, height / gcd);

        }

        /// <summary>
        /// 小さい方を1としたアスペクト比を取得する.
        /// </summary>
        /// <param name="width">幅.</param>
        /// <param name="height">高さ.</param>
        /// <returns>小さい方を1としたアスペクト比.</returns>
        public static Vector2 GetNormalizedAspectRate(float width, float height)
        {
            if ((width == 0.0f) || (height == 0.0f))
            {
                return Vector2.zero;
            }

            var rate = GetAspectRate(width, height);
            if ((rate.x == 0.0f) || (rate.y == 0.0f))
            {
                return Vector2.zero;
            }

            if (rate.x > rate.y)
            {
                return new Vector2(rate.x / rate.y, 1.0f);
            }

            return new Vector2(1.0f, rate.y / rate.x);
        }

        /// <summary>
        /// 値を0～1に変換する.
        /// </summary>
        /// <param name="value">変換する値.</param>
        /// <param name="max">最大値.</param>
        /// <param name="min">最小値(指定がない場合は0).</param>
        /// <returns>0～1.</returns>
        public static float To01(int value, int max, int min = 0) => Mathf.InverseLerp(min, max, value);
        
        /// <summary>
        /// 値の範囲を別の範囲にマッピングする.
        /// </summary>
        /// <param name="value">変換する値.</param>
        /// <param name="minOld">古い最小値.</param>
        /// <param name="maxOld">古い最大値.</param>
        /// <param name="minNew">新しい最小値.</param>
        /// <param name="maxNew">新しい最大値.</param>
        /// <returns>再マッピング後の値.</returns>
        public static float Remap(float value, float minOld, float maxOld, float minNew, float maxNew)
        {
            var t = Mathf.InverseLerp(minOld, maxOld, value);
            return Mathf.Lerp(minNew, maxNew, t);
        }

        /// <summary>
        /// AnimationCurve による値を取得する.
        /// </summary>
        /// <param name="curve">AnimationCurve.</param>
        /// <param name="time">0～1.</param>
        /// <param name="max">最大値.</param>
        /// <param name="min">最小値(指定がない場合は0).</param>
        /// <returns>min < x < max.</returns>
        public static float GetValueByCurve(AnimationCurve curve, float time, float max, float min = 0.0f)
        {
            if (curve == null)
            {
                return 0.0f;
            }

            var ratio = curve.Evaluate(time);
            return Mathf.Lerp(min, max, ratio);
        }
    }
}
