// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         // Приклад створення матриці та використання основних методів
//         MatrixUlong matrix = new MatrixUlong(2, 3); // Створюємо матрицю 2x3
//         Console.WriteLine("Enter values for matrix:");
//         matrix.InputValues(); // Введення значень матриці з клавіатури
//         Console.WriteLine("Matrix values:");
//         matrix.DisplayValues(); // Виведення значень матриці на екран

//         // Приклад використання індексаторів
//         Console.WriteLine("Value at index [1,2]: " + matrix[1, 2]); // Отримання значення за індексами
//         matrix[1, 2] = 10; // Присвоєння нового значення за індексами
//         Console.WriteLine("Modified matrix:");
//         matrix.DisplayValues(); // Виведення зміненого стану матриці

//         // Приклад використання індексатора з одним індексом
//         Console.WriteLine("Value at index [4]: " + matrix[4]); // Отримання значення за одним індексом (індексом k)

//         // Приклад використання властивостей
//         Console.WriteLine("Number of rows: " + matrix.Rows);
//         Console.WriteLine("Number of columns: " + matrix.Columns);
//         Console.WriteLine("Error code: " + matrix.CodeError);

//         // Приклад перевантаження операторів
//         MatrixUlong anotherMatrix = new MatrixUlong(2, 3);
//         Console.WriteLine("Are matrices equal? " + (matrix == anotherMatrix)); // Порівняння матриць
//         Console.WriteLine("Are matrices not equal? " + (matrix != anotherMatrix)); // Порівняння матриць
//         Console.WriteLine("Is matrix true? " + matrix); // Перевірка на true
//         Console.WriteLine("Is matrix false? " + !matrix); // Перевірка на false
//     }
// }


// public class MatrixUlong
// {
//     protected ulong[,] ULArray; 
//     protected uint n, m; 
//     protected int codeError; 
//     protected static int num_m;

//     public MatrixUlong()
//     {
//         n = 1;
//         m = 1;
//         ULArray = new ulong[n, m];
//         codeError = 0;
//         num_m++;
//     }

//     public MatrixUlong(uint rows, uint cols)
//     {
//         n = rows;
//         m = cols;
//         ULArray = new ulong[n, m];
//         codeError = 0;
//         num_m++;
//     }

//     public MatrixUlong(uint rows, uint cols, ulong initValue)
//     {
//         n = rows;
//         m = cols;
//         ULArray = new ulong[n, m];
//         for (uint i = 0; i < n; i++)
//         {
//             for (uint j = 0; j < m; j++)
//             {
//                 ULArray[i, j] = initValue;
//             }
//         }
//         codeError = 0;
//         num_m++;
//     }

//     ~MatrixUlong()
//     {
//         Console.WriteLine("Destructor called for MatrixUlong");
//     }

//     public void InputValues()
//     {
//         for (uint i = 0; i < n; i++)
//         {
//             for (uint j = 0; j < m; j++)
//             {
//                 Console.Write($"Enter value at [{i},{j}]: ");
//                 ULArray[i, j] = Convert.ToUInt64(Console.ReadLine());
//             }
//         }
//     }

//     public void DisplayValues()
//     {
//         for (uint i = 0; i < n; i++)
//         {
//             for (uint j = 0; j < m; j++)
//             {
//                 Console.Write($"{ULArray[i, j]} ");
//             }
//             Console.WriteLine();
//         }
//     }

//     public void AssignValue(ulong value)
//     {
//         for (uint i = 0; i < n; i++)
//         {
//             for (uint j = 0; j < m; j++)
//             {
//                 ULArray[i, j] = value;
//             }
//         }
//     }

//     public static int CountMatrices()
//     {
//         return num_m;
//     }

//     public ulong this[uint i, uint j]
//     {
//         get
//         {
//             if (i < n && j < m)
//             {
//                 codeError = 0;
//                 return ULArray[i, j];
//             }
//             else
//             {
//                 codeError = -1;
//                 return 0;
//             }
//         }
//         set
//         {
//             if (i < n && j < m)
//             {
//                 ULArray[i, j] = value;
//             }
//             else
//             {
//                 codeError = -1;
//             }
//         }
//     }

//     public ulong this[uint k]
//     {
//         get
//         {
//             uint i = k / m;
//             uint j = k % m;
//             if (i < n && j < m)
//             {
//                 codeError = 0;
//                 return ULArray[i, j];
//             }
//             else
//             {
//                 codeError = -1;
//                 return 0;
//             }
//         }
//         set
//         {
//             uint i = k / m;
//             uint j = k % m;
//             if (i < n && j < m)
//             {
//                 ULArray[i, j] = value;
//             }
//             else
//             {
//                 codeError = -1;
//             }
//         }
//     }

//     public uint Rows => n;

//     public uint Columns => m;

//     public int CodeError
//     {
//         get { return codeError; }
//         set { codeError = value; }
//     }

//     public static bool operator true(MatrixUlong matrix)
//     {
//         if (matrix.n != 0 && matrix.m != 0)
//         {
//             for (uint i = 0; i < matrix.n; i++)
//             {
//                 for (uint j = 0; j < matrix.m; j++)
//                 {
//                     if (matrix.ULArray[i, j] == 0)
//                         return false;
//                 }
//             }
//             return true;
//         }
//         return false;
//     }

//     public static bool operator false(MatrixUlong matrix)
//     {
//         return !matrix;
//     }

//     public static bool operator !(MatrixUlong matrix)
//     {
//         return matrix.n != 0 && matrix.m != 0;
//     }

//     // Other unary and binary operator overloads can be added here as required
// }