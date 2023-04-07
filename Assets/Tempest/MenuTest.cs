using System;
using UnityEditor;
using UnityEngine;
using Tempest;
using Tempest.Trees.Mono;

public class MenuTest : MonoBehaviour
{
    

    // Add a menu item named "Do Something" to MyMenu in the menu bar.
    [MenuItem("Tempest/Foobar")]
    static void DoSomething()
    {
        Debug.Log("Tempest - MenuItem MenuTest - Foobar...");
    }
    
    //Menu Commands
    [MenuItem("Tempest/Navigation/Init NavSystem")]
    public static void MenuHandler_InitSystem()
    {
        //throw new NotImplementedException();
        ITempestNavigationMenuHandlers handler = GameObject.FindObjectOfType<TempestNavigationBuss>();
        handler.InitNavigationSystem();
    }

    [MenuItem("Tempest/Navigation/Regenerate TempestGraph")]
    public static void MenuHandler_RegenTempestGraph()
    {
        //throw new NotImplementedException();
        ITempestNavigationMenuHandlers handler = GameObject.FindObjectOfType<TempestNavigationBuss>();
        handler.RegenTempestGraph();
    }
    
    
    
    //test
    [MenuItem("Tempest/TestGraphPopulation")]
    public static void MenuHandler_TestGraphPopulation()
    {
        //throw new NotImplementedException();
        ITempestNavigationMenuHandlers handler = GameObject.FindObjectOfType<TempestNavigationBuss>();
        handler.TestGraphPopulation();
    }
    
}



