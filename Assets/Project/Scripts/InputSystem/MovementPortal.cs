using ThroughMe.Movement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ThroughMe.InputSystem
{
    [RequireComponent(typeof(Image))]
    public class MovementPortal : MonoBehaviour, IDirection, IDragHandler
    {
        public Vector2 Direction => throw new System.NotImplementedException();

        private Vector2 _first = Vector2.zero;
        private Vector2 _last = Vector2.zero;

        public void OnDrag(PointerEventData eventData)
        {
            print(eventData.delta);
        }
    }
}
