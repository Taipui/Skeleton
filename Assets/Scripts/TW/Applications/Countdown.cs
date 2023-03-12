using UnityEngine;
using UnityEngine.UI;

using System.Collections;

using TW.Common;


namespace TW.Applications
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// カウントダウンする.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public sealed class Countdown : MonoBehaviour
    {
        //================================================================================
        // Fields.
        //================================================================================

        /// <summary>
        /// カウントダウンのImage.
        /// </summary>
        [SerializeField] private Image Image = default;

        /// <summary>
        /// カウントダウンの画像.
        /// </summary>
        /// <remarks>
        /// 最後の画像はカウントダウン後に表示する画像.
        /// </remarks>
        [SerializeField] private Sprite[] Sprites = default;

        /// <summary>
        /// WaitForSecondsのキャッシュ.
        /// </summary>
        private WaitForSeconds Wfs = new(1.0f);

        //================================================================================
        // Methods.
        //================================================================================

        //--------------------------------------------------------------------------------
        // MonoBehaviour methods.
        //--------------------------------------------------------------------------------

        public void Reset()
        {
            ColorHelper.SetAlpha(Image, 0.0f);
        }

        //--------------------------------------------------------------------------------
        // Public methods.
        //--------------------------------------------------------------------------------

        /// <summary>
        /// カウントダウンするコルーチン.
        /// </summary>
        /// <param name="cb">カウントダウンが終わると呼ばれる.</param>
        public IEnumerator Do(System.Action cb = null)
        {
            ColorHelper.SetAlpha(Image, 1.0f);
            for (var i = 0; i < Sprites.Length - 1; ++i)
            {
                Image.overrideSprite = Sprites[i];
                Image.SetNativeSize();
                yield return Wfs;
            }

            Image.overrideSprite = Sprites[^1];
            Image.SetNativeSize();
            yield return Wfs;

            Reset();

            cb?.Invoke();
        }
    }
}

