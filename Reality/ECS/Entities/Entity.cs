using Reality.ECS.Components.IComponents;
using System;
using System.Collections.Generic;

namespace Reality.ECS.Entities
{
    public class Entity
    {
        public int Id { get; private set; }
       // private static int _nextId = 0;
        private readonly Dictionary<Type, IComponent> _components = new Dictionary<Type, IComponent>();

        //public Entity()
        //{
        //    Id = _nextId++;
        //}

        public void AddComponent(IComponent component)
        {
            _components[component.GetType()] = component;
        }

        //public T GetComponent<T>() where T : class, IComponent
        //{
        //    _components.TryGetValue(typeof(T), out var component);
        //    return component as T;
        //}
        public T GetComponent<T>() where T: IComponent
        {
            //if (_components.TryGetValue(typeof(T), out var component))
            //{
            //    return (T)component;
            //}
            //return default;
            return (T)_components[typeof(T)];
        }

        public bool HasComponent<T>() where T : class, IComponent
        {
            return _components.ContainsKey(typeof(T));
        }
    }


}
