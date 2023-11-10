
using OkarMatrix;

namespace OkarMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Przykładowy program mnożący dwie macierze
            
            OkarMatrix m1 = new OkarMatrix(3, 2, "Matrix1");
            OkarMatrix m2 = new OkarMatrix(2, 3, "Matrix2");
            m1.FillRandom(1, 10);
            m2.FillRandom(1, 10);
            
            OkarMatrix m3 = m1 * m2;
            
            m1.DisplayAll();
            m2.DisplayAll();
            m3.DisplayAll();

        }
    }
}
