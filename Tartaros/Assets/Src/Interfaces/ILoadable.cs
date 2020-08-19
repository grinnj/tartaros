using UnityEngine;

public interface ILoadable
{
    ILoadable CreateFromFile();
    bool LoadFromFile();
}
