using System.Collections.Generic;
using UnityEngine;
using Tempest.Trees;

//Event Interfaces && Menu Items
namespace Tempest
{
    public interface ITempestNavigationHook //virtual method to call from parent
    {
        void EventRefresh_Resubscribe();
    }

    public interface ITempestNavigationMenuHandlers
    {
        void InitNavigationSystem();
        void RegenTempestGraph();

        //test
        void TestGraphPopulation();
    }
}

//Node Interfaces - Mono, Tempest, XNode
namespace Tempest
{
    public interface ITempestNodeMono
    {
        void Set_TempestNodeField(TempestNode _tempestNode);
        void Get_WorldPosition();
    }
    
    public interface IXNodeAttributes
    {
        XNode.Node Get_XNode();
        string Get_MatchLabel();
        Vector3 Get_WorldPOS();
        List<Edge> Get_Edges();
    }
}