using UnityEngine;

using TW.Devices;

using TMPro;


namespace PJ.InputHelperTest
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// InputHelperのテスト.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public sealed class InputHelperTest : MonoBehaviour
    {
        //================================================================================
        // Fields.
        //================================================================================

        [SerializeField] private TextMeshProUGUI ScreenWidthLabel          = default;
        [SerializeField] private TextMeshProUGUI ScreenHeightLabel         = default;
        [SerializeField] private TextMeshProUGUI HalfScreenWidthLabel      = default;
        [SerializeField] private TextMeshProUGUI HalfScreenHeightLabel     = default;
        [SerializeField] private TextMeshProUGUI ScreenPositionLabel       = default;
        [SerializeField] private TextMeshProUGUI WorldPositionLabel        = default;
        [SerializeField] private TextMeshProUGUI TapDownLabel              = default;
        [SerializeField] private TextMeshProUGUI TapLabel                  = default;
        [SerializeField] private TextMeshProUGUI TapUpLabel                = default;
        [SerializeField] private TextMeshProUGUI RightMouseButtonDownLabel = default;
        [SerializeField] private TextMeshProUGUI RightMouseButtonLabel     = default;
        [SerializeField] private TextMeshProUGUI RightMouseButtonUpLabel   = default;
        [SerializeField] private TextMeshProUGUI TapScreenPositionLabel    = default;
        [SerializeField] private TextMeshProUGUI TapWorldPositionLabel     = default;
        [SerializeField] private TextMeshProUGUI TappedObjectLabel         = default;

        //================================================================================
        // Methods.
        //================================================================================

        //--------------------------------------------------------------------------------
        // MonoBehaviour methods.
        //--------------------------------------------------------------------------------

        private void Update()
        {
            ScreenWidthLabel         .SetText($"ScreenWidth: {InputHelper.ScreenWidth}");
            ScreenHeightLabel        .SetText($"ScreenHeight: {InputHelper.ScreenHeight}");
            HalfScreenWidthLabel     .SetText($"HalfScreenWidth: {InputHelper.HalfScreenWidth}");
            HalfScreenHeightLabel    .SetText($"HalfScreenHeight: {InputHelper.HalfScreenHeight}");
            var screenPosition = Input.mousePosition;
            ScreenPositionLabel      .SetText($"ScreenPosition: {screenPosition}");
            WorldPositionLabel       .SetText($"WorldPosition: {InputHelper.ScreenToWorldPosition(screenPosition)}");
            TapDownLabel             .SetText($"TapDown: {InputHelper.GetTapDown()}");
            TapLabel                 .SetText($"Tap: {InputHelper.GetTap()}");
            TapUpLabel               .SetText($"TapUp: {InputHelper.GetTapUp()}");
            RightMouseButtonDownLabel.SetText($"RightMouseButtonDown: {InputHelper.GetRightMouseButtonDown()}");
            RightMouseButtonLabel    .SetText($"RightMouseButton: {InputHelper.GetRightMouseButton()}");
            RightMouseButtonUpLabel  .SetText($"RightMouseButtonUp: {InputHelper.GetRightMouseButtonUp()}");
            var tapScreenPosition = InputHelper.GetTapScreenPosition();
            if (tapScreenPosition.HasValue)
            {
                TapScreenPositionLabel.SetText($"TapScreenPosition: {tapScreenPosition.Value}");
            }
            var tapWorldPosition = InputHelper.GetTapWorldPosition();
            if (tapWorldPosition.HasValue)
            {
                TapWorldPositionLabel.SetText($"TapWorldPosition: {tapWorldPosition.Value}");
            }
            TappedObjectLabel.SetText($"TappedObject: {InputHelper.GetTappedObject()}");
        }
    }
}
