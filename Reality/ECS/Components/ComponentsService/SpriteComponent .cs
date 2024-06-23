using Microsoft.Xna.Framework.Graphics;
using Reality.ECS.Components.IComponents;

namespace Reality.ECS.Components.ComponentsService
{
    public class SpriteComponent : IComponent
    {
        public Texture2D Texture { get; set; }
    }

}
