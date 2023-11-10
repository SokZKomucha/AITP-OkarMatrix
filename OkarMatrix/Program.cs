
using OkarMatrix;

namespace OkarMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Sama klasa OkarMatrix jest lekko okrojona w porównaniu do implementacji
            // w C++, głównie dlatego, że nie znalazłem* operatorów streamowania oraz 
            // metody na przeładowanie przyrównania. Na pocieszenie wszystkie inne operatory
            // działają, a do tego jest jeszcze operator `matrix[i, j]`, za pomocą którego możemy 
            // (get)ować wartości z danego miejsca w matrixie, bądź je tam set(ować).
            // * nie znalazłem = nie chciało mi się szukać

            // Paradoksalnie cały ten program jest starszy od połowy implementacji w 
            // CPlusPlusie, więc brak przeciążenia strumieni oraz przyrównania wynika z
            // mojego nadmiernego lenistwa. Chociaż tak teraz (w chwili pisania) jak na to patrzę,
            // to przyrównania nie można overloadować. Mimo wszystko, jestem o wiele bardziej dumny
            // z tego, niż oryginału w C++.



            OkarMatrix m1 = new OkarMatrix(3, 2, "Ania");
            m1.FillRandom(1, 10);
            m1.DisplayAll("1) Deklaracja i wyświetlanie macierzy:");

            OkarMatrix m2 = new OkarMatrix(3, 2, "Zosia");
            OkarMatrix m3 = new OkarMatrix(3, 2, "Julka");
            m2.FillRandom(1, 10);
            m3.FillRandom(1, 10);
            OkarMatrix m2m3added = m2 + m3;
            m2.DisplayAll("\n2) Dodawanie dwóch macierzy:");
            m3.DisplayAll();
            m2m3added.DisplayAll();

            OkarMatrix m4 = new OkarMatrix(3, 2, "Aleksandra");
            m4.FillRandom(1, 10);
            m4.DisplayAll("\n3) Mnożenie macierzy przez scalar:");
            m4 *= 5;
            m4.DisplayAll();

            OkarMatrix m5 = new OkarMatrix(3, 2, "Karolina");
            OkarMatrix m6 = new OkarMatrix(2, 3, "Zuzanna");
            m5.FillRandom(1, 10);
            m6.FillRandom(1, 10);
            OkarMatrix m5m6multiplied = m5 * m6;
            m5.DisplayAll("\n4) Mnożenie dwóch macierzy:");
            m6.DisplayAll();
            m5m6multiplied.DisplayAll();

            OkarMatrix m7 = new OkarMatrix(3, 2, "Magda");
            m7.FillRandom(1, 10);
            OkarMatrix m7transposed = m7.Transpose();
            m7.DisplayAll("\n5) Transponowanie macierzy");
            m7transposed.DisplayAll();

            OkarMatrix m8 = new OkarMatrix(3, 3, "Halina");
            m8.FillRandom(1, 10);
            double det = OkarMatrix.Determinant(m8);
            m8.DisplayAll("\n6) Wyznacznik macierzy:");
            Console.WriteLine("Wyznacznik: " +  det);

            // Nie będę prezentował konstruktora kopiującego, bo
            // nie mam pomysłu jak. Tak samo destruktora, chociaż
            // tu nawet nie mam, bo nie ma po co.

        }
    }
}