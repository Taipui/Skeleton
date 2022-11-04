using UnityEngine;

using System.Collections;


namespace TW.Animation.Test
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// TW.Animationのテスト.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public sealed class AnimationTest : MonoBehaviour
    {
        //================================================================================
        // Fields.
        //================================================================================

        [SerializeField] private Animator Animator = default;

        //================================================================================
        // Methods.
        //================================================================================

        //--------------------------------------------------------------------------------
        // MonoBehaviour methods.
        //--------------------------------------------------------------------------------

        private IEnumerator Start()
        {
            while (true)
            {
                yield return null;
                yield return new WaitForAnimation(Animator, 0);

                Debug.Log("アニメーション終了");
            }
        }

        private void Update()
        {
            var animationName = AnimationHelper.GetCurrentAnimationName(Animator);
            Debug.Log($"現在のアニメーション名: {animationName}");
        }
    }
}
