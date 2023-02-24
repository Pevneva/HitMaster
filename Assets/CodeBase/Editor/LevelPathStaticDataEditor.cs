using System.Linq;
using CodeBase.Enemy;
using CodeBase.StaticData;
using CodeBase.WayPoints;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(LevelPathStaticData))]
    public class LevelPathStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var pointsData = (LevelPathStaticData) target;

            if (GUILayout.Button("Collect"))
            {
                WayPointMarker[] wayPointMarkers =
                    FindObjectOfType<LevelPathMarker>()
                        .GetComponentsInChildren<WayPointMarker>();
                
                pointsData.AllWayPoints =
                    wayPointMarkers
                        .Select(x => new PointSpawnData(x.transform.position,
                            x.GetComponentsInChildren<EnemySpawnMarker>().Length,
                            x.GetComponentsInChildren<EnemySpawnMarker>()
                                .Select(y => new EnemySpawnData(y.transform.position))
                                .ToList()))
                        .ToList();
            }
            
            EditorUtility.SetDirty(target);
        }
    }
}