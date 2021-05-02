using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Bunzl.Kitten.API.Domain.User
{
    public class KittenImage
    {
        public KittenImage(Image image)
        {
            if (image == null)
                throw new InvalidOperationException("Image is null");

            Image = image;
        }

        public Image Image { get; }

        public byte[] GetRotatedBy180()
        {
            byte[] result = null;
            RotateBy180();

            using (var ms = new MemoryStream())
            {
                Image.Save(ms, ImageFormat.Jpeg);
                result = ms.ToArray();
            }

            return result;
        }

        private void RotateBy180()
        {
            Image.RotateFlip(RotateFlipType.Rotate180FlipX);
        }
    }
}
