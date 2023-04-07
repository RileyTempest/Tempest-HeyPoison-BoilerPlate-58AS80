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
        protected static TempestNavigationEvent TempestGraph_test;

        //Init
        private void Init_SelfFirst()
        {
            SysHook = this;
            MenuHandlers = this;
            InitSystem = delegate {  };
            Regenerate = delegate {  };
            
            //tests
            LoadTest_TempestGraph();
            
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
        void ITempestNavigationMenuHandlers.TestGraphPopulation() => TempestGraph_test.Invoke();

        
        //Helpers - test
        private void LoadTest_TempestGraph() => TempestGraph_test = delegate {  };
        
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