class Program
{
    static void Main()
    {
        int[] arr1 = {3, 2, 4, -1};
        int k1 = 2;
        int[] res1 = RotateAndSum(arr1, k1);
        Console.WriteLine(string.Join(" ", res1));
        
        int[] arr2 = {1, 2, 3, 4, 5};
        int k2 = 3;
        int[] res2 = RotateAndSum(arr2, k2);
        Console.WriteLine(string.Join(" ", res2));
    }

    static int[] RotateAndSum(int[] arr, int k)
    {
        int n = arr.Length;
        int[] sum = new int[n];

        for(int r = 1; r <= k; r++)
        {
            int[] rotated = new int[n];

            for(int i = 0; i < n; i++)
                rotated[(i + r) % n] = arr[i];

            for(int i = 0; i < n; i++)
                sum[i] += rotated[i];
        }

        return sum;
    }
}