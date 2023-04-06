using System;
using System.Collections.Generic;
using UnityEngine;
using Tempest;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.SceneManagement;
using XNode;


namespace Tempest.Trees.Mono
{
    [Serializable]
    public class TempestNavigationMono : TempestNavigationBuss 
    {
        //Fields
        [SerializeField] private XNode.SceneGraph SceneGraphComponent;
        [SerializeField] private XNode.NodeGraph XGraph;
        [SerializeField] private GameObject NodeGOPrefab;
        [SerializeField] private Tempest.Trees.Graph NavigationGraph;
        
        
        //Globals
        private Transform[] NodeGOs = null;
        
        //Events/Subs
        public void InitSubscriptions()
        {
            //TempestNavigationBuss.derp += () => { };
            //TempestNavigationBuss.derp += delegate {  };
            TempestNavigationBuss.derp += HandlerRegenerate;
        }
        
        //Unity Messages
        private void Awake()
        {
            //throw new NotImplementedException();
        }

        private void Update()
        {
            //throw new NotImplementedException();
        }
        
        //Helper
        private void CountChildrenForGraphUpdate()
        { 
            NodeGOs = GetComponentsInChildren<Transform>();
            foreach (Transform trans in NodeGOs)
            {
                Debug.Log(trans + " " + trans.name);
            }
        }
        private void SetChildrenWithPrefab()
        {
            for (int i = NodeGOs.Length - 1; i > 0; i--)
            {
                Debug.Log( " forloop SetChildrenPrefab" + i);
                Instantiate(NodeGOPrefab, 
                    NodeGOs[i].position, 
                    Quaternion.identity.normalized,
                    this.transform);
            }
        }
        private void DestroyOldChildren()
        {
            for (int i = NodeGOs.Length - 1; i > 0; i--)
            {
                DestroyImmediate(NodeGOs[i].gameObject);
            }
        }
        private void InitGlobalFields() //eeewww. This feels gross.
        {
            NodeGOs = null;
        }

        //Helper - EventHandlers
        private void HandlerRegenerate()
        {
            Debug.Log("entered HandlerRgen method in NavMono");
            
            //
            /*
             * crawl children. names as tags
             * add to dictionary as keys
             * "" crawl nodes in XnodeGraph, tag/name/label field
             * add to same dictionary as keys, handling collisions
             * value is a struct, an intermediate data container. Serialized Object?
             * 
             * 
             * 
             */
            
            CountChildrenForGraphUpdate();
            DestroyOldChildren();

            SceneGraphComponent = GetComponent<SceneGraph>();
            XGraph = SceneGraphComponent.graph;
            NavigationGraph = null; //TODO: Make this whole process more elegant and 'in the background'. 
            foreach (XNode.Node node in XGraph.nodes)
            {
                GameObject GO = Instantiate(NodeGOPrefab, this.transform);
                GO.name = node.name;

            }
            
            
            
            //
            //CountChildrenForGraphUpdate();
            //SetChildrenWithPrefab();
            //DestroyOldChildren();
            InitGlobalFields();
        }
    }
}