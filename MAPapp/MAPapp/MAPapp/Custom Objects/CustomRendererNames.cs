using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MAPapp {
    class CustomRendererNames {
    }

    public class ImageButton : Button {
        Image image;
        public ImageButton()
        {

        }
        public new sealed class ButtonContentLayout {
            public enum ImagePosition {
                Left,
                Top,
                Right,
                Bottom
            }

            public ButtonContentLayout(ImagePosition position, double spacing)
            {
                Position = ImagePosition.Right;//position;
                Spacing = spacing;
            }

            public ImagePosition Position { get; }

            public double Spacing { get; }

            public override string ToString()
            {
                return $"Image Position = {Position}, Spacing = {Spacing}";
            }
        }
        /*
        public new sealed class ButtonContentTypeConverter : TypeConverter {
            public override object ConvertFromInvariantString(string value)
            {
                if (value == null)
                {
                    throw new InvalidOperationException($"Cannot convert null into {typeof(ButtonContentLayout)}");
                }

                string[] parts = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 1 && parts.Length != 2)
                {
                    throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(ButtonContentLayout)}");
                }

                double spacing = DefaultSpacing;
                var position = ButtonContentLayout.ImagePosition.Left;

                var spacingFirst = char.IsDigit(parts[0][0]);

                int positionIndex = spacingFirst ? (parts.Length == 2 ? 1 : -1) : 0;
                int spacingIndex = spacingFirst ? 0 : (parts.Length == 2 ? 1 : -1);

                if (spacingIndex > -1)
                {
                    spacing = double.Parse(parts[spacingIndex]);
                }

                if (positionIndex > -1)
                {
                    position =
                        (ButtonContentLayout.ImagePosition)Enum.Parse(typeof(ButtonContentLayout.ImagePosition), parts[positionIndex], true);
                }

                return new ButtonContentLayout(position, spacing);
            }
        }
        */
            public Image CompleteImage
        {
            get { return image; }
            set { image = value; }
        }
    }
}
