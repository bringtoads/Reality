using Reality.ECS.Components.IComponents;
using System;

namespace Reality.ECS.Components.ComponentsService
{
    public class HealthComponent : IComponent
    {
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }

        public HealthComponent(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth = Math.Max(0, CurrentHealth - amount);
        }
    }

}
