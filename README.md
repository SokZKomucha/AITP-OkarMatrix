# OkarMatrix

### Krótki opis

Prosta implementacja macierzy MxN napisana w C#. Pięknie zaimplementowana jest tu klasa `OkarMatrix` (**O**s**kar** **Matrix**), która posiada niemalże wszystkie rzeczy wspomniane w treści zadania.

<br>

### Metody i operatory

Do wykorzystania w kodzie dostępne są metody:
- `public OkarMatrix(int x, int y)` - konstruktor tworzący macierz wielkości `x` oraz `y`
- `public OkarMatrix(OkarMatrix matrixToCopy)` - konstruktor kopiujący
- `public void Fill(double value)` - wypełnia całą macierz wartością `value`
- `public void FillRandom(int min, int max)` - wypełnia całą macierz losowymi liczbami w zakresie `min` - `max`
- `public OkarMatrix Transpose()` - transponuje obecną macierz i zwraca transponowaną macierz
- `public OkarMatrix Minor(int row, int col)`
- `public static double Determinant(OkarMatrix m)` - liczy wyznacznik z macierzy `m`, wielkości `MxM`
- `public void Display()` - wyświetla obecną macierz w konsoli
- `public void DisplayInformation()` - wyświetla podstawowe dane dotyczące obecnej macierzy
- `public int GetX()` - zwraca szerokość `x` macierzy
- `public int GetY()` - zwraca wysokość `y` macierzy
- `public string GetName()` - zwraca nazwę macierzy

Do tego operatory:
- `public double this[int x, int y]` - umożliwia przypisanie komórce `m[x, y]` wartości, bądź odczytanie wartości z tej komórki
- `public static OkarMatrix Operator +(OkarMatrix m1, OkarMatrix m2)` - pozwala dodawać macierze, np. `OkarMatrix m3 = m1 + m2;`
- `public static OkarMatrix Operator *(OkarMatrix m1, double value)` - pozwala mnożyć macierze przez scalary, np `m1 *= 2.5;`
- `public static OkarMatrix operator *(OkarMatrix m1, OkarMatrix m2)` - pozwala mnożyć macierze przez inne macierze, np `OkarMatrix m3 = m1 * m2;`

<br>

### Przykładowy kod

Poniżej przykład mnożenia macierzy `m1` przez macierz `m2`, gdzie obie z nich mają losowe wartości:

```csharp
OkarMatrix m1 = new OkarMatrix(3, 2, "Matrix1");
OkarMatrix m2 = new OkarMatrix(2, 3, "Matrix2");
m1.FillRandom(1, 10);
m2.FillRandom(1, 10);

OkarMatrix m3 = m1 * m2;

m1.DisplayInformation();
m1.Display();
m2.DisplayInformation();
m2.Display();
m3.DisplayInformation();
m3.Display();
```

Wynik:

```
Matrix "Matrix1" (3x2)
3  6  1
6  7  8

Matrix "Matrix2) (2x)
2  4
3  7
4  7

Matrix "Matrix1 * Matrix2" (2x2)
28  61
65  129
```

<br>

### Podsumowanie

Za bardzo nie wiem co tu jest do podsumowania. Zrobiłem implementację macierzy w C# która działa, jak powinna. Posiada wszystkie funkcje/metody które powinna posiadać, co prawda nie każda zaimplementowana zgodnie z poleceniem. Niektóre z nich wygodniej było zaimplementować w klasie jako operatory, co z pewnością przekłada się na łatwość użytkowania. Wszystko co tylko się chce można kopiować, chociaż bardzo chętnie przyjąłbym followa na GitHubie w zamian. Miłego dnia! 
