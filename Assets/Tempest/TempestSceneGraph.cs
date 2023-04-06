using System;
using System.Collections.Generic;
using Tempest;
using UnityEngine;
using XNode;

[Serializable]
public class TempestSceneGraph : XNode.SceneGraph
{
    //Fields
    [SerializeField] private List<TempestXNode> TempestNodes;
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

}
