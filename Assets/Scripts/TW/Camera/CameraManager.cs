using UnityEngine;
using UnityEngine.Assertions;

using System.Collections.Generic;


namespace TW.CameraControl
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// カメラのマネージャー.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public sealed class CameraManager : MonoBehaviour
    {
        //================================================================================
        // Definitions.
        //================================================================================

        /// <summary>
        /// カメラの種類.
        /// </summary>
        public enum CameraType : int
        {
            /// <summary>
            /// 固定.
            /// </summary>
            Static

            /// <summary>
            /// 全てのプレイヤーが収まるよう移動する.
            /// </summary>
          , Movable
        }

        //================================================================================
        // Fields.
        //================================================================================

        [SerializeField] private Camera               _mainCamera          = default;
        [SerializeField] private MultipleTargetCamera MultipleTargetCamera = default;

        //================================================================================
        // Properties.
        //================================================================================

        /// <summary>
        /// メインカメラ.
        /// </summary>
        public Camera MainCamera => _mainCamera;

        //================================================================================
        // Methods.
        //================================================================================

        //--------------------------------------------------------------------------------
        // Public methods.
        //--------------------------------------------------------------------------------

        /// <summary>
        /// 初期設定する.
        /// </summary>
        /// <param name="target">(対象をとる場合の)対象.</param>
        /// <param name="settings">カメラの設定.</param>
        public void Setup(Transform target = default, CameraSettings settings = default)
        {
            Setup(new List<Transform> { target }, settings);
        }

        /// <summary>
        /// 初期設定する.
        /// </summary>
        /// <param name="targets">(対象をとる場合の)対象.</param>
        /// <param name="settings">カメラの設定.</param>
        public void Setup(IReadOnlyList<Transform> targets, CameraSettings settings = default)
        {
            Assert.IsNotNull(MainCamera);
            Assert.IsNotNull(MultipleTargetCamera);

            settings ??= new CameraSettings();
            if (settings.CameraType == CameraType.Static)
            {
                MainCamera.transform.localPosition = settings.CameraPosition;
                MultipleTargetCamera.enabled       = false;
            }
            else
            {
                MultipleTargetCamera.Setup(targets, settings);
                MultipleTargetCamera.enabled = true;
            }
        }

        /// <summary>
        /// 毎フレーム呼ぶ.
        /// LateUpdateで呼ぶ.
        /// </summary>
        /// <param name="dt">deltaTime.</param>
        public void LateTick(float dt)
        {
            if (MultipleTargetCamera.enabled)
            {
                MultipleTargetCamera.LateTick(dt);
            }
        }
    }
}
