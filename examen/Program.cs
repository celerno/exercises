internal class Program
{
    public static bool contiene(int[] arreglo, int valor, int cantidad)
        {
            for (int i = 0; i < arreglo.Length; i++)
            {
                if (arreglo[i] == valor)
                    cantidad--;
                if(cantidad<=0)
                    break;
            }
            return cantidad <= 0;
        }

    public static int mayorDiferencia(int[] arreglo){
        Array.Sort(arreglo);
        return arreglo[arreglo.Length -1] - arreglo[0];
    }
    
    private static void Main(string[] args)
    {
        int[] arreglo = new int[] {4, 5, 2, 4, 5, 9, 9, 4, 4};
       Console.WriteLine(mismaDiferencia(new decimal[] { 1, 3, 5 })); // true
        Console.WriteLine(mismaDiferencia(new decimal[] { 194, 54, 23, 7, 3, 6, 8 })); // false
       Console.WriteLine(mismaDiferencia(new decimal[] {44, 37, 30, 23 })); // true
        Console.WriteLine(mismaDiferencia(new decimal[] { -2.3M, -1.1M, 0.1M, 1.3M, 2.5M, 3.7M })); // true
        Console.WriteLine(mismaDiferencia(new decimal[] { 1, 8 })); // true
        Console.WriteLine(mismaDiferencia(new decimal[] { 3, 2, 1, 2, 3, 4, 3})); // true
/*
        Console.WriteLine(mayorDiferencia( new int[] { 1, 1, 4 })); // 3
        Console.WriteLine(mayorDiferencia( new int[] { 9, 8 })); // 1
        Console.WriteLine(mayorDiferencia( new int[] { 6, 22, 16, 29, 23 })); // 23
        Console.WriteLine(mayorDiferencia( new int[] { 28, 16, 28, 11, 14, 26, 23, 25, 17, 3, 22, 23, 23, 10 })); // 25
*/
       /* Console.WriteLine(contiene(arreglo, 4, 5)); // Regresa false;
        Console.WriteLine(contiene(arreglo, 4, 4)); // Regresa true;
                        Console.WriteLine(contiene(arreglo, 4, 3)); // Regresa true;

        Console.WriteLine(contiene(arreglo, 9, 2)); // Regresa true;*/
    }
}