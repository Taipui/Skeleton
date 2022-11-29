using UnityEngine;


namespace TW.CameraControl.Test
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// カメラ関連のテスト.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public sealed class CameraTest : MonoBehaviour
    {
        //================================================================================
        // Fields.
        //================================================================================

        [SerializeField] private CameraManager            CameraManager = default;
        [SerializeField] private Transform[]              Targets       = default;
        [SerializeField] private CameraManager.CameraType CameraType    = CameraManager.CameraType.Static;

        //================================================================================
        // Methods.
        //================================================================================

        //--------------------------------------------------------------------------------
        // MonoBehaviour methods.
        //--------------------------------------------------------------------------------

        private void Start()
        {
            var settings = new CameraSettings(CameraType, CameraManager.MainCamera.transform.position);
            CameraManager.Setup(Targets, settings);
        }

        private void LateUpdate()
        {
            CameraManager.LateTick(Time.deltaTime);
        }
    }
}
