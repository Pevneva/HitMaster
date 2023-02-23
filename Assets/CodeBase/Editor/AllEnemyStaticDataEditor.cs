using System.Linq;
using CodeBase.Enemy;
using CodeBase.StaticData;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(EnemySpawnPointsStaticData))]
    public class AllEnemyStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            var pointsData = (EnemySpawnPointsStaticData) target;

            if (GUILayout.Button("Collect"))
            {
                pointsData.EnemySpawnPoints =
                    FindObjectOfType<EnemySpawnMarkers>()
                        .GetComponentsInChildren<EnemySpawnMarker>()
                        .Select(x => new EnemySpawnData(x.transform.position))
                        .ToList();
            }
            
            EditorUtility.SetDirty(target);            
        }
    }

}