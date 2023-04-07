using System;
using Tempest.Trees;
using Tempest.Trees.Mono;
using Unity.Collections;
using UnityEngine;
using UnityEditor;

namespace Tempest
{
    [Serializable]
    [ExecuteInEditMode]
    public class TempestNodeMono : TempestNavigationBuss
    {
        //Fields
        [SerializeField] public TempestNodePayload Payload; 

        //
        private void Awake()
        {

        }
        private void OnGUI()
        {
            
            
            
            
            //Debug.DrawLine();
        }
        
        //
        
    }
}