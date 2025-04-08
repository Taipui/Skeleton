using UnityEngine;

using TMPro;


namespace TW.UI
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// バージョン表示.
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public sealed class VersionDisplay : MonoBehaviour
    {
        //================================================================================
        // Fields.
        //================================================================================

        /// <summary>
        /// ラベル.
        /// </summary>
        [SerializeField] private TextMeshProUGUI Label = default;
        
        //================================================================================
        // Methods.
        //================================================================================
        
        //--------------------------------------------------------------------------------
        // MonoBehaviour methods.
        //--------------------------------------------------------------------------------
        
        private void Start()
        {
            Label.SetText($"ver.{Application.version}");
        }
    }
}
