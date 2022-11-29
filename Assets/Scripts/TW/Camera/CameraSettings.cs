using UnityEngine;


namespace TW.CameraControl
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// カメラの設定.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public sealed class CameraSettings
    {
        //================================================================================
        // Properties.
        //================================================================================

        /// <summary>
        /// カメラの種類.
        /// </summary>
        public CameraManager.CameraType CameraType { get; private set; } = CameraManager.CameraType.Movable;

        /// <summary>
        /// カメラの位置.
        /// </summary>
        public Vector3 CameraPosition { get; private set; } = Vector3.zero;

        /// <summary>
        /// カメラの回転(度).
        /// </summary>
        public Vector3 CameraRotation { get; private set; } = Vector3.zero;

        /// <summary>
        /// カメラのオフセット.
        /// </summary>
        public Vector3? CameraOffset { get; private set; } = default;

        /// <summary>
        /// カメラの最小ズーム値.
        /// </summary>
        public float? MinZoom { get; private set; } = default;

        /// <summary>
        /// カメラの最大ズーム値.
        /// </summary>
        public float? MaxZoom { get; private set; } = default;

        /// <summary>
        /// カメラをズームする度合い.
        /// </summary>
        public float? ZoomLimit { get; private set; } = default;

        //================================================================================
        // Methods.
        //================================================================================

        //--------------------------------------------------------------------------------
        // Constructors.
        //--------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="type">カメラの種類.</param>
        /// <param name="position">カメラの位置.</param>
        /// <param name="rotation">カメラの回転.</param>
        /// <param name="offset">カメラのオフセット.</param>
        /// <param name="minZoom">カメラの最小ズーム値.</param>
        /// <param name="maxZoom">カメラの最大ズーム値.</param>
        /// <param name="zoomLimit">カメラをズームする度合い.</param>
        public CameraSettings(
            CameraManager.CameraType type      = CameraManager.CameraType.Static
          , Vector3                  position  = default
          , Vector3                  rotation  = default
          , Vector3?                 offset    = default
          , float  ?                 minZoom   = default
          , float  ?                 maxZoom   = default
          , float  ?                 zoomLimit = default
        )
        {
            Setup(type, position, rotation, offset, minZoom, maxZoom, zoomLimit);
        }

        //--------------------------------------------------------------------------------
        // Public methods.
        //--------------------------------------------------------------------------------

        /// <summary>
        /// 初期設定する.
        /// </summary>
        /// <param name="type">カメラの種類.</param>
        /// <param name="position">カメラの位置.</param>
        /// <param name="rotation">カメラの回転.</param>
        /// <param name="offset">カメラのオフセット.</param>
        /// <param name="minZoom">カメラの最小ズーム値.</param>
        /// <param name="maxZoom">カメラの最大ズーム値.</param>
        /// <param name="zoomLimit">カメラをズームする度合い.</param>
        public void Setup(
            CameraManager.CameraType type
          , Vector3                  position  = default
          , Vector3                  rotation  = default 
          , Vector3?                 offset    = default
          , float?                   minZoom   = default
          , float?                   maxZoom   = default 
          , float?                   zoomLimit = default
        )
        {
            SetType    (type    );
            SetPosition(position);
            SetRotation(rotation);
            CameraOffset = offset;
            MinZoom      = minZoom;
            MaxZoom      = maxZoom;
            ZoomLimit    = zoomLimit;
        }

        /// <summary>
        /// カメラの種類を設定する.
        /// </summary>
        /// <param name="type">カメラの種類.</param>
        public void SetType(CameraManager.CameraType type) => CameraType = type;

        /// <summary>
        /// カメラの位置を設定する.
        /// </summary>
        /// <param name="position">カメラの位置.</param>
        public void SetPosition(Vector3 position) => CameraPosition = position;

        /// <summary>
        /// カメラの回転を設定する.
        /// </summary>
        /// <param name="rotation">カメラの回転.</param>
        public void SetRotation(Vector3 rotation) => CameraRotation = rotation;

        /// <summary>
        /// カメラのオフセットを設定する.
        /// </summary>
        /// <param name="offset">カメラのオフセット.</param>
        public void SetOffset(Vector3 offset) => CameraOffset = offset;

        /// <summary>
        /// カメラの最小ズーム値を設定する.
        /// </summary>
        /// <param name="value">カメラの最小ズーム値.</param>
        public void SetMinZoom(float value) => MinZoom = value;

        /// <summary>
        /// カメラの最大ズーム値を設定する.
        /// </summary>
        /// <param name="value">カメラの最大ズーム値.</param>
        public void SetMaxZoom(float value) => MaxZoom = value;

        /// <summary>
        /// カメラをズームする度合いを設定する.
        /// </summary>
        /// <param name="value">カメラをズームする度合い.</param>
        public void SetZoomLimit(float value) => ZoomLimit = value;
    }
}
