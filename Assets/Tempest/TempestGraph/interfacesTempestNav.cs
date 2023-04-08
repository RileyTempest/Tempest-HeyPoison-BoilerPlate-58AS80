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
    
    //
    public interface ITempestNodeMonoInit
    {
        void Set_TempestNodeField(TempestNode _tempestNode);
    }
}