using Reality.ECS.Components.IComponents;

namespace Reality.ECS.Components.ComponentsServicec
{
    public class PlayerComponent : IComponent
    {
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }

        public PlayerComponent()
        {
            Level = 1;
            Experience = 0;
            Gold = 0;
        }
    }

}
