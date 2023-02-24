using CodeBase.Enemy;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(EnemySpawnMarker))]
    public class EnemySpawnMarkerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(EnemySpawnMarker point, GizmoType gizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(point.transform.position, 0.35f);
        }
    }
}