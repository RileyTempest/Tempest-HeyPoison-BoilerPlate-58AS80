using System;
using System.Collections;
using System.Collections.Generic;
using Tempest;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using XNode;
using XNode.Examples.LogicToy;

[Serializable]
public class TempestSceneGraph : XNode.SceneGraph
{
    //Fields
    [SerializeField] private List<TempestNode> TempestNodes;
    [SerializeField] private NodeGraph NodeGraph;
    
    //Context menu item. 
    /*
     *TODO:
     * Load Prefab
     * Field for loading SO graphs, different levels.
     * context menu item for  refreshing, loading
     * Edit graph. XNode
     * 
     *
     *
     * 
     */
    
    //Menu Commands
    [ContextMenu("Tempest/Regenerate TempestNodes from Graph")]
    public void TempestNodes_RegenFromXNodeGraph()
    {
        //
        
        
        
        //
        
        Debug.Log(base.graph.nodes[0].GetType());
        //.GameObject().GetComponent<Renderer>().material.color = Color.red;
        
        
        
        
        //
        Debug.Log("TempestNodes - Regenerating...");
        
    }
    



}
