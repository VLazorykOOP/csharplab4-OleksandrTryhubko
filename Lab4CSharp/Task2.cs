// using System;

// class VectorULong
// {
//     protected ulong[] IntArray;
//     protected uint size;
//     protected int codeError;
//     protected static uint num_vec;

//     public VectorULong()
//     {
//         IntArray = new ulong[1];
//         size = 1;
//         codeError = 0;
//         num_vec++;
//     }

//     public VectorULong(uint size)
//     {
//         IntArray = new ulong[size];
//         this.size = size;
//         codeError = 0;
//         num_vec++;
//     }

//     public VectorULong(uint size, ulong initValue)
//     {
//         IntArray = new ulong[size];
//         this.size = size;
//         codeError = 0;
//         for (int i = 0; i < size; i++)
//         {
//             IntArray[i] = initValue;
//         }
//         num_vec++;
//     }

//     ~VectorULong()
//     {
//         Console.WriteLine("Destructor is called");
//     }

//     public void InputValues()
//     {
//         for (int i = 0; i < size; i++)
//         {
//             Console.WriteLine("Enter value for element {0}: ", i);
//             IntArray[i] = Convert.ToUInt64(Console.ReadLine());
//         }
//     }

//     public void DisplayValues()
//     {
//         for (int i = 0; i < size; i++)
//         {
//             Console.WriteLine("Element {0}: {1}", i, IntArray[i]);
//         }
//     }

//     public void AssignValue(ulong value)
//     {
//         for (int i = 0; i < size; i++)
//         {
//             IntArray[i] = value;
//         }
//     }

//     public static uint CountVectors()
//     {
//         return num_vec;
//     }

//     public uint Size
//     {
//         get { return size; }
//     }

//     public int CodeError
//     {
//         get { return codeError; }
//         set { codeError = value; }
//     }

//     public ulong this[int index]
//     {
//         get
//         {
//             if (index < 0 || index >= size)
//             {
//                 codeError = -1;
//                 return 0;
//             }
//             else
//             {
//                 codeError = 0;
//                 return IntArray[index];
//             }
//         }
//         set
//         {
//             if (index < 0 || index >= size)
//             {
//                 codeError = -1;
//             }
//             else
//             {
//                 codeError = 0;
//                 IntArray[index] = value;
//             }
//         }
//     }

//     public static VectorULong operator ++(VectorULong vec)
//     {
//         for (int i = 0; i < vec.size; i++)
//         {
//             vec.IntArray[i]++;
//         }
//         return vec;
//     }

//     public static VectorULong operator --(VectorULong vec)
//     {
//         for (int i = 0; i < vec.size; i++)
//         {
//             vec.IntArray[i]--;
//         }
//         return vec;
//     }

//     public static bool operator true(VectorULong vec)
//     {
//         return vec.size != 0 && Array.TrueForAll(vec.IntArray, x => x != 0);
//     }

//     public static bool operator false(VectorULong vec)
//     {
//         return vec.size == 0 || Array.TrueForAll(vec.IntArray, x => x == 0);
//     }

//     public static bool operator !(VectorULong vec)
//     {
//         return !(vec);
//     }

//     public static VectorULong operator ~(VectorULong vec)
//     {
//         VectorULong result = new VectorULong(vec.size);
//         for (int i = 0; i < vec.size; i++)
//         {
//             result[i] = ~vec.IntArray[i];
//         }
//         return result;
//     }

//     public static VectorULong operator +(VectorULong vec1, VectorULong vec2)
//     {
//         uint newSize = Math.Max(vec1.size, vec2.size);
//         VectorULong result = new VectorULong(newSize);
//         for (int i = 0; i < newSize; i++)
//         {
//             result[i] = vec1[i] + vec2[i];
//         }
//         return result;
//     }

//     public static VectorULong operator +(VectorULong vec, ulong scalar)
//     {
//         VectorULong result = new VectorULong(vec.size);
//         for (int i = 0; i < vec.size; i++)
//         {
//             result[i] = vec[i] + scalar;
//         }
//         return result;
//     }

//     public static VectorULong operator -(VectorULong vec1, VectorULong vec2)
//     {
//         uint newSize = Math.Max(vec1.size, vec2.size);
//         VectorULong result = new VectorULong(newSize);
//         for (int i = 0; i < newSize; i++)
//         {
//             result[i] = vec1[i] - vec2[i];
//         }
//         return result;
//     }

//     public static VectorULong operator -(VectorULong vec, ulong scalar)
//     {
//         VectorULong result = new VectorULong(vec.size);
//         for (int i = 0; i < vec.size; i++)
//         {
//             result[i] = vec[i] - scalar;
//         }
//         return result;
//     }

