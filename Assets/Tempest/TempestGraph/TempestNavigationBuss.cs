using System;
using UnityEngine;
using UnityEditor;



//public delegate void SampleEventHandler(object sender, SampleEventArgs e);
public delegate void TempestNavigationHandler();
//TempestNavigationBuss.derp += () => { };
//TempestNavigationBuss.derp += delegate {  };


namespace Tempest.Trees.Mono
{
    public class TempestNavigationBuss : MonoBehaviour
    {

        
        //Fields
        private TempestNavigationMono NavigationMono; 
        
        //Events
        public static TempestNavigationHandler derp;
        
        //Unity Messages
        private void Awake()
        {
            Acquirefields();
            CheckFields();
        }


        //Helpers
        private void CheckFields()
        {
            if (NavigationMono == null)
            {
                Debug.LogWarning("Tempest - NavigationMono object/component not populated at this time. ");
            }
        }

        private void Acquirefields()
        {
            NavigationMono = GetComponent<TempestNavigationMono>();
        }
        
        //Menu Commands
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
            
            NavigationMono.InitSubscriptions();
            
            derp.Invoke();
        
        }
    }
}