using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ILNumerics;

namespace COMP4932_Assignment3
{
    public static class ImageTool
    {
        public static double[,] GetGreyScale(Bitmap bmp)
        {
            double[,] result = new double[bmp.Height, bmp.Width];
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color tmp = bmp.GetPixel(j, i);
                    result[i, j] = (tmp.R + tmp.G + tmp.B) / 3;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the grayscale bitmap of the bitmap passed in.
        /// </summary>
        /// <param name="orgBmp">Bitmap to grayscale</param>
        /// <returns>Grayscaled image</returns>
        public static Bitmap grayscale(Bitmap orgBmp)
        {
            int width = orgBmp.Width, height = orgBmp.Height;
            Bitmap bmp = new Bitmap(width, height);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color p = orgBmp.GetPixel(x, y);
                    int g = (int)(0 + (0.299 * p.R) + (0.587 * p.G) + (0.114 * p.B));
                    bmp.SetPixel(x, y, Color.FromArgb(255, g, g, g));
                }
            }
            return bmp;
        }

        /// <summary>
        /// Gets a double 2D array of pixels.
        /// </summary>
        /// <param name="bmp">Bitmap to get pixels from</param>
        /// <returns>Double 2D array of pixels</returns>
        public static double[,] GetArray(Bitmap bmp)
        {
            double[,] result = new double[bmp.Height, bmp.Width];
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    result[i, j] = bmp.GetPixel(j, i).R;
                }
            }
            return result;
        }

        /// <summary>
        /// Sets the Bitmap passed in to the pixel array.
        /// </summary>
        /// <param name="bmp">Bitmap to change</param>
        /// <param name="img">Pixel array to change</param>
        public static void SetImage(Bitmap bmp, double[,] img)
        {
            SetImage(bmp, img, false);
        }

        /// <summary>
        /// Sets each pixel in the bitmap to each pixel from the array.
        /// </summary>
        /// <param name="bmp">Bitmap to change</param>
        /// <param name="img">Double 2D array of pixels</param>
        /// <param name="shift">Bitshift on/off</param>
        public static void SetImage(Bitmap bmp, double[,] img, bool shift)
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    int s = 0;
                    if (shift)
                        s = 128;
                    int val = (int)img[j, i] + s;
                    if (val < 0)
                        val = 0;
                    if (val > 255)
                        val = 255;
                    bmp.SetPixel(i, j, Color.FromArgb(val, val, val));
                }
            }
        }

        /// <summary>
        /// Sets the bitmap to each pixel in the complex array.
        /// </summary>
        /// <param name="bmp">Bitmap to change</param>
        /// <param name="img">Complex array of pixels</param>
        public static void SetImage(Bitmap bmp, complex[,] img)
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    double pxl = img[j, i].Abs() * 500;
                    bmp.SetPixel(i, j, Color.FromArgb((int)pxl, (int)pxl, (int)pxl));
                }
            }
        }

        // TODO Use this funciton when passing in the face snapshot
        /// <summary>
        /// Gets the eigen object from the bitmap.
        /// </summary>
        /// <param name="bmp">Bitmap to get the eigenface from</param>
        /// <returns>EigenObject</returns>
        public static EigenObject GetEigen(Bitmap bmp)
        {
            int width = bmp.Width;
            double[] array = new double[width * width];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    array[i * width + j] = bmp.GetPixel(i, j).R;
                }
            }
            ILArray<double> A = ILMath.array(
                array, width, width);
            ILArray<complex> eigVectors = ILMath.array(new complex(0, 0), width * width);
            ILArray<complex> eigValues = ILMath.eig(A, eigVectors);
            return new EigenObject(eigVectors, eigValues, width);
        }

        /// <summary>
        /// Gets the eigen object from a double 2D array of pixels.
        /// </summary>
        /// <param name="a">Array of pixels (bitmap)</param>
        /// <returns>EigenObject</returns>
        public static EigenObject GetEigen(double[,] a)
        {
            int width = a.GetLength(0);
            double[] array = new double[width * width];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    array[i * width + j] = a[i, j];
                }
            }
            ILRetArray<double> A = ILMath.array(array, width, width);
            ILArray<complex> eigVectors = ILMath.array(new complex(0, 0), width * width);
            ILArray<complex> eigValues = ILMath.eig(A, eigVectors);
            return new EigenObject(eigVectors, eigValues, width);
        }

        // TODO Get the average face of the library
        /// <summary>
        /// Gets the average face of the library.
        /// </summary>
        /// <param name="lib">Library to get the average face from.</param>
        /// <returns></returns>
        public static double[,] GetAvg(double[][,] lib)
        {
            double[,] result = new double[lib[0].GetLength(0), lib[0].GetLength(1)];
            for (int k = 0; k < lib.Length; k++)
            {
                for (int i = 0; i < lib[0].GetLength(0); i++)
                {
                    for (int j = 0; j < lib[0].GetLength(1); j++)
                    {
                        result[i, j] += lib[k][i, j] / lib.GetLength(0);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the difference of the library to the average face. Use with double 2D array for the average.
        /// </summary>
        /// <param name="lib">Library to get the faces</param>
        /// <param name="avg">Average face</param>
        /// <returns>Differences as a [1D][2D] array</returns>
        public static double[][,] GetDifferenceArray(double[][,] lib, double[,] avg)
        {
            double[][,] dif = new double[lib.Length][,];
            for (int k = 0; k < lib.Length; k++)
            {
                dif[k] = new double[lib[0].GetLength(0), lib[0].GetLength(1)];
                for (int i = 0; i < lib[0].GetLength(0); i++)
                {
                    for (int j = 0; j < lib[0].GetLength(1); j++)
                    {
                        dif[k][i, j] = lib[k][i, j] - avg[i, j];
                    }
                }
            }
            return dif;
        }

        // TODO Is this function for each individual image?
        /// <summary>
        /// Gets the differences of the libraries images, and the average face.
        /// </summary>
        /// <param name="lib">Library (picture?) as double 2D array</param>
        /// <param name="avg">Averae face double 2D array</param>
        /// <returns>Double 2D array</returns>
        public static double[,] GetDifference(double[,] lib, double[,] avg)
        {
            double[,] dif = new double[lib.GetLength(0), lib.GetLength(1)];
            for (int i = 0; i < lib.GetLength(0); i++)
            {
                for (int j = 0; j < lib.GetLength(1); j++)
                {
                    dif[i, j] = lib[i, j] - avg[i, j];
                }
            }

            return dif;
        }

        /// <summary>
        /// Gets an array from the library. As the length?
        /// </summary>
        /// <param name="lib">Double [1D][2D] array of the library</param>
        /// <returns>Double 2D array</returns>
        public static double[,] GetA(double[][,] lib)
        {
            double[,] A = new double[lib.Length, lib[0].GetLength(0) * lib[0].GetLength(1)];
            double[,] At = new double[lib[0].GetLength(0) * lib[0].GetLength(1), lib.Length];
            int length = lib[0].GetLength(0);
            for (int k = 0; k < lib.Length; k++)
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        A[k, i * length + j] = lib[k][i, j];
                        At[i * length + j, k] = lib[k][i, j];
                    }
                }
            }
            double[,] result = MatrixMult(A, At);
            return result;
        }

        /// <summary>
        /// Multiplies a matrix by another of the same size.
        /// </summary>
        /// <param name="a">Matrix 1</param>
        /// <param name="b">Matrix 2</param>
        /// <returns>New Double 2D matrix</returns>
        public static double[,] MatrixMult(double[,] a, double[,] b)
        {
            int length = a.GetLength(0);
            double[,] result = new double[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < length; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        // TODO What do I do with this?
        /// <summary>
        /// Get the eigen faces in the difFaces.
        /// </summary>
        /// <param name="eigenVector">Complex 2D array of eigenvectors (calculated?)</param>
        /// <param name="difFace">Double [1D][2D] array of difference faces</param>
        /// <returns>Double [1D][2D] array of eigenfaces</returns>
        public static double[][,] getEigenFaces(complex[,] eigenVector, double[][,] difFace)
        {
            double[][,] eFaces = new double[eigenVector.GetLength(1)][,];
            for (int m = 0; m < eigenVector.GetLength(1); m++)
            {
                eFaces[m] = new double[difFace[0].GetLength(0), difFace[0].GetLength(1)];
                for (int k = 0; k < eigenVector.GetLength(0); k++)
                {
                    for (int i = 0; i < difFace[k].GetLength(0); i++)
                    {
                        for (int j = 0; j < difFace[k].GetLength(1); j++)
                        {
                            eFaces[m][i, j] += difFace[k][i, j] * eigenVector[m, k].real;
                        }
                    }
                }
            }
            return eFaces;
        }

        // TODO This gets the weight of the image in the facespace? How useable it is?
        /// <summary>
        /// Gets the weights of the faces, based on the test face and the average face compared to the whole array
        /// </summary>
        /// <param name="eigFaces">Eigen face array</param>
        /// <param name="testFace">Test face to check Double 2D array</param>
        /// <param name="avgFace">Average face (calculated) Double 2D array</param>
        /// <returns></returns>
        public static double[] getWeights(double[][,] eigFaces, double[,] testFace, double[,] avgFace)
        {
            double[] weights = new double[eigFaces.Length];
            double[,] difFace = new double[testFace.GetLength(0), testFace.GetLength(1)];
            int length = testFace.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    difFace[i, j] = testFace[i, j] - avgFace[i, j];
                }
            }
            for (int k = 0; k < eigFaces.Length; k++)
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        weights[k] += eigFaces[k][i, j] * difFace[i, j];
                    }
                }
            }
            return weights;
        }

        // TODO Recreates the image face based on the image
        /// <summary>
        /// Recreate the face based on the weights, eigen faces and average face.
        /// </summary>
        /// <param name="weights">Weights of the face to recreate.</param>
        /// <param name="eigFaces">Eigen faces array</param>
        /// <param name="avg">Average face</param>
        /// <returns>Reconstructed image as a Double 2D array</returns>
        public static double[,] reconstruct(double[] weights, double[][,] eigFaces, double[,] avg)
        {
            int length = eigFaces[0].GetLength(0);
            double[,] result = new double[length, length];
            //normalize(weights);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    for (int k = 0; k < eigFaces.Length; k++)
                    {
                        result[i, j] += eigFaces[k][i, j] * weights[k] / eigFaces.Length;
                    }
                }
            }
            normalize(result, 128);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    result[i, j] += avg[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Normalizes the vectors passed in.
        /// </summary>
        /// <param name="v">Vector array to normalize</param>
        public static void normalize(complex[,] v)
        {
            for (int i = 0; i < v.GetLength(1); i++)
            {
                double length = 0;
                for (int j = 0; j < v.GetLength(0); j++)
                {
                    length += v[j, i].real * v[j, i].real;
                }
                length = Math.Sqrt(length);
                for (int j = 0; j < v.GetLength(0); j++)
                {
                    v[j, i].real = v[j, i].real / length;
                }
            }
        }

        /// <summary>
        /// Normalizes the weights.
        /// </summary>
        /// <param name="w">Weght array to normalize</param>
        public static void normalize(double[] w)
        {
            double length = 0;
            for (int i = 1; i < w.Length; i++)
            {
                length += w[i] * w[i];
            }
            length = Math.Sqrt(length);
            for (int i = 0; i < w.Length; i++)
            {
                w[i] /= length;
            }
        }

        /// <summary>
        /// Normalizes the array passed in, based to the max value.
        /// </summary>
        /// <param name="a">Array to normalize</param>
        /// <param name="max">Maximum value</param>
        public static void normalize(double[,] a, double max)
        {
            double top = Math.Abs(a[0, 0]);
            int length = a.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (Math.Abs(a[i, j]) > top)
                        top = Math.Abs(a[i, j]);
                }
            }
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    a[i, j] = a[i, j] / top * max;
                }
            }
        }

        /// <summary>
        /// Compares the library weights to the weights of the testing image.
        /// </summary>
        /// <param name="libWieghts">Library weight 2D array</param>
        /// <param name="testWeigths">Test weight 1D array</param>
        /// <returns>Double 1D array</returns>
        public static double[] compareWeigths(double[][] libWieghts, double[] testWeigths)
        {
            double[] result = new double[libWieghts.Length];
            for (int i = 0; i < libWieghts.Length; i++)
            {
                for (int j = 0; j < libWieghts[0].Length; j++)
                {
                    result[i] += Math.Pow(libWieghts[i][j] - testWeigths[j], 2);
                }
            }
            for (int k = 0; k < result.Length; k++)
            {
                result[k] = Math.Log10(Math.Sqrt(result[k]));
            }
            return result;
        }

        /// <summary>
        /// Finds the smallest value in the array.
        /// </summary>
        /// <param name="d">Array to find</param>
        /// <returns>Smallest value in the array</returns>
        public static int smallestVal(double[] d)
        {
            double smallest = d[0];
            int index = 0;
            for (int i = 1; i < d.Length; i++)
            {
                if (d[i] < smallest)
                {
                    smallest = d[i];
                    index = i;
                }
            }
            return index;
        }


        public static double[][,] avgSubsets(double[][,] faces, int setSize)
        {
            double[][,] result = new double[faces.Length / setSize][,];
            for (int k = 0; k <= faces.Length - setSize; k += setSize)
            {
                result[k / setSize] = new double[faces[0].GetLength(0), faces[0].GetLength(1)];
                for (int s = 0; s < setSize; s++)
                {
                    for (int i = 0; i < faces[0].GetLength(0); i++)
                    {
                        for (int j = 0; j < faces[0].GetLength(1); j++)
                        {
                            result[k / setSize][i, j] += faces[k + s][i, j] / setSize;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Get the difference between the two images as Double 2D arrays.
        /// </summary>
        /// <param name="img1">Image 1</param>
        /// <param name="img2">Image 2</param>
        /// <returns>The difference between the two images.</returns>
        public static double difference(double[,] img1, double[,] img2)
        {
            double result = 0;
            for (int i = 0; i < img1.GetLength(0); i++)
            {
                for (int j = 0; j < img1.GetLength(1); j++)
                {
                    result += Math.Pow(img1[i, j] - img2[i, j], 2);
                }
            }
            result = Math.Sqrt(result);
            return result;
        }

        /// <summary>
        /// Gets the differences of between the frams at frame i and i+1
        /// </summary>
        /// <param name="i">Index where to grab the frames</param>
        /// <returns>Bitmap of the differences</returns>
        public static Bitmap getDifference(int i, ref Data data)
        {
            Bitmap f = data.grayscales.ElementAt(i);
            Bitmap l;
            if (i + 1 >= data.grayscales.Count) l = data.grayscales.ElementAt(0); // Next image
            else l = data.grayscales.ElementAt(i + 1); // Next image
            if (f.Width != l.Width) { MessageBox.Show("Images must be the same width!"); return null; }
            Bitmap diff = new Bitmap(f.Width, f.Height);
            for (int x = 0; x < f.Width; x++)
            {
                for (int y = 0; y < f.Height; y++)
                {
                    int fp = (int)f.GetPixel(x, y).R;
                    int lp = (int)l.GetPixel(x, y).R;
                    int dp = fp - lp; // Get pixel, minus first from last
                    if (dp < data.threshold) dp = 0; // Threshold
                    diff.SetPixel(x, y, Color.FromArgb(255, dp, dp, dp));
                }
            }
            return diff;
        }
    }
}
