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
    }
}