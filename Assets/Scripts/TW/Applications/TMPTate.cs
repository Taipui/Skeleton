// TextMeshPro(UGUI)を縦書きにする方法[Unity+TMP] | あのゲームの作り方Web版
// https://anogame.net/textmeshprougui-tate-vertical/
// UnityEditor上でGameObjectをUpdateさせる方法 #C# - Qiita
// https://qiita.com/KyoheiOkawa/items/26fa8d8a46f6e40ae44e
using UnityEngine;
using TMPro;
using UnityEditor;


namespace TW.Applications
{
    [ExecuteAlways]
    public class TMPTate : MonoBehaviour
    {
        private TMP_Text textMeshPro;
        private void Awake()
        {
            textMeshPro = gameObject.GetComponent<TMP_Text>();
        }

        private void Update()
        {
            #if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return;
            }
            #endif

            Render();
        }

        void OnRenderObject()
        {
            #if UNITY_EDITOR
            if (Application.isPlaying)
            {
                return;
            }

            Render();

            EditorApplication.QueuePlayerLoopUpdate();
            SceneView.RepaintAll();
            #endif
        }

        void Render()
        {
            textMeshPro.ForceMeshUpdate();

            var textInfo = textMeshPro.textInfo;
            if (textInfo.characterCount == 0)
            {
                return;
            }
            Vector3[] firstDestVertices = textInfo.meshInfo[0].vertices;
            float startX = firstDestVertices[0].x;
            Vector3 startCenter = (firstDestVertices[0] + firstDestVertices[2]) / 2;
            float characterHeight = firstDestVertices[1].y - firstDestVertices[0].y;

            for (int index = 0; index < textInfo.characterCount; index++)
            {
                var charaInfo = textInfo.characterInfo[index];
                if (!charaInfo.isVisible)
                {
                    continue;
                }

                int materialIndex = charaInfo.materialReferenceIndex;
                int vertexIndex = charaInfo.vertexIndex;
                Vector3[] destVertices = textInfo.meshInfo[materialIndex].vertices;

                Vector3 charaCenter = (destVertices[vertexIndex + 0] + destVertices[vertexIndex + 2]) / 2;

                float offsetX = charaCenter.x - startCenter.x;
                float offsetY = (characterHeight * index);

                Vector3 offset = new Vector3(-offsetX, -offsetY, 0);

                destVertices[vertexIndex + 0] += offset;
                destVertices[vertexIndex + 1] += offset;
                destVertices[vertexIndex + 2] += offset;
                destVertices[vertexIndex + 3] += offset;
            }

            for (int i = 0; i < textInfo.meshInfo.Length; i++)
            {
                textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
                textMeshPro.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
            }
        }
    }
}
