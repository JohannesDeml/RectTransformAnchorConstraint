// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RectTransformAnchorSetter.cs" company="Supyrb">
//   Copyright (c) 2016 Supyrb. All rights reserved.
// </copyright>
// <author>
//   Johannes Deml
//   send@johannesdeml.com
// </author>
// --------------------------------------------------------------------------------------------------------------------

namespace Supyrb
{
	using UnityEngine;
	using System.Collections;
    using System;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public enum RectAnchor
    {
        Left,
        Top,
        Right,
        Bottom
    }

    public class RectTransformAnchorSetter : UIBehaviour, UnityEngine.UI.ILayoutSelfController
    {
        [SerializeField] private RectTransform rectListener;

        [SerializeField] private RectTransform rectReference = null;
        [SerializeField] RectAnchor targetAnchor = RectAnchor.Bottom;

        public void SetLayoutHorizontal()
        {
            UpdateRect();
        }

        public void SetLayoutVertical()
        {
            UpdateRect();
        }

        public void UpdateRect()
        {
            switch (targetAnchor)
            {
                case RectAnchor.Left:
                    rectListener.SetAnchorMinX(rectReference.anchorMin.x);
                    rectListener.offsetMin = new Vector2(rectReference.GetWidth() / 2f, 0f);
                    break;
                case RectAnchor.Top:
                    rectListener.SetAnchorMaxY(rectReference.anchorMax.y);
                    rectListener.offsetMax = new Vector2(0, -rectReference.GetHeight() / 2f);
                    break;
                case RectAnchor.Right:
                    rectListener.SetAnchorMaxX(rectReference.anchorMax.x);
                    rectListener.offsetMax = new Vector2( -rectReference.GetWidth() / 2f, 0);
                    break;
                case RectAnchor.Bottom:
                    rectListener.SetAnchorMinY(rectReference.anchorMin.y);
                    rectListener.offsetMin = new Vector2(0, rectReference.GetHeight() / 2f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            UpdateRect();
        }
#endif

        protected override void OnRectTransformDimensionsChange()
        {
            UpdateRect();
        }

        protected void Reset()
        {
            if (rectListener == null)
            {
                rectListener = GetComponent<RectTransform>();
            }
        }
    }
}