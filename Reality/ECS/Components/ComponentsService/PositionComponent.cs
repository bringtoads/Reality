using Reality.ECS.Components.IComponents;

namespace Reality.ECS.Components.ComponentsService
{
    public class PositionComponent : IComponent
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

}