//     public static VectorULong operator *(VectorULong vec1, VectorULong vec2)
//     {
//         uint newSize = Math.Max(vec1.size, vec2.size);
//         VectorULong result = new VectorULong(newSize);
//         for (int i = 0; i < newSize; i++)
//         {
//             result[i] = vec1[i] * vec2[i];
//         }
//         return result;
//     }

//     public static VectorULong operator *(VectorULong vec, ulong scalar)
//     {
//         VectorULong result = new VectorULong(vec.size);
//         for (int i = 0; i < vec.size; i++)
//         {
//             result[i] = vec[i] * scalar;
//         }
//         return result;
//     }

//     public static VectorULong operator /(VectorULong vec1, VectorULong vec2)
//     {
//         uint newSize = Math.Max(vec1.size, vec2.size);
//         VectorULong result = new VectorULong(newSize);
//         for (int i = 0; i < newSize; i++)
//         {
//             if (vec2[i] == 0)
//                 throw new DivideByZeroException("Division by zero.");
//             result[i] = vec1[i] / vec2[i];
//         }
//         return result;
//     }

//     public static VectorULong operator /(VectorULong vec, ulong scalar)
//     {
//         if (scalar == 0)
//             throw new DivideByZeroException("Division by zero.");
//         VectorULong result = new VectorULong(vec.size);
//         for (int i = 0; i < vec.size; i++)
//         {
//             result[i] = vec[i] / scalar;
//         }
//         return result;
//     }

//     public static VectorULong operator %(VectorULong vec1, VectorULong vec2)
//     {
//         uint newSize = Math.Max(vec1.size, vec2.size);
//         VectorULong result = new VectorULong(newSize);
//         for (int i = 0; i < newSize; i++)
//         {
//             if (vec2[i] == 0)
//                 throw new DivideByZeroException("Modulo by zero.");
//             result[i] = vec1[i] % vec2[i];
//         }
//         return result;
//     }

//     public static VectorULong operator %(VectorULong vec, ulong scalar)
//     {
//         if (scalar == 0)
//             throw new DivideByZeroException("Modulo by zero.");
//         VectorULong result = new VectorULong(vec.size);
//         for (int i = 0; i < vec.size; i++)
//         {
//             result[i] = vec[i] % scalar;
//         }
//         return result;
//     }

//     public static VectorULong operator |(VectorULong vec1, VectorULong vec2)
//     {
//         uint newSize = Math.Max(vec1.size, vec2.size);
//         VectorULong result = new VectorULong(newSize);
//         for (int i = 0; i < newSize; i++)
//         {
//             result[i] = vec1[i] | vec2[i];
//         }
//         return result;
//     }

//     public static VectorULong operator |(VectorULong vec, ulong scalar)
//     {
//         VectorULong result = new VectorULong(vec.size);
//         for (int i = 0; i < vec.size; i++)
//         {
//             result[i] = vec[i] | scalar;
//         }
//         return result;
//     }

//     public static VectorULong operator ^(VectorULong vec1, VectorULong vec2)
//     {
//         uint newSize = Math.Max(vec1.size, vec2.size);
//         VectorULong result = new VectorULong(newSize);
//         for (int i = 0; i < newSize; i++)
//         {
//             result[i] = vec1[i] ^ vec2[i];
//         }
//         return result;
//     }

//     public static VectorULong operator ^(VectorULong vec, ulong scalar)
//     {
//         VectorULong result = new VectorULong(vec.size);
//         for (int i = 0; i < vec.size; i++)
//         {
//             result[i] = vec[i] ^ scalar;
//         }
//         return result;
//     }

//     public static VectorULong operator &(VectorULong vec1, VectorULong vec2)
//     {
//         uint newSize = Math.Max(vec1.size, vec2.size);
//         VectorULong result = new VectorULong(newSize);
//         for (int i = 0; i < newSize; i++)
//         {
//             result[i] = vec1[i] & vec2[i];
//         }
//         return result;
//     }

//     public static VectorULong operator &(VectorULong vec, ulong scalar)
//     {
//         VectorULong result = new VectorULong(vec.size);
//         for (int i = 0; i < vec.size; i++)
//         {
//             result[i] = vec[i] & scalar;
//         }
//         return result;
//     }

//     public static VectorULong RightShift(VectorULong vec1, int shift)
//     {
//         VectorULong result = new VectorULong(vec1.size);
//         ulong mask = (ulong.MaxValue << (64 - shift)); // Create a mask for shifting
//         for (int i = 0; i < vec1.size; i++)
//         {
//             result[i] = vec1[i] >> shift;
//             // Apply mask for negative numbers
//             if ((vec1[i] & 0x8000000000000000) != 0)
//                 result[i] |= mask;
//         }
//         return result;
//     }

