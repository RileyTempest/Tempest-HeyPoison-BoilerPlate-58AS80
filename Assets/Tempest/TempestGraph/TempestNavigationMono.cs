using System;
using System.Collections.Generic;
using UnityEngine;
using Tempest;
using Unity.VisualScripting;
using UnityEditor;


namespace Tempest.Trees.Mono
{
    [Serializable]
    public class TempestNavigationMono : TempestNavigationBuss 
    {
        
        
        
        //Fields
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
            CountChildrenForGraphUpdate();
            SetChildrenWithPrefab();
            DestroyOldChildren();
            InitGlobalFields();
        }
    }
}