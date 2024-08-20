using UnityEngine;
#if false
using UnityEngine.InputSystem;

using System.Linq;
#endif


namespace TW.Devices
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// 入力に関するヘルパークラス.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public static class InputHelper
    {
        //================================================================================
        // Properties.
        //================================================================================

        /// 画面の横幅.
        public static float ScreenWidth
        {
            get { return Screen.width; }
        }

        /// 画面の縦幅.
        public static float ScreenHeight
        {
            get { return Screen.height; }
        }

        /// 画面の半分の横幅.
        public static float HalfScreenWidth
        {
            get { return ScreenWidth / 2.0f; }
        }

        /// 画面の半分の縦幅.
        public static float HalfScreenHeight
        {
            get { return ScreenHeight / 2.0f; }
        }

        //================================================================================
        // Methods.
        //================================================================================

        /// <summary>
        /// タップしたスクリーン座標を返す.
        /// </summary>
        /// <remarks>
        /// 複数同時タップされた場合は、一番最初にタップした場所.
        /// </remarks>
        /// <returns>スクリーン座標.</returns>
        public static Vector3? GetTapScreenPosition()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            if (Input.GetMouseButtonDown(0))
            {
                return Input.mousePosition;
            }
#else
            if (Input.touchCount <= 0) 
            {
                return default; 
            }

            return Input.touches[0].position;
#endif

            return default;
        }

        /// <summary>
        /// タップしたワールド座標を返す.
        /// </summary>
        /// <remarks>
        /// 複数同時タップされた場合は、一番最初にタップした場所.
        /// </remarks>
        /// <returns>ワールド座標.</returns>
        public static Vector2? GetTapWorldPosition()
        {
            var screenPosition = GetTapScreenPosition();
            if (!screenPosition.HasValue)
            {
                return default;
            }

            var screenPos = screenPosition.Value;
            screenPos.z   = 10.0f;
            var worldPosition = Camera.main.ScreenToWorldPoint(screenPos);
            return worldPosition;
        }

        /// <summary>
        /// スクリーン座標をワールド座標に変換する.
        /// </summary>
        /// <param name="screenPosition">スクリーン座標.</param>
        /// <returns>ワールド座標.</returns>
        public static Vector2 ScreenToWorldPosition(Vector2 screenPosition)
        {
            return ScreenToWorldPosition(new Vector3(screenPosition.x, screenPosition.y, 0.0f));
        }

        /// <summary>
        /// スクリーン座標をワールド座標に変換する.
        /// </summary>
        /// <param name="screenPosition">スクリーン座標.</param>
        /// <returns>ワールド座標.</returns>
        public static Vector2 ScreenToWorldPosition(Vector3 screenPosition)
        {
            screenPosition.z = 1.0f;
            var worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

        /// <summary>
        /// タップしたか.
        /// </summary>
        /// <returns>タップした瞬間true.</returns>
        public static bool GetTapDown()
        {
            return Input.GetMouseButtonDown(0);
        }

        /// <summary>
        /// タップしているか.
        /// </summary>
        /// <returns>タップ中true.</returns>
        public static bool GetTap()
        {
            return Input.GetMouseButton(0);
        }

        /// <summary>
        /// タップをやめたか.
        /// </summary>
        /// <returns>タップをやめたあるいは認識できなくなった瞬間true.</returns>
        public static bool GetTapUp()
        {
            return Input.GetMouseButtonUp(0);
        }

        /// <summary>
        /// 右クリックしたか.
        /// </summary>
        /// <returns>右クリックした瞬間true.</returns>
        public static bool GetRightMouseButtonDown()
        {
            return Input.GetMouseButtonDown(1);
        }

        /// <summary>
        /// 右クリックしているか.
        /// </summary>
        /// <returns>右クリック中true.</returns>
        public static bool GetRightMouseButton()
        {
            return Input.GetMouseButton(1);
        }

        /// <summary>
        /// 右クリックをやめたか.
        /// </summary>
        /// <returns>右クリックをやめたあるいは認識できなくなった瞬間true.</returns>
        public static bool GetRightMouseButtonUp()
        {
            return Input.GetMouseButtonUp(1);
        }

        /// <summary>
        /// タップした場所にあるオブジェクトを取得する.
        /// </summary>
        /// <returns>
        /// タップした場所にオブジェクトがあれば、そのオブジェクトを返す.
        /// なければnullを返す.
        /// </returns>
        public static GameObject GetTappedObject()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out var hit, Mathf.Infinity))
            {
                return hit.collider.gameObject;
            }

            return null;
        }

#if false
        public static int GetGamepadIndex(InputAction.CallbackContext context)
        {
            return GetGamepadIndex(context.control.device.deviceId);
        }

        /// <summary>
        /// ゲームパッドのインデックスを取得する.
        /// </summary>
        /// <param name="deviceId">ゲームパッドのデバイスID.</param>
        /// <returns>ゲームパッドのインデックス(1オリジン).</returns>
        public static int GetGamepadIndex(int deviceId)
        {
            var deviceIds = InputSystem.devices
                .Where(device => device is Gamepad)
                .Select(device => device.deviceId)
                .ToArray();

            if ((deviceIds == null) || (deviceIds.Length == 0))
            {
                return 1;
            }

            var index = System.Array.IndexOf(deviceIds, deviceId);
            if (index == -1)
            {
                return 1;
            }

            return index + 1;
        }
#endif
    }
}
