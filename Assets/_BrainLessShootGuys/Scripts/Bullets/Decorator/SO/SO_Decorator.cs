using UnityEngine;

[CreateAssetMenu(fileName = "SO_Decorator", menuName = "Scriptable Objects/SO_Decorator")]
public class SO_Decorator : ScriptableObject
{
    public virtual IBullet ApplyDecorator(IBullet bullet)
    {
        
        return bullet;
    }
}
