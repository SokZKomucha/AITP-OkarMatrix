
namespace OkarMatrix
{
    internal class OkarMatrix
    {

        private int x = 0;
        private int y = 0;
        private string name = "";
        private double[][] matrix;

        /// <summary>
        /// Zwykły konstruktor. 
        /// Przyjmuje rozmiar x, y orz opcjonalnie - nazwę macierzy.
        /// </summary>
        /// <param name="x"> Szerokość macierzy. </param>
        /// <param name="y"> Wysokość macierzy. </param>
        /// <param name="name"> (opcjonalnie) nazwa macierzy. </param>
        public OkarMatrix(int x, int y, string name = "undefined")
        {
            this.x = x;
            this.y = y;
            this.name = name;

            this.matrix = new double[x][];
            for (int i = 0; i < this.x; i++)
                this.matrix[i] = new double[y];
        }

        /// <summary>
        /// Konstruktor kopiujący.
        /// Przyjmuje oryginał macierzy oraz opcjonalnie - imię nowej macierzy.
        /// </summary>
        /// <param name="matrixToCopy"> Oryginalna macierz. </param>
        /// <param name="name"> (opcjonalnie) nazwa macierzy. </param>
        public OkarMatrix(OkarMatrix matrixToCopy, string name = "undefined")
        {
            this.x = matrixToCopy.x;
            this.y = matrixToCopy.y;
            this.name = name;

            this.matrix = new double[x][];
            for (int i = 0; i < this.x; i++)
                this.matrix[i] = new double[y];

            for (int i = 0; i < this.x; i++)
                for (int j = 0 ; j < this.y; j++)
                    this.matrix[i][j] = matrixToCopy.matrix[i][j];
        }

        /// <summary>
        /// Wypełnia całą macierz jedną wartością.
        /// </summary>
        /// <param name="value"> Wartość, którą zostanie wypełniona macierz </param>
        public void Fill(double value)
        {
            for (int i = 0; i < this.x; i++)
                for (int j = 0; j < this.y; j++)
                    this.matrix[i][j] = value;
        }

        /// <summary>
        /// Wypełnia całą macierz losowymi liczbami w zakresie.
        /// </summary>
        /// <param name="min"> Dolna granica zakresu. </param>
        /// <param name="max"> Górna granica zakresu. </param>
        public void FillRandom(int min, int max)
        {
            Random random = new Random();
            for (int i = 0; i < this.x; i++)
                for (int j = 0; j < this.y; j++)
                    this.matrix[i][j] = random.Next(min, max);
        }

        /// <summary>
        /// Transponuje daną macierz.
        /// </summary>
        /// <returns> Transponowaną macierz. </returns>
        public OkarMatrix Transpose()
        {
            OkarMatrix result = new OkarMatrix(this.y, this.x, this.name + " transposed");
            for (int i = 0; i < this.y; i++)
                for (int j = 0; j  < this.x; j++)
                    result.matrix[i][j] = this.matrix[j][i];
            return result;
        }

        public OkarMatrix Minor(int row, int col)
        {
            if (this.x != this.y)
                throw new Exception("Minor can only be calculated for square matrices.");

            if (row < 0 || row >= this.x || col < 0 || col >= this.y)
                throw new Exception("Row or column index out of bounds.");

            OkarMatrix minorMatrix = new OkarMatrix(this.x - 1, this.y - 1);
            int rowIndex = 0;
            for (int i = 0; i < this.x; i++)
            {
                if (i == row)
                    continue;

                int colIndex = 0;
                for (int j = 0; j < this.y; j++)
                {
                    if (j == col)
                        continue;

                    minorMatrix[rowIndex, colIndex] = this[i, j];
                    colIndex++;
                }

                rowIndex++;
            }

            return minorMatrix;
        }

        /// <summary>
        /// Oblicza wyznacznik macierzy kwadratowej (x*x)
        /// </summary>
        /// <param name="m"> Macierz, na podstawie której obliczany jest wyznacznik. </param>
        /// <returns> Wyznacznik macierzy. </returns>
        /// <exception cref="Exception"> W przypadku złych parametrów, wyrzuca błąd. </exception>
        public static double Determinant(OkarMatrix m)
        {
            if (m.x != m.y)
                throw new Exception("Determinant can only be calculated for square matrices.");

            if (m.x == 1)
                return m[0, 0];

            double determinant = 0;
            for (int i = 0; i < m.x; i++)
            {
                OkarMatrix minorMatrix = m.Minor(0, i);
                determinant += Math.Pow(-1, i) * m[0, i] * OkarMatrix.Determinant(minorMatrix);
            }
            return determinant;
        }

