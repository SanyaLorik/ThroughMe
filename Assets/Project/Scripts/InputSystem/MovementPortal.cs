using ThroughMe.Movement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ThroughMe.InputSystem
{
    [RequireComponent(typeof(Image))]
    public class MovementPortal : MonoBehaviour, IDirection, IDragHandler, IEndDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.delta.y == 0)
                return;

            Direction = eventData.delta.normalized;
        }

        public void OnEndDrag(PointerEventData eventData) =>
            Direction = Vector2.zero;

        public Vector2 Direction { get; private set; }
    }
}
