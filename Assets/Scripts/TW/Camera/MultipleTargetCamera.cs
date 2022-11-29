using UnityEngine;
using UnityEngine.Assertions;

using System.Collections.Generic;
using System.Linq;

using TW.Common;


namespace TW.CameraControl
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// 【Unity】スマブラのように複数のオブジェクトが画面内に収まるようにカメラを制御する - コガネブログ.
    /// http://baba-s.hatenablog.com/entry/2017/12/29/145000
    /// </summary>
    /// <remarks>
    /// カメラにアタッチする.
    /// </remarks>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    [RequireComponent(typeof(Camera))]
    public sealed class MultipleTargetCamera : MonoBehaviour
    {
        //================================================================================
        // Fields.
        //================================================================================

        [SerializeField] private Camera  Camera          = default;
        [SerializeField] private Vector3 Offset          = Vector3.zero;
        [SerializeField] private float   SmoothTime      = 0.5f;
        [SerializeField] private float   MinZoom         = 40.0f;
        [SerializeField] private float   MaxZoom         = 10.0f;
        [SerializeField] private float   ZoomLimit       = 50.0f;
        [SerializeField] private Vector3 Velocity        = Vector3.zero;
        [SerializeField] private float   FollowThreshold = 0.0f;
        [SerializeField] private bool    Is2D            = false;

        private float           TargetDistance   = 0.0f;
        private List<Transform> Targets          = new();
        private float           CurrentZoomLimit = 0.0f;

        //================================================================================
        // Methods.
        //================================================================================

        //--------------------------------------------------------------------------------
        // Public methods.
        //--------------------------------------------------------------------------------

        /// <summary>
        /// 初期設定する.
        /// </summary>
        /// <param name="targets">画面内に収める対象.</param>
        /// <param name="settings">カメラの設定.</param>
        public void Setup(IReadOnlyList<Transform> targets, CameraSettings settings)
        {
            Assert.IsNotNull(targets);
            Assert.IsNotNull(settings);
            Assert.AreEqual(settings.CameraType, CameraManager.CameraType.Movable);

            Targets                   = targets.ToList();
            Camera.transform.rotation = Quaternion.Euler(settings.CameraRotation);
            Offset                    = settings.CameraOffset ?? Offset;
            MinZoom                   = settings.MinZoom      ?? MinZoom;
            MaxZoom                   = settings.MaxZoom      ?? MaxZoom;
            ZoomLimit                 = settings.ZoomLimit    ?? ZoomLimit;
        }

        /// <summary>
        /// 毎フレーム呼ぶ.
        /// LateUpdateで呼ぶ.
        /// </summary>
        /// <param name="dt">deltaTime.</param>
        public void LateTick(float dt)
        {
            if (ShouldFollow())
            {
                Move();
                Zoom(dt);
            }

            /// <summary>
            /// 対象を画面内に収められるか？
            /// </summary>
            /// <returns>画面内に収める対象がいればtrue.</returns>
            bool ShouldFollow()
            {
                if (Targets.Count == 0)
                {
                    TargetDistance = 0.0f;
                    return false;
                }

                if (Targets.Count == 1)
                {
                    var targetPosition = Targets[0].position;
                    var cameraPosition = transform.position - Offset;
                    if (Is2D)
                    {
                        cameraPosition.z = 0.0f;
                    }
                    TargetDistance = Vector3.Distance(targetPosition, cameraPosition);
                    return TargetDistance >= FollowThreshold;
                }

                TargetDistance = 0.0f;

                return true;
            }

            /// <summary>
            /// カメラを移動させる.
            /// </summary>
            void Move()
            {
                var centerPoint    = GetCenterPoint();
                var newPosition    = centerPoint + Offset;
                var targetPosition = Vector3.SmoothDamp(transform.position, newPosition, ref Velocity, SmoothTime);
                if (Is2D)
                {
                    targetPosition.z = -1.0f;
                }
                transform.position = targetPosition;

                /// <summary>
                /// 全ての対象が収まるカメラの中心点を返す.
                /// </summary>
                /// <returns>中心点の座標.</returns>
                Vector3 GetCenterPoint()
                {
                    if (Targets.Count == 1)
                    {
                        return Targets[0].position;
                    }

                    var bounds = GetEncapsulatedBounds();
                    return bounds.center;
                }
            }

            /// <summary>
            /// ズームする.
            /// </summary>
            /// <param name="dt">deltaTime.</param>
            void Zoom(float dt)
            {
                var newZoom = Mathf.Lerp(MaxZoom, MinZoom, GetGreatestDistance() / CurrentZoomLimit);
                
                if (Is2D)
                {
                    Camera.orthographicSize = Mathf.Lerp(Camera.orthographicSize, newZoom, dt);
                }
                else
                {
                    Camera.fieldOfView = Mathf.Lerp(Camera.fieldOfView, newZoom, dt);
                }

                /// <summary>
                /// カメラから一番遠い対象との距離を返す.
                /// </summary>
                /// <returns>対象との距離.</returns>
                float GetGreatestDistance()
                {
                    var bounds           = GetEncapsulatedBounds();
                    var size             = bounds.size;
                    var aspectRate       = ScreenHelper.NormalizedAspectRate;
                    var playerAspectRate = MathHelper.GetNormalizedAspectRate(size.x, size.z);
                    if (aspectRate.x > aspectRate.y)
                    {
                        var coefficient = Mathf.Lerp(1.0f, aspectRate.x, Mathf.Clamp01(playerAspectRate.x - playerAspectRate.y));
                        CurrentZoomLimit = ZoomLimit * coefficient;
                    }
                    else
                    {
                        var coefficient = Mathf.Lerp(1.0f, aspectRate.y, Mathf.Clamp01(playerAspectRate.y - playerAspectRate.x));
                        CurrentZoomLimit = ZoomLimit * coefficient;
                    }

                    return Mathf.Max(size.x, size.z);
                }
            }

            Bounds GetEncapsulatedBounds()
            {
                var bounds = new Bounds(Targets[0].position, Vector3.zero);
                foreach (var target in Targets)
                {
                    bounds.Encapsulate(target.position);
                }
                return bounds;
            }
        }
    }
}
