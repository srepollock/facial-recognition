    using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace COMP4932_Assignment3.Detect.Imaging
{
    public unsafe class FaceImage : IDisposable
    {

        private int[,] normalSum;
        private int[,] squareSum;
        private int[,] tiltedSum;

        private int* nSum;
        private int* sSum;
        private int* tSum;

        private GCHandle normalHandle;
        private GCHandle squareHandle;
        private GCHandle tiltedHandle;

        private int width;
        private int height;

        private int normWidth;
        private int normHeight;

        private int tiltWidth;
        private int tiltHeight;

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public int[,] getNormal()
        {
            return normalSum;
        }

        public int[,] getSquared()
        {
            return squareSum;
        }

        public int[,] getTitled()
        {
            return tiltedSum;
        }

        public FaceImage(int nW, int nH, bool tilt)
        {
            this.width = nW;
            this.height = nH;

            this.normWidth = nW + 1;
            this.normHeight = nW + 1;

            this.tiltWidth = nW + 2;
            this.tiltHeight = nH + 2;

            this.normalSum = new int[normHeight, normWidth];
            this.normalHandle = GCHandle.Alloc(normalSum, GCHandleType.Pinned);
            this.nSum = (int*)normalHandle.AddrOfPinnedObject().ToPointer();

            this.squareSum = new int[normHeight, normWidth];
            this.squareHandle = GCHandle.Alloc(squareSum, GCHandleType.Pinned);
            this.sSum = (int*)squareHandle.AddrOfPinnedObject().ToPointer();

            if (tilt)
            {
                this.tiltedSum = new int[tiltHeight, tiltWidth];
                this.tiltedHandle = GCHandle.Alloc(tiltedSum, GCHandleType.Pinned);
                this.tSum = (int*)tiltedHandle.AddrOfPinnedObject().ToPointer();
            }

        }

        public static FaceImage FromBitmap(Bitmap image, int channel)
        {
            return FromBitmap(image, channel, false);
        }

        public static FaceImage FromBitmap(Bitmap image, int channel, bool tilt)
        {
            //Check image format
            if (!(image.PixelFormat == PixelFormat.Format8bppIndexed ||
                image.PixelFormat == PixelFormat.Format24bppRgb ||
                image.PixelFormat == PixelFormat.Format32bppArgb))
            {
                throw new UnsupportedImageFormatException("Only grayscale and 24 bpp RGB images are supported");
            }

            BitmapData imageData = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, image.PixelFormat);

            FaceImage im = FromBitmap(imageData, channel, tilt);
            image.UnlockBits(imageData);

            return im;
        }

        public static FaceImage FromBitmap(BitmapData imageData, int channel)
        {
            return FromBitmap(new UnmanagedImage(imageData), channel);
        }

        public static FaceImage FromBitmap(BitmapData imageData, int channel, bool tilt)
        {
            return FromBitmap(new UnmanagedImage(imageData), channel, tilt);
        }

        public static FaceImage FromBitmap(UnmanagedImage image, int channel)
        {
            return FromBitmap(image, channel, false);
        }

        public static FaceImage FromBitmap(UnmanagedImage image, int channel, bool tilt)
        {
            if (!(image.PixelFormat == PixelFormat.Format8bppIndexed ||
                  image.PixelFormat == PixelFormat.Format24bppRgb ||
                  image.PixelFormat == PixelFormat.Format32bppArgb))
            {
                throw new UnsupportedImageFormatException("Only grayscale and 24 bpp RGB images are supported.");
            }

            int pixelSize = System.Drawing.Image.GetPixelFormatSize(image.PixelFormat) / 8;
            int width = image.Width;
            int height = image.Height;
            int stride = image.Stride;
            int offset = stride - width * pixelSize;

            FaceImage im = new FaceImage(width, height, tilt);
            int* nSum = im.nSum, sSum = im.sSum, tSum = im.tSum;

            int nWidth = im.normWidth, nHeight = im.normHeight;
            int tWidth = im.tiltWidth, tHeight = im.tiltHeight;

            if (image.PixelFormat == PixelFormat.Format8bppIndexed && channel != 0)
                throw new ArgumentException("Only the first channel is available for 8 bpp images.", "channel");

            byte* srcStart = (byte*)image.ImageData.ToPointer() + channel;

            byte* src = srcStart;

            for (int y = 1; y <= height; y++)
            {
                int yy = nWidth * (y);
                int y1 = nWidth * (y - 1);

                // for each pixel
                for (int x = 1; x <= width; x++, src += pixelSize)
                {
                    int p1 = *src;
                    int p2 = p1 * p1;

                    int r = yy + (x);
                    int a = yy + (x - 1);
                    int b = y1 + (x);
                    int c = y1 + (x - 1);

                    nSum[r] = p1 + nSum[a] + nSum[b] - nSum[c];
                    sSum[r] = p2 + sSum[a] + sSum[b] - sSum[c];
                }

                src += offset;
            }

            if (tilt)
            {
                src = srcStart;

                // Left-to-right, top-to-bottom pass
                for (int y = 1; y <= height; y++, src += offset)
                {
                    int yy = tWidth * (y);
                    int y1 = tWidth * (y - 1);

                    for (int x = 2; x < width + 2; x++, src += pixelSize)
                    {
                        int a = y1 + (x - 1);
                        int b = yy + (x - 1);
                        int c = y1 + (x - 2);
                        int r = yy + (x);

                        tSum[r] = *src + tSum[a] + tSum[b] - tSum[c];
                    }
                }

                {
                    int yy = tWidth * (height);
                    int y1 = tWidth * (height + 1);

                    for (int x = 2; x < width + 2; x++, src += pixelSize)
                    {
                        int a = yy + (x - 1);
                        int c = yy + (x - 2);
                        int b = y1 + (x - 1);
                        int r = y1 + (x);

                        tSum[r] = tSum[a] + tSum[b] - tSum[c];
                    }
                }

                // Right-to-left, bottom-to-top pass
                for (int y = height; y >= 0; y--)
                {
                    int yy = tWidth * (y);
                    int y1 = tWidth * (y + 1);

                    for (int x = width + 1; x >= 1; x--)
                    {
                        int r = yy + (x);
                        int b = y1 + (x - 1);

                        tSum[r] += tSum[b];
                    }
                }

                for (int y = height + 1; y >= 0; y--)
                {
                    int yy = tWidth * (y);

                    for (int x = width + 1; x >= 2; x--)
                    {
                        int r = yy + (x);
                        int b = yy + (x - 2);

                        tSum[r] -= tSum[b];
                    }
                }
            }

            return im;
        }

        public int GetSum(int x, int y, int width, int height)
        {
            int a = normWidth * (y) + (x);
            int b = normWidth * (y + height) + (x + width);
            int c = normWidth * (y + height) + (x);
            int d = normWidth * (y) + (x + width);

            return nSum[a] + nSum[b] - nSum[c] - nSum[d];
        }

        public int GetSumSquare(int x, int y, int width, int height)
        {
            int a = normWidth * (y) + (x);
            int b = normWidth * (y + height) + (x + width);
            int c = normWidth * (y + height) + (x);
            int d = normWidth * (y) + (x + width);

            return sSum[a] + sSum[b] - sSum[c] - sSum[d];
        }

        public int GetSumTilt(int x, int y, int width, int height)
        {
            int a = tiltWidth * (y + width) + (x + width + 1);
            int b = tiltWidth * (y + height) + (x - height + 1);
            int c = tiltWidth * (y) + (x + 1);
            int d = tiltWidth * (y + width + height) + (x + width - height + 1);

            return tSum[a] + tSum[b] - tSum[c] - tSum[d];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~FaceImage()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //free managed 
            }

            //free native resources
            if (normalHandle.IsAllocated)
            {
                normalHandle.Free();
                nSum = null;
            }

            if (squareHandle.IsAllocated)
            {
                squareHandle.Free();
                sSum = null;
            }

            if (tiltedHandle.IsAllocated)
            {
                tiltedHandle.Free();
                tSum = null;
            }
        }
    }
}
