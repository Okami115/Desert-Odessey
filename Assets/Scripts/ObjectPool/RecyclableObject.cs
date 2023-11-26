using UnityEngine;

public interface RecyclableObject
{
    internal abstract void Config(ObjectPool pool);

    internal abstract void Recycle();

    internal abstract void Init(Vector3 pos);
}
