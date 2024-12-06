Console.WriteLine("{0,-10} {1,-8} {2,-30} {3,-30}", "Type", "Bytes", "Min Value", "Max Value");
Console.WriteLine(new string('-', 80)); // Separator line

Console.WriteLine("{0,-10} {1,-8} {2,-30} {3,-30}", "sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
Console.WriteLine("{0,-10} {1,-8} {2,-30} {3,-30}", "byte", sizeof(byte), byte.MinValue, byte.MaxValue);
Console.WriteLine("{0,-10} {1,-8} {2,-30} {3,-30}", "short", sizeof(short), short.MinValue, short.MaxValue);
Console.WriteLine("{0,-10} {1,-8} {2,-30} {3,-30}", "ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
Console.WriteLine("{0,-10} {1,-8} {2,-30} {3,-30}", "int", sizeof(int), int.MinValue, int.MaxValue);
Console.WriteLine("{0,-10} {1,-8} {2,-30} {3,-30}", "uint", sizeof(uint), uint.MinValue, uint.MaxValue);
Console.WriteLine("{0,-10} {1,-8} {2,-30} {3,-30}", "long", sizeof(long), long.MinValue, long.MaxValue);
Console.WriteLine("{0,-10} {1,-8} {2,-30} {3,-30}", "ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
Console.WriteLine("{0,-10} {1,-8} {2,-30} {3,-30}", "float", sizeof(float), float.MinValue, float.MaxValue);
Console.WriteLine("{0,-10} {1,-8} {2,-30} {3,-30}", "double", sizeof(double), double.MinValue, double.MaxValue);
Console.WriteLine("{0,-10} {1,-8} {2,-30} {3,-30}", "decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);