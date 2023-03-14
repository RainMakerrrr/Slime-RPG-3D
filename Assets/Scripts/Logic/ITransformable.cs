using UnityEngine;

namespace Logic
{
    public interface ITransformable
    {
        Vector3 Position { get; }
        bool IsDestroyed { get; }
    }
}