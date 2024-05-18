using UnityEditor;
using UnityEngine;


namespace TW.Editor
{
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    /// <summary>
    /// Unityで階層構造の深い箇所のすべてのMissing Scriptの一括削除の方法 | Silver winds of nirvana
    /// https://silver-nirvana.com/2023/02/03/all-missing-error-script-removal-in-bulk/
    /// </summary>
    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    
    public class MissingScriptUtility
    {
        [MenuItem("MissingScriptUtility/all missing error script removal in bulk")]
        private static void all_missing_error_script_removal_in_bulk()
        {
            int Sgo = 0;
            int i;
            int missingCount = 0;
            Sgo = Selection.gameObjects.Length;
            Debug.Log("SelectObj = " + Sgo);

            GameObject[] target_obj;
            if(Sgo >= 1){
                target_obj = Selection.gameObjects;
                for(i=0; i<Sgo; i++){
                    missingCount += GameObjectUtility.RemoveMonoBehavioursWithMissingScript(target_obj[i]);
                }
            }
            Debug.Log("missingCountObj = " + missingCount);
        }
    }
}