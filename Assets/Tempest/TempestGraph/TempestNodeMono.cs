using System;
using Tempest.Trees;
using Tempest.Trees.Mono;
using Unity.Collections;
using UnityEngine;
using UnityEditor;

namespace Tempest
{
    public class TempestNodeMono : MonoBehaviour, ITempestNodeMono
    {
        //Fields
        private TempestNode tempestNode;
        private ITempestNode ITempestNode => tempestNode;

        //Interfaces
        void ITempestNodeMono.Set_TempestNodeField(TempestNode _tempestNode)
        {
            tempestNode = _tempestNode;
            ITempestNode.Ingest_NodeMono(this);
            Debug.LogWarning("TempestNodeMono has ingested itself into TempestNode", this);
        }
        void ITempestNodeMono.Get_WorldPosition()
        {
            throw new NotImplementedException();
        }
    }
}