using System;

class DRomb
{
    // Захищені поля
    protected int d1, d2; // діагоналі
    protected int c; // колір ромба

    // Конструктор
    public DRomb(int diagonal1, int diagonal2, int color)
    {
        d1 = diagonal1;
        d2 = diagonal2;
        c = color;
    }

    // Методи
    public void DisplayLengths()
    {
        Console.WriteLine($"Діагональ 1: {d1}");
        Console.WriteLine($"Діагональ 2: {d2}");
    }

    public double Perimeter()
    {
        return 2 * (d1 + d2);
    }

    public double Area()
    {
        return 0.5 * d1 * d2;
    }

    public bool IsSquare()
    {
        return d1 == d2;
    }

    // Властивості
    public int Diagonal1
    {
        get { return d1; }
        set { d1 = value; }
    }

    public int Diagonal2
    {
        get { return d2; }
        set { d2 = value; }
    }

    public int Color
    {
        get { return c; }
    }

    // Індексатор
    public object this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return d1;
                case 1:
                    return d2;
                case 2:
                    return c;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index), "Непідтримуваний індекс.");
            }
        }
        set
        {
            switch (index)
            {
                case 0:
                    d1 = (int)value;
                    break;
                case 1:
                    d2 = (int)value;
                    break;
                case 2:
                    c = (int)value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index), "Непідтримуваний індекс.");
            }
        }
    }

    // Перевантаження операторів
    public static DRomb operator ++(DRomb romb)
    {
        romb.d1++;
        romb.d2++;
        return romb;
    }

    public static DRomb operator --(DRomb romb)
    {
        romb.d1--;
        romb.d2--;
        return romb;
    }

    public static bool operator true(DRomb romb)
    {
        return romb.IsSquare();
    }

    public static bool operator false(DRomb romb)
    {
        return !romb.IsSquare();
    }

    public static DRomb operator +(DRomb romb, int scalar)
    {
        romb.d1 += scalar;
        romb.d2 += scalar;
        return romb;
    }

    public static explicit operator string(DRomb romb)
    {
        return $"DRomb: d1={romb.d1}, d2={romb.d2}, Color={romb.c}";
    }

    public static explicit operator DRomb(string s)
    {
        // Реалізуйте розбір рядка тут
        throw new NotImplementedException();
    }

    // Main метод, точка входу для програми
    static void Main(string[] args)
    {
        // Приклад використання класу DRomb
        DRomb romb = new DRomb(5, 5, 1);
        romb.DisplayLengths();
        Console.WriteLine($"Perimeter: {romb.Perimeter()}");
        Console.WriteLine($"Area: {romb.Area()}");
        Console.WriteLine($"IsSquare: {romb.IsSquare()}");
    }
}