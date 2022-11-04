using UnityEngine;


namespace TW.Animation
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// アニメーションのヘルパークラス.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public static class AnimationHelper
    {
        /// <summary>
        /// 現在のアニメーション名を返す.
        /// </summary>
        /// <param name="animator">Animator.</param>
        /// <returns>
        /// アニメーション名.
        /// 見つからなければstring.Emptyを返す.
        /// </returns>
        public static string GetCurrentAnimationName(Animator animator)
        {
            if (animator == null)
            {
                return string.Empty;
            }

            var info = animator.GetCurrentAnimatorClipInfo(0);
            if ((info == null) || (info.Length <= 0))
            {
                return string.Empty;
            }

            var clip = info[0].clip;
            if (clip == null)
            {
                return string.Empty;
            }
            
            return clip.name;
        }
    }
}
