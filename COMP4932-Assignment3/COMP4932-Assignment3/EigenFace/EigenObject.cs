namespace EigenFace
{
    using System.Linq;
    using ILNumerics;

    /// <summary>
    /// Contains the vectors and values of an image.
    /// </summary>
    public class EigenObject
    {
        /// <summary>
        /// Complex value array for the Eigen face.
        /// </summary>
        public complex[] Values { get; set; }

        /// <summary>
        /// Complex double array of vectors for the Eigen face.
        /// </summary>
        public complex[,] Vectors { get; set; }

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="vec">Vectors for the Eigen face.</param>
        /// <param name="val">Values of the Eigen face.</param>
        public EigenObject(complex[,] vec, complex[] val) {
            Vectors = vec;
            Values = val;
        }

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="vec">ILArray of complex vectors for the Eigen Face.</param>
        /// <param name="val">ILArray of complex vectors values for the Eigen Face.</param>
        /// <param name="width">Width of the image.</param>
        public EigenObject(ILArray<complex> vec, ILArray<complex> val, int width) {
            Vectors = ILArray2Array(vec, width);
            Values = ILArray2Values(val, width);
        }

        /// <summary>
        /// ILArray changer to a new 2D array.
        /// </summary>
        /// <param name="il">ILArray of values.</param>
        /// <param name="width">Width of the image.</param>
        /// <returns>Complex 2D array.</returns>
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

        /// <summary>
        /// ILArray changer to values in a complex array.
        /// </summary>
        /// <param name="il">ILArray of values.</param>
        /// <param name="width">Width of the image.</param>
        /// <returns>Complex array.</returns>
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
