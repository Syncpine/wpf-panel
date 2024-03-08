using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace wpf_panel
{
    public class WpfCanvas : Panel
    {
        public WpfCanvas()
        {
            _leftLength = new Dictionary<UIElement, double>();
            _topLength = new Dictionary<UIElement, double>();
            _rightLength = new Dictionary<UIElement, double>();
            _bottomLength = new Dictionary<UIElement, double>();
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size childConstraint = new Size(Double.PositiveInfinity, Double.PositiveInfinity);

            foreach (UIElement child in InternalChildren)
            {
                if (child == null)
                {
                    continue;
                }

                child.Measure(childConstraint);
            }

            return new Size();
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                if (child == null)
                {
                    continue;
                }

                double x = 0;
                double y = 0;

                double left = GetLeft(child);
                if (!double.IsNaN(left))
                {
                    x = left;
                }
                else
                {
                    double right = GetRight(child);

                    if (!double.IsNaN(right))
                    {
                        x = finalSize.Width - child.DesiredSize.Width - right;
                    }
                }

                double top = GetTop(child);
                if (!double.IsNaN(top))
                {
                    y = top;
                }
                else
                {
                    double bottom = GetBottom(child);

                    if (!double.IsNaN(bottom))
                    {
                        y = finalSize.Height - child.DesiredSize.Height - bottom;
                    }
                }

                child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
            }

            return finalSize;
        }

        public static void SetLeft(UIElement element, double length)
        {
            _leftLength[element] = length;
        }

        public static void SetTop(UIElement element, double length)
        {
            _topLength[element] = length;
        }

        public static void SetRight(UIElement element, double length)
        {
            _rightLength[element] = length;
        }

        public static void SetBottom(UIElement element, double length)
        {
            _bottomLength[element] = length;
        }

        public static double GetLeft(UIElement element)
        {
            if (_leftLength.ContainsKey(element))
            {
                return _leftLength[element];
            }

            return double.NaN;
        }

        public static double GetTop(UIElement element)
        {
            if (_topLength.ContainsKey(element))
            {
                return _topLength[element];
            }

            return double.NaN;
        }

        public static double GetRight(UIElement element)
        {
            if (_rightLength.ContainsKey(element))
            {
                return _rightLength[element];
            }

            return double.NaN;
        }

        public static double GetBottom(UIElement element)
        {
            if (_bottomLength.ContainsKey(element))
            {
                return _bottomLength[element];
            }

            return double.NaN;
        }

        private static Dictionary<UIElement, double> _leftLength;

        private static Dictionary<UIElement, double> _topLength;

        private static Dictionary<UIElement, double> _rightLength;

        private static Dictionary<UIElement, double> _bottomLength;
    }
}