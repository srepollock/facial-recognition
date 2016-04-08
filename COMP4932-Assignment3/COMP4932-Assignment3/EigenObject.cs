using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILNumerics;

namespace COMP4932_Assignment3
{
    /// <summary>
    /// Contains the vectors and values of an image.
    /// </summary>
    public class EigenObject
    {
        public complex[] Values { get; set; }
        public complex[,] Vectors { get; set; }

        public EigenObject(complex[,] vec, complex[] val) {
            Vectors = vec;
            Values = val;
        }

        public EigenObject(ILArray<complex> vec, ILArray<complex> val, int width) {
            Vectors = ILArray2Array(vec, width);
            Values = ILArray2Values(val, width);
        }

        public complex[,] ILArray2Array(ILArray<complex> il, int width) {
            complex[,] result = new complex[width, width];
            complex[] ila = il.ToArray();
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < width; j++) {
                    result[i, j] = ila[i*width + j];
                }
            }
            return result;
        }

        public complex[] ILArray2Values(ILArray<complex> il, int width) {
            complex[] result = new complex[width];
            complex[] ila = il.ToArray();
            for (int i = 0; i < width; i++) {
                result[i] = ila[i*width + i];
            }
            return result;
        }
    }
}
