using Utility.EventBusSystem.Interfaces;

namespace Core.Events
{
    public class OnFarmEnabled : IEvent
    {
        public readonly float ValuePerTime;

        public OnFarmEnabled(float valuePerTime)
        {
            this.ValuePerTime = valuePerTime;
        }
    }
}