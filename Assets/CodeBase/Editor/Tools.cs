using CodeBase.Logic;
using UnityEditor;
using UnityEngine;

public class Tools
{
    [MenuItem("Tools/Do Kinemanic")]
    public static void DoKinemanic()
    {
        GameObject.FindObjectOfType<RigidBodySetter>().TurnOnKinematic();
    }
    
    [MenuItem("Tools/DoNotKinemanic")]
    public static void DoNotKinemanic()
    {
        GameObject.FindObjectOfType<RigidBodySetter>().TurnOffKinematic();
    }
}