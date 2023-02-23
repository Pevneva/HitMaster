using CodeBase.WayPoints;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(inspectedType: typeof(WayPointSpawnMarker))]
    public class WayPointSpawnMarkerEditor : UnityEditor.Editor
    {
        [DrawGizmo(gizmo: GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(WayPointSpawnMarker point, GizmoType gizmo)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(center: point.transform.position, radius: 0.5f);
        }
    }
}