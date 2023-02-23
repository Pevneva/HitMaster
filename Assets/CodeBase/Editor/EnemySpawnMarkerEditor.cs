using CodeBase.Enemy;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(inspectedType: typeof(EnemySpawnMarker))]
    public class EnemySpawnMarkerEditor : UnityEditor.Editor
    {
        [DrawGizmo(gizmo: GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(EnemySpawnMarker point, GizmoType gizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(center: point.transform.position, radius: 0.5f);
        }
    }
}