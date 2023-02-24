using CodeBase.WayPoints;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(WayPointMarker))]
    public class WayPointSpawnMarkerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(WayPointMarker point, GizmoType gizmo)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(point.transform.position, 0.35f);
        }
    }
}