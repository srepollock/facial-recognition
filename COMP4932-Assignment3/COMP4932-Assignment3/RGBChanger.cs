using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP4932_Assignment3
{
    public static class RGBChanger
    {
        /* 
            Takes in an array of data that is the image RGB data
            Then converts it to YCbCr data
            Then returns the YCbCr data

            Needs to take in the data of the image

            returns the new bitmap
        */
        /// <summary>
        /// Changes RGB to YCbCr and saves the data into the Data object.
        /// </summary>
        /// <remarks>
        /// RGB -> YCbCr
        /// Takes in the bitmap of the original image, then changes the image
        /// to YCbCr data.
        /// Then returns the YCbCr data.
        /// </remarks>
        /// <param name="orgBmp">Original bitmap to base the image off</param>
        /// <param name="dataObj">Data object to save the data to</param>
        public static Bitmap RGBtoYCbCr(Bitmap orgBmp, ref Data dataObj)
        {
            Bitmap bmp = orgBmp;

            int width = bmp.Width;
            int height = bmp.Height;
            int[,] yData = new int[width, height];                     //luma
            byte[,] CbData = new byte[width, height];                     //Cb
            byte[,] CrData = new byte[width, height];                     //Cr
            Color[,] YCbCrData = new Color[width, height];

            unsafe
            {
                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                int heightInPixels = bitmapData.Height;
                int widthInBytes = width * 3;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                //Convert to YCbCr
                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < width; x++)
                    {
                        int xPor3 = x * 3;
                        float blue = currentLine[xPor3++];
                        float green = currentLine[xPor3++];
                        float red = currentLine[xPor3];

                        yData[x, y] = (int)(0 + (0.299 * red) + (0.587 * green) + (0.114 * blue));
                        CbData[x, y] = (byte)(128 - (0.168 * red) - (0.331264 * green) + (0.5 * blue));
                        CrData[x, y] = (byte)(128 + (0.5 * red) - (0.418688 * green) - (0.081312 * blue));

                        YCbCrData[x, y] = Color.FromArgb(yData[x, y], CbData[x, y], CrData[x, y]);
                    }
                }
                bmp.UnlockBits(bitmapData);
            }
            Bitmap output = new Bitmap(bmp.Width, bmp.Height);
            for (int x = 0; x < bmp.Width; x++) {
                for(int y = 0; y < bmp.Height; y++)
                {
                    output.SetPixel(x, y, Color.FromArgb(255, yData[x,y], yData[x, y], yData[x, y]));
                }
            }
            return output;
        }

        /*
        /// <summary>
        /// Changes RGB to YCbCr and saves the data into the Data object. 
        /// Depends on the image number
        /// </summary>
        /// <remarks>
        /// RGB -> YCbCr
        /// Takes in the bitmap of the original image, then changes the image
        /// to YCbCr data.
        /// Then returns the YCbCr data.
        /// </remarks>
        /// <param name="orgBmp">Original bitmap to base the image off</param>
        /// <param name="dataObj">Data object to save the data to</param>
        /// <param name="PicNum">Number of the image to read in the data</param>
        public void RGBtoYCbCr(Bitmap orgBmp, ref Data dataObj, int picNum)
        {
            Bitmap bmp = orgBmp;

            int width, height;

            if (picNum == 1)
            {
                width = dataObj.mv1Head.getWidth();
                height = dataObj.mv1Head.getHeight();
            }
            else
            {
                width = dataObj.mv2Head.getWidth();
                height = dataObj.mv2Head.getHeight();
            }
            byte[,] yData = new byte[width, height];                     //luma
            byte[,] CbData = new byte[width, height];                     //Cb
            byte[,] CrData = new byte[width, height];                     //Cr
            Color[,] YCbCrData = new Color[width, height];

            unsafe
            {
                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                int heightInPixels = bitmapData.Height;
                int widthInBytes = width * 3;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                //Convert to YCbCr
                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < width; x++)
                    {
                        int xPor3 = x * 3;
                        float blue = currentLine[xPor3++];
                        float green = currentLine[xPor3++];
                        float red = currentLine[xPor3];

                        yData[x, y] = (byte)(0 + (0.299 * red) + (0.587 * green) + (0.114 * blue));
                        CbData[x, y] = (byte)(128 - (0.168 * red) - (0.331264 * green) + (0.5 * blue));
                        CrData[x, y] = (byte)(128 + (0.5 * red) - (0.418688 * green) - (0.081312 * blue));

                        YCbCrData[x, y] = Color.FromArgb(yData[x, y], CbData[x, y], CrData[x, y]);
                    }
                }
                bmp.UnlockBits(bitmapData);
            }
            if (picNum == 1)
            {
                dataObj.setyData(yData);
                dataObj.setCbData(CbData);
                dataObj.setCrData(CrData);
                dataObj.setYCrCbData(YCbCrData);
            }
            else if (picNum == 2)
            {
                dataObj.setyData2(yData);
                dataObj.setCbData2(CbData);
                dataObj.setCrData2(CrData);
                dataObj.setYCrCbData2(YCbCrData);
            }
        }

        /// <summary>
        /// Changes YCbCr data back into RGB data and saves it to the Data
        /// object.
        /// </summary>
        /// <remarks>
        /// YCbCr -> RGB
        /// Changes the data in the data object to RGB data. Then saves the
        /// data back to the Data object.
        /// </remarks>
        /// <param name="dataObj">Data object to read and save the data from/to</param>
        public void YCbCrtoRGB(ref Data dataObj, Header head)
        {

            int width = head.getWidth();
            int height = head.getHeight();
            byte[,] rData = new byte[width, height];
            byte[,] gData = new byte[width, height];
            byte[,] bData = new byte[width, height];

            // Can't use the height and width of original. Needs to be the sub sampled size
            // need to handle doubling up the information
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int r, g, b;

                    r = (int)(dataObj.yData[x, y] + (1.402 * ((dataObj.CrData[x, y] - 128))));
                    g = (int)(dataObj.yData[x, y] - (0.34414 * (dataObj.CbData[x, y] - 128)) - (0.71414 * (dataObj.CrData[x, y] - 128)));
                    b = (int)(dataObj.yData[x, y] + (1.772 * (dataObj.CbData[x, y] - 128)));

                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    rData[x, y] = (byte)r;
                    gData[x, y] = (byte)g;
                    bData[x, y] = (byte)b;
                }
            }
            dataObj.setrData(rData);
            dataObj.setgData(gData);
            dataObj.setbData(bData);
        }

        /// <summary>
        /// Changes YCbCr data back into RGB data and saves it to the Data
        /// object.
        /// </summary>
        /// <remarks>
        /// YCbCr -> RGB
        /// Changes the data in the data object to RGB data. Then saves the
        /// data back to the Data object.
        /// </remarks>
        /// <param name="dataObj">Data object to read and save the data from/to</param>
        public void YCbCrtoRGB(ref Data dataObj, MHeader head)
        {

            int width = head.getWidth();
            int height = head.getHeight();
            byte[,] rData = new byte[width, height];
            byte[,] gData = new byte[width, height];
            byte[,] bData = new byte[width, height];

            // Can't use the height and width of original. Needs to be the sub sampled size
            // need to handle doubling up the information
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int r, g, b;

                    r = (int)(dataObj.yData[x, y] + (1.402 * ((dataObj.CrData[x, y] - 128))));
                    g = (int)(dataObj.yData[x, y] - (0.34414 * (dataObj.CbData[x, y] - 128)) - (0.71414 * (dataObj.CrData[x, y] - 128)));
                    b = (int)(dataObj.yData[x, y] + (1.772 * (dataObj.CbData[x, y] - 128)));

                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    rData[x, y] = (byte)r;
                    gData[x, y] = (byte)g;
                    bData[x, y] = (byte)b;
                }
            }
            dataObj.setrData(rData);
            dataObj.setgData(gData);
            dataObj.setbData(bData);
        }

        /// <summary>
        /// Changes YCbCr data back into RGB data and saves into the Data 
        /// object.
        /// </summary>
        /// <remarks>
        /// sYCbCr -> RGB
        /// Changes the data in the data object to RGB data. Then saves the
        /// data back to the Data object.
        /// This is for sbytes
        /// 
        /// * Don't know if I really need this function. Is it not the exact
        /// same as above?
        /// </remarks>
        /// <param name="dataObj">Data object to read and save the data from/to</param>
        public void sYCbCrtoRGB(ref Data dataObj)
        {
            int width = dataObj.gHead.getWidth();
            int height = dataObj.gHead.getHeight();
            byte[,] rData = new byte[width, height];
            byte[,] gData = new byte[width, height];
            byte[,] bData = new byte[width, height];

            Bitmap outBmp = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int r, g, b;

                    r = (int)(dataObj.getdyData()[x, y] + (1.402 * ((dataObj.getdCrData()[x, y] - 128))));
                    g = (int)(dataObj.getdyData()[x, y] - (0.34414 * (dataObj.getdCbData()[x, y] - 128)) - (0.71414 * (dataObj.getdCrData()[x, y] - 128)));
                    b = (int)(dataObj.getdyData()[x, y] + (1.772 * (dataObj.getdCbData()[x, y] - 128)));

                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    rData[x, y] = (byte)r;
                    gData[x, y] = (byte)g;
                    bData[x, y] = (byte)b;
                }
            }
            dataObj.setrData(rData);
            dataObj.setgData(gData);
            dataObj.setbData(bData);
        }

        /// <summary>
        /// Changes YCbCr data back into RGB data and saves into the Data 
        /// object.
        /// </summary>
        /// <remarks>
        /// sYCbCr -> RGB
        /// Changes the data in the data object to RGB data. Then saves the
        /// data back to the Data object.
        /// This is for sbytes
        /// 
        /// * Don't know if I really need this function. Is it not the exact
        /// same as above?
        /// </remarks>
        /// <param name="dataObj">Data object to read and save the data from/to</param>
        public void sYCbCrtoRGB(ref Data dataObj, MHeader head)
        {
            int width = head.getWidth();
            int height = head.getHeight();
            byte[,] rData = new byte[width, height];
            byte[,] gData = new byte[width, height];
            byte[,] bData = new byte[width, height];

            Bitmap outBmp = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int r, g, b;

                    r = (int)(dataObj.getdyData()[x, y] + (1.402 * ((dataObj.getdCrData()[x, y] - 128))));
                    g = (int)(dataObj.getdyData()[x, y] - (0.34414 * (dataObj.getdCbData()[x, y] - 128)) - (0.71414 * (dataObj.getdCrData()[x, y] - 128)));
                    b = (int)(dataObj.getdyData()[x, y] + (1.772 * (dataObj.getdCbData()[x, y] - 128)));

                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    rData[x, y] = (byte)r;
                    gData[x, y] = (byte)g;
                    bData[x, y] = (byte)b;
                }
            }
            dataObj.setrData(rData);
            dataObj.setgData(gData);
            dataObj.setbData(bData);
        }
        */
    }
}
