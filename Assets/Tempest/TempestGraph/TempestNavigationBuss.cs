using System;
using System.Collections.Generic;
using System.Data;
using Tempest;
using Tempest.Trees;
using UnityEngine;
using UnityEditor;


//public delegate void SampleEventHandler(object sender, SampleEventArgs e);
public delegate void TempestNavigationEvent();
//TempestNavigationBuss.derp += () => { };
//TempestNavigationBuss.derp += delegate {  };


namespace Tempest.Trees.Mono
{
    public class TempestNavigationBuss : MonoBehaviour, ITempestNavigationHook, ITempestNavigationMenuHandlers
    {
        //Fields
        protected static ITempestNavigationHook SysHook;
        protected static ITempestNavigationMenuHandlers MenuHandlers;
        
        //Events
        protected static TempestNavigationEvent InitSystem;
        protected static TempestNavigationEvent Regenerate;
      
        //Unity Messages
        private void Awake()
        {
            Acquirefields();
            CheckFields();
        }
        
        //Init
        private void Init_SelfFirst()
        {
            SysHook = this;
            InitSystem = delegate {  };
            Regenerate = delegate {  };
            this.EventRefresh_Resubscribe();
            InitSystem.Invoke();
        }
        
        //ITempest - interfaces
        public virtual void EventRefresh_Resubscribe()
        {
            Debug.Log(this.name + " is calling ResubTobuss, parent");
        }
        void ITempestNavigationMenuHandlers.InitNavigationSystem() => Init_SelfFirst();
        void ITempestNavigationMenuHandlers.RegenTempestGraph() => Regenerate.Invoke();
        
        
        //Below Are just notes from previous implementations 
        
#region Previmplementations
        
        //Helpers
        private void CheckFields()
        {
            /*if (_navigationMonoTest == null)
            {
                Debug.LogWarning("Tempest - NavigationMono object/component not populated at this time. ");
            }*/
        }
        private void Acquirefields()
        {
            //_navigationMonoTest = GetComponent<TempestNavigationMono_test>();
        }


        //Menu Commands
        [ContextMenu("Tempest/Pull Position Data to XNode")]
        public void TempestNodes_PositionData()
        {
            Acquirefields();
            CheckFields();
            
            Regenerate = delegate {  };
            //_navigationMonoTest.InitSubscriptions();
            //SetTransforms.Invoke();
        }
        
        [ContextMenu("Tempest/Regenerate TempestNodes from Graph")]
        public void TempestNodes_RegenFromXNodeGraph()
        {
            //
            //Debug.Log(base.graph.nodes[0].GetType());
            //.GameObject().GetComponent<Renderer>().material.color = Color.red;
            //
            
            Debug.Log("TempestNodes - Regenerating...");
            Acquirefields();
            CheckFields();
            
            Regenerate = delegate {  };
            //_navigationMonoTest.InitSubscriptions();
            Regenerate.Invoke();
        
        }

        [ContextMenu("Tempest/Crawl ports gen edges")]
        public void TempestNodes_CrawlPortsGenerateEdges()
        {
            Acquirefields();
            CheckFields();
            
            //CrawlPorts = delegate {  };
            //_navigationMonoTest.InitSubscriptions();
            //CrawlPorts.Invoke();
        }
        
#endregion
        
    }
}