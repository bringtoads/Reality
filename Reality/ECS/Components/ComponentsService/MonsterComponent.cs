using Reality.ECS.Components.IComponents;

namespace Reality.ECS.Components.ComponentsService
{
    public class MonsterComponent : IComponent
    {
        public int GoldReward { get; set; }
        public int ExpReward { get; set; }

        public MonsterComponent(int goldReward, int expReward)
        {
            GoldReward = goldReward;
            ExpReward = expReward;
        }
    }

}
