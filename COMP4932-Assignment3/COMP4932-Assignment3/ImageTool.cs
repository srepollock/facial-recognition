using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics;

namespace COMP4932_Assignment3
{
    class ImageTool
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

        public static void SetImage(Bitmap bmp, double[,] img)
        {
            SetImage(bmp, img, false);
        }

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
            ILRetArray<double> A = ILMath.array(
                array, width, width);
            ILArray<complex> eigVectors = ILMath.array(new complex(0, 0), width * width);
            ILArray<complex> eigValues = ILMath.eig(A, eigVectors);
            return new EigenObject(eigVectors, eigValues, width);
        }

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
    }
}
