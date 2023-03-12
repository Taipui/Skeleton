using UnityEngine;

using System.Collections;


namespace TW.Countdown.Test
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// Countdownのサンプル.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public sealed class CountdownSample : MonoBehaviour
    {
        //================================================================================
        // Fields.
        //================================================================================

        /// <summary>
        /// カウントダウンのクラス.
        /// </summary>
        [SerializeField] private Applications.Countdown Countdown = default;

        //================================================================================
        // Methods.
        //================================================================================

        //--------------------------------------------------------------------------------
        // MonoBehaviour methods.
        //--------------------------------------------------------------------------------

        private IEnumerator Start()
        {
            yield return Countdown.Do(() => Debug.Log("Countdown is over"));
        }
    }
}
