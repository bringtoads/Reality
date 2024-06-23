using Reality.ECS.Components.IComponents;
using System;

namespace Reality.ECS.Components.ComponentsService
{
    public class PowerComponent : IComponent
    {
        public int CurrentPower { get; set; }
        public int MaxPower { get; set; }

        public PowerComponent(int maxPower)
        {
            MaxPower = maxPower;
            CurrentPower = maxPower;
        }

        public void UsePower(int amount)
        {
            CurrentPower = Math.Max(0, CurrentPower - amount);
        }

        public void RechargePower(int amount)
        {
            CurrentPower = Math.Min(MaxPower, CurrentPower + amount);
        }
    }

}
