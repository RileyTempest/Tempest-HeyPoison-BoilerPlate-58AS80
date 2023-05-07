using System;
using UnityEditor;
using UnityEngine;
using Tempest;
using Tempest.Trees.Mono;

public class MenuTest : MonoBehaviour
{
    

    // Add a menu item named "Do Something" to MyMenu in the menu bar.
    [MenuItem("Tempest/AIO")]
    static void DoSomething()
    {
        Debug.Log("Tempest - All in One GraphSetup. Note, some inspector fields may need to be set again.");
        MenuHandler_InitSystem();
        MenuHandler_RegenTempestGraph();
        MenuHandler_TestGraphPopulation();
    }
    
    //Menu Commands
    [MenuItem("Tempest/Navigation/Init NavSystem")]
    public static void MenuHandler_InitSystem()
    {
        //throw new NotImplementedException();
        ITempestNavigationMenuHandlers handler = 
            FindObjectOfType<TempestSceneGraph>().
            GetComponent<TempestNavigationBuss>();
        
        handler.InitNavigationSystem();
    }

    [MenuItem("Tempest/Navigation/Regenerate TempestGraph")]
    public static void MenuHandler_RegenTempestGraph()
    {
        Debug.Log("Regenerating...");
        Debug.Log("TODO: Collect Transforms, Collect Xnodes. Set Xnode worldPOS from matching transforms. Cont Graph population per usge ");
        //throw new NotImplementedException();
        ITempestNavigationMenuHandlers handler = 
            FindObjectOfType<TempestSceneGraph>().
                GetComponent<TempestNavigationBuss>();
        
        TempestSceneGraph.temp_InitSeq(); //TODO: review. temp for test. Do not do this plz
        
        
        handler.RegenTempestGraph();
    }
    
    
    
    //test
    [MenuItem("Tempest/Navigation/TestGraphPopulation")]
    public static void MenuHandler_TestGraphPopulation()
    {
        //throw new NotImplementedException();
        ITempestNavigationMenuHandlers handler = GameObject.FindObjectOfType<TempestNavigationBuss>();
        handler.TestGraphPopulation();
    }
    
}