        /// <summary>
        /// Wyświetla zawartość danej macierzy.
        /// </summary>
        public void Display()
        {
            for (int i = 0; i < this.y; i++)
            {
                for (int j = 0; j < this.x; j++)
                    Console.Write(matrix[j][i] + "\t");
                Console.WriteLine();
            } Console.WriteLine();
        }

        /// <summary>
        /// Wyświetla podstawowe informacje dotyczące macierzy.
        /// </summary>
        public void DisplayInformation()
        {
            Console.WriteLine($"\nMatrix \"{this.name}\" ({this.x}x{this.y})");
        }

        /// <summary>
        /// Wyświetla informacje o macierzy + samą macierz
        /// Przyjmuje opcjonalny parametr. Po jego użyciu,
        /// wyświetla dany tekst przed informacjami.
        /// </summary>
        /// <param name="prepend"> Tekst wyświetlany przed macierzą </param>
        public void DisplayAll(string prepend = "")
        {
            if (prepend != "") Console.Write(prepend);
            this.DisplayInformation();
            this.Display();
        }

        /// <summary>
        /// Zwraca szerokość X macierzy.
        /// </summary>
        /// <returns></returns>
        public int GetX() { return this.x; }

        /// <summary>
        /// Zwraca wysokość Y macierzy.
        /// </summary>
        /// <returns></returns>
        public int GetY() { return this.y; }

        /// <summary>
        /// Zwraca nazwę macierzy.
        /// </summary>
        /// <returns></returns>
        public string GetName() { return this.name; }



        /// <summary>
        /// Przeładowany operator służący do zmiany/podglądu elementu na danej pozycji
        /// </summary>
        /// <param name="x"> X elementu. </param>
        /// <param name="y"> Y elementu. </param>
        /// <returns> Zwraca wartość pod (x, y). </returns>
        public double this[int x, int y]
        {
            get { return this.matrix[x][y]; }
            set { this.matrix[x][y] = value; }
        }

        /// <summary>
        /// Operacja dodawania macierzy.
        /// </summary>
        /// <param name="m1"> Macierz 1. </param>
        /// <param name="m2"> Macierz 2. </param>
        /// <returns> Macierz 3 (Wynik sumy macierzy 1 oraz 2). </returns>
        /// <exception cref="Exception"> W przypadku różnych rozmiarów, wyrzuca błąd. </exception>
        public static OkarMatrix operator +(OkarMatrix m1, OkarMatrix m2)
        {
            if (m1.x != m2.x || m1.y != m2.y)
                throw new Exception("Both dimensions for both matrices must be the same.");

            OkarMatrix m3 = new OkarMatrix(m1.x, m1.y, $"{m1.name} + {m2.name}");
            for (int i = 0; i < m3.x; i++)
                for (int j = 0; j < m3.y; j++)
                    m3.matrix[i][j] += m1.matrix[i][j] + m2.matrix[i][j];
            return m3;
        }

        /// <summary>
        /// Operacja mnożenia macierzy przez wartość
        /// </summary>
        /// <param name="m1"> Macierz. </param>
        /// <param name="value"> Wartość. </param>
        /// <returns> Macierz pomnożoną przez wartość. </returns>
        public static OkarMatrix operator *(OkarMatrix m1, double value)
        {
            for (int i = 0; i < m1.x; i++)
                for (int j = 0; j < m1.y; j++)
                    m1.matrix[i][j] *= value;
            return m1;
        }

        /// <summary>
        /// Zwraca wynik mnożenia macierzy 1 przez macierz 2.
        /// </summary>
        /// <param name="m1"> Macierz 1. </param>
        /// <param name="m2"> Macierz 2. </param>
        /// <returns> Wynik mnożenia m1 * m2. </returns>
        /// <exception cref="Exception"></exception>
        public static OkarMatrix operator *(OkarMatrix m1, OkarMatrix m2)
        {
            if (m2.y != m1.x)
                throw new Exception("Matrix multiplication not allowed for those matrices.");

            OkarMatrix result = new OkarMatrix(m2.x, m1.y, $"{m1.name} * {m2.name}");
            result.Fill(0);

            for (int i = 0; i < m2.x; i++)
                for (int j = 0; j < m1.y; j++)
                    for (int k = 0; k < m2.y; k++) 
                        result.matrix[i][j] += m2.matrix[i][k] * m1.matrix[k][j];
            return result;
        
            // Trochę jest tu namieszane, bo mam dziwnie zrobiony x oraz y
            // Poprzednio z m1*m2 wychodził wynik m2*m1 (i na odwrót), ale 
            // ponaprawiałem i teraz jakoś tam działa

            // W przyszłości postaram się zrobić dobrze. Tak, żeby wszyściutko się wyświetlało
            // tak jak powinno, itp. Nie mówię, że teraz jest źle, tylko po prostu kod jest brudny.
        }
    }
}
