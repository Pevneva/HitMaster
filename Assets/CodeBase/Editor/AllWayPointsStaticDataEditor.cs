using System.Linq;
using CodeBase.Enemy;
using CodeBase.StaticData;
using CodeBase.WayPoints;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(LevelPathStaticData))]
    public class AllWayPointsStaticDataEditor : UnityEditor.Editor
    {
        private int _index;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var pointsData = (LevelPathStaticData) target;

            if (GUILayout.Button("Collect"))
            {
                var wayPointMarkers =
                    FindObjectOfType<WayPointSpawnMarkers>()
                        .GetComponentsInChildren<WayPointSpawnMarker>();
                
                pointsData.AllWayPointsWithEnemies =
                    wayPointMarkers
                        .Select(x => new PointSpawnerData(++_index,x.transform.position, 
                            x.GetComponentsInChildren<EnemySpawnMarker>()
                            .Select(y => new EnemySpawnData(y.transform.position))
                            .ToList()))
                        .ToList();

                _index = 0;
            }
            
            EditorUtility.SetDirty(target);
        }
    }
}