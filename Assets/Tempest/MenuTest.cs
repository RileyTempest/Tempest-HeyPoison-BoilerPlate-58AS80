using UnityEditor;
using UnityEngine;

public class MenuTest : MonoBehaviour
{
    // Add a menu item named "Do Something" to MyMenu in the menu bar.
    [MenuItem("Tempest/Foobar")]
    static void DoSomething()
    {
        Debug.Log("Tempest - MenuItem MenuTest - Foobar...");
    }
}