using UnityEngine;
#if false
using UnityEngine.InputSystem;
#endif
using System.Linq;


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
        public static float ScreenWidth => Screen.width;

        /// 画面の縦幅.
        public static float ScreenHeight => Screen.height;

        /// 画面の半分の横幅.
        public static float HalfScreenWidth => ScreenWidth / 2.0f;

        /// 画面の半分の縦幅.
        public static float HalfScreenHeight => ScreenHeight / 2.0f;

        //================================================================================
        // Methods.
        //================================================================================

        /// <summary>
        /// スクリーン座標をワールド座標に変換する.
        /// </summary>
        /// <param name="screenPosition">スクリーン座標.</param>
        /// <returns>ワールド座標.</returns>
        public static Vector2 ScreenToWorldPosition(Vector2 screenPosition) => ScreenToWorldPosition(new Vector3(screenPosition.x, screenPosition.y));

        /// <summary>
        /// スクリーン座標をワールド座標に変換する.
        /// </summary>
        /// <param name="screenPosition">スクリーン座標.</param>
        /// <returns>ワールド座標.</returns>
        public static Vector2 ScreenToWorldPosition(Vector3 screenPosition)
        {
            screenPosition.z  = 1.0f;
            var worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

        /// <summary>
        /// タップしたか.
        /// </summary>
        /// <returns>タップした瞬間true.</returns>
        public static bool GetTapDown()
        {
            if (Input.touchCount > 0)
            {
                return Input.touches[0].phase == TouchPhase.Began;
            }

            return Input.GetMouseButtonDown(0);
        }

        /// <summary>
        /// タップしているか.
        /// </summary>
        /// <returns>タップ中true.</returns>
        public static bool GetTap()
        {
            if (Input.touchCount > 0)
            {
                return Input.touches[0].phase is TouchPhase.Stationary or TouchPhase.Moved;
            }

            return Input.GetMouseButton(0);
        }

        /// <summary>
        /// タップをやめたか.
        /// </summary>
        /// <returns>タップをやめたあるいは認識できなくなった瞬間true.</returns>
        public static bool GetTapUp()
        {
            if (Input.touchCount > 0)
            {
                return Input.touches[0].phase is TouchPhase.Ended or TouchPhase.Canceled;
            }

            return Input.GetMouseButtonUp(0);
        }

        /// <summary>
        /// タップしているスクリーン座標を返す.
        /// </summary>
        /// <returns>スクリーン座標.</returns>
        public static Vector3? GetTappingScreenPosition()
        {
            if (Input.touchCount > 0)
            {
                return Input.touches[0].position;
            }

            return Input.mousePosition;
        }

        /// <summary>
        /// タップしたスクリーン座標を返す.
        /// </summary>
        /// <remarks>
        /// 複数同時タップされた場合は、一番最初にタップした場所.
        /// </remarks>
        /// <returns>スクリーン座標.</returns>
        public static Vector3? GetTapScreenPosition() => GetTapDown() ? GetTappingScreenPosition() : null;

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
                return null;
            }

            var screenPos     = screenPosition.Value;
            screenPos.z       = 10.0f;
            var worldPosition = Camera.main.ScreenToWorldPoint(screenPos);
            return worldPosition;
        }

        /// <summary>
        /// 右クリックしたか.
        /// </summary>
        /// <returns>右クリックした瞬間true.</returns>
        public static bool GetRightMouseButtonDown() => Input.GetMouseButtonDown(1);

        /// <summary>
        /// 右クリックしているか.
        /// </summary>
        /// <returns>右クリック中true.</returns>
        public static bool GetRightMouseButton() => Input.GetMouseButton(1);

        /// <summary>
        /// 右クリックをやめたか.
        /// </summary>
        /// <returns>右クリックをやめたあるいは認識できなくなった瞬間true.</returns>
        public static bool GetRightMouseButtonUp() => Input.GetMouseButtonUp(1);

        /// <summary>
        /// タップした場所にあるオブジェクトを取得する.
        /// </summary>
        /// <returns>
        /// タップした場所にオブジェクトがあれば、そのオブジェクトを返す.
        /// なければnullを返す.
        /// </returns>
        public static GameObject GetTappedObject()
        {
            var position = GetTapScreenPosition();
            if (!position.HasValue)
            {
                return null;
            }

            var ray = Camera.main.ScreenPointToRay(position.Value);
            if (Physics.Raycast(ray.origin, ray.direction, out var hit, Mathf.Infinity))
            {
                return hit.collider.gameObject;
            }

            return null;
        }

        /// <summary>
        /// オブジェクトを取得する.
        /// </summary>
        /// <param name="position">スクリーン座標.</param>
        /// <param name="layer">レイヤー.</param>
        /// <returns>オブジェクト.</returns>
        public static GameObject GetObject2D(Vector3 position, LayerMask layer = default)
        {
            var hit = Physics2D.Raycast(
                Camera.main.ScreenToWorldPoint(position)
              , Vector3.forward
              , float.MaxValue
              , layer
            );
            return (hit.collider == null) ? null : hit.collider.gameObject;
        }

        /// <summary>
        /// タップしている場所にあるオブジェクトを取得する.
        /// </summary>
        /// <remarks>2D版.</remarks>
        /// <param name="layer">レイヤー.</param>
        /// <returns>
        /// タップしている場所にオブジェクトがあれば、そのオブジェクトを返す.
        /// なければnullを返す.
        /// </returns>
        public static GameObject GetTappingObject2D(LayerMask layer = default)
        {
            var position = GetTappingScreenPosition();
            if (!position.HasValue)
            {
                return null;
            }

            return GetObject2D(position.Value, layer);
        }

        /// <summary>
        /// タップした場所にあるオブジェクトを取得する.
        /// </summary>
        /// <remarks>2D版.</remarks>
        /// <param name="layer">レイヤー.</param>
        /// <returns>
        /// タップした場所にオブジェクトがあれば、そのオブジェクトを返す.
        /// なければnullを返す.
        /// </returns>
        public static GameObject GetTappedObject2D(LayerMask layer = default)
        {
            var position = GetTapScreenPosition();
            if (!position.HasValue)
            {
                return null;
            }

            return GetObject2D(position.Value, layer);
        }

        /// <summary>
        /// タップした場所にあるオブジェクトを取得する.
        /// </summary>
        /// <remarks>2D版.</remarks>
        /// <param name="layer">レイヤー.</param>
        /// <returns>
        /// タップした場所にオブジェクトがあれば、そのオブジェクトを返す.
        /// オブジェクトが複数ある場合、もっとも近いオブジェクトを返す.
        /// なければnullを返す.
        /// </returns>
        public static GameObject GetTappedNearestObject2D(LayerMask layer = default)
        {
            var position = GetTapScreenPosition();
            if (!position.HasValue)
            {
                return null;
            }

            var hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(position.Value), Vector3.forward, float.MaxValue, layer);
            return hits
                .Where(hit => hit.collider != null)
                .OrderBy(hit => Vector3.Distance(hit.transform.position, position.Value))
                .Select(hit => hit.collider.gameObject)
                .FirstOrDefault();
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
