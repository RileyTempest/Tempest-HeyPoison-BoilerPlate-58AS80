using System;
using Tempest.Trees;
using Tempest.Trees.Mono;
using Unity.Collections;
using UnityEngine;
using UnityEditor;

namespace Tempest
{
    
    //
    public class TempestNodeMono : TempestNavigationMono, ITempestNodeMonoInit
    {
        //Fields
        private TempestNode tempestNode;
        private ITempestNode ITempestNode => tempestNode;

        //Interfaces
        void ITempestNodeMonoInit.Set_TempestNodeField(TempestNode _tempestNode)
        {
            tempestNode = _tempestNode;
            ITempestNode.Ingest_NodeMono(this);
        }
    }
}