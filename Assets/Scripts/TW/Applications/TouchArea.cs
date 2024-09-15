using UnityEngine;
using UnityEngine.Events;


namespace TW.Applications
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// タップ可能なエリア.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public sealed class TouchArea : MonoBehaviour
    {
        //================================================================================
        // Fields.
        //================================================================================

        /// <summary>
        /// タップ開始時のイベント.
        /// </summary>
        [SerializeField] private UnityEvent TapDownEvent = default;

        /// <summary>
        /// タップ終了時のイベント.
        /// </summary>
        [SerializeField] private UnityEvent TapUpEvent = default;

        //================================================================================
        // Methods.
        //================================================================================

        //--------------------------------------------------------------------------------
        // Public methods.
        //--------------------------------------------------------------------------------

        /// <summary>
        /// タップ開始時に呼ばれる.
        /// </summary>
        public void OnTapDown() => TapDownEvent?.Invoke();

        /// <summary>
        /// タップ終了時に呼ばれる.
        /// </summary>
        public void OnTapUp() => TapUpEvent?.Invoke();
    }
}

