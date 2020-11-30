using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



    public class TouchController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public Vector3 direction;
        public Vector3 origin;
        public bool downHandler;
        public bool upHandler;

        private void Awake()
        {
            this.direction = Vector3.zero;
        }
        
        private void LateUpdate()
        {
            upHandler = false;
           
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            this.origin = eventData.position;
            downHandler = true;

        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 currentPosition = eventData.position;
            Vector3 directionRaw = currentPosition - origin;
            this.direction = directionRaw;

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            direction = Vector3.zero;
            upHandler = true;
            downHandler = false;

        }

        public Vector3 GetDirection()
        {
            return direction;
        }

    }