//     public static VectorULong LeftShift(VectorULong vec1, int shift)
//     {
//         VectorULong result = new VectorULong(vec1.size);
//         ulong mask = (ulong.MaxValue >> (64 - shift)); // Create a mask for shifting
//         for (int i = 0; i < vec1.size; i++)
//         {
//             result[i] = vec1[i] << shift;
//             // Apply mask for overflow
//             if ((vec1[i] & 0x8000000000000000) != 0)
//                 result[i] &= ~mask;
//         }
//         return result;
//     }

//     public static bool operator ==(VectorULong vec1, VectorULong vec2)
//     {
//         if (vec1.size != vec2.size)
//             return false;
//         for (int i = 0; i < vec1.size; i++)
//         {
//             if (vec1[i] != vec2[i])
//                 return false;
//         }
//         return true;
//     }

//     public static bool operator !=(VectorULong vec1, VectorULong vec2)
//     {
//         return !(vec1 == vec2);
//     }

//     public static bool operator >(VectorULong vec1, VectorULong vec2)
//     {
//         if (vec1.size != vec2.size)
//             throw new ArgumentException("Vectors must have the same size for comparison");
//         for (int i = 0; i < vec1.size; i++)
//         {
//             if (vec1[i] <= vec2[i])
//                 return false;
//         }
//         return true;
//     }

//     public static bool operator >=(VectorULong vec1, VectorULong vec2)
//     {
//         if (vec1.size != vec2.size)
//             throw new ArgumentException("Vectors must have the same size for comparison");
//         for (int i = 0; i < vec1.size; i++)
//         {
//             if (vec1[i] < vec2[i])
//                 return false;
//         }
//         return true;
//     }

//     public static bool operator <(VectorULong vec1, VectorULong vec2)
//     {
//         if (vec1.size != vec2.size)
//             throw new ArgumentException("Vectors must have the same size for comparison");
//         for (int i = 0; i < vec1.size; i++)
//         {
//             if (vec1[i] >= vec2[i])
//                 return false;
//         }
//         return true;
//     }

//     public static bool operator <=(VectorULong vec1, VectorULong vec2)
//     {
//         if (vec1.size != vec2.size)
//             throw new ArgumentException("Vectors must have the same size for comparison");
//         for (int i = 0; i < vec1.size; i++)
//         {
//             if (vec1[i] > vec2[i])
//                 return false;
//         }
//         return true;
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         VectorULong vec1 = new VectorULong(3, 10);
//         VectorULong vec2 = new VectorULong(3, 5);

//         Console.WriteLine("Vector 1:");
//         vec1.DisplayValues();

//         Console.WriteLine("\nVector 2:");
//         vec2.DisplayValues();

//         Console.WriteLine("\nVector 1 + Vector 2:");
//         (vec1 + vec2).DisplayValues();

//         Console.WriteLine("\nVector 1 + 2:");
//         (vec1 + 2).DisplayValues();

//         Console.WriteLine("\nVector 1 - Vector 2:");
//         (vec1 - vec2).DisplayValues();

//         Console.WriteLine("\nVector 1 - 2:");
//         (vec1 - 2).DisplayValues();

//         Console.WriteLine("\nVector 1 * Vector 2:");
//         (vec1 * vec2).DisplayValues();

//         Console.WriteLine("\nVector 1 * 2:");
//         (vec1 * 2).DisplayValues();

//         Console.WriteLine("\nVector 1 / Vector 2:");
//         (vec1 / vec2).DisplayValues();

//         Console.WriteLine("\nVector 1 / 2:");
//         (vec1 / 2).DisplayValues();

//         Console.WriteLine("\nVector 1 % Vector 2:");
//         (vec1 % vec2).DisplayValues();

//         Console.WriteLine("\nVector 1 % 2:");
//         (vec1 % 2).DisplayValues();

//         Console.WriteLine("\nVector 1 | Vector 2:");
//         (vec1 | vec2).DisplayValues();

//         Console.WriteLine("\nVector 1 & Vector 2:");
//         (vec1 & vec2).DisplayValues();

//         Console.WriteLine("\nVector 1 ^ Vector 2:");
//         (vec1 ^ vec2).DisplayValues();

//         Console.WriteLine("\nVector 1 >> 2:");
//         VectorULong.RightShift(vec1, 2).DisplayValues();

//         Console.WriteLine("\nVector 1 << 2:");
//         VectorULong.LeftShift(vec1, 2).DisplayValues();

//         Console.WriteLine("\nVector 1 > Vector 2: " + (vec1 > vec2));
//         Console.WriteLine("Vector 1 >= Vector 2: " + (vec1 >= vec2));
//         Console.WriteLine("Vector 1 < Vector 2: " + (vec1 < vec2));
//         Console.WriteLine("Vector 1 <= Vector 2: " + (vec1 <= vec2));

//         Console.WriteLine("\nNumber of vectors: {0}", VectorULong.CountVectors());
//     }
// }