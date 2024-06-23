using Reality.ECS.Components.IComponents;

namespace Reality.ECS.Components.ComponentsService
{
    public class VelocityComponent : IComponent
    {
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
    }

}
