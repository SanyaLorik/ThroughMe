using UnityEngine;

namespace ThroughMe
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data", order = 1)]
    public class Data : ScriptableObject
    {
        [field: SerializeField][field: Range(0, 10)] public int Value { get; private set; }
    }
}