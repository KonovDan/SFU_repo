// int R = new Random().Next(3, 10);
// int C = new Random().Next(3, 10);

int R = 3; int C = 3;

// int[,] array = new int[R, C];

int[] characteristics = new int[C];

for (int c = 0, n = 0; c < array.GetLength(1); c++, n = 0)
{
    for (int r = 0; r < array.GetLength(0); r++)
    {
        if (array[r, c] != Math.Abs(array[r, c])) n += Math.Abs(array[r, c]);
    }
    characteristics[c] = n;
}


for (int i = 0; i < C - 1; i++)
    for (int j = 0; j < C - 1; j++)
    {
        if (characteristics[j] > characteristics[j + 1])
        {
            int tmp = characteristics[j];
            characteristics[j] = characteristics[j + 1];
            characteristics[j + 1] = tmp;

            int[] tmpArray = new int[R];
            for (int index = 0; index < R; index++) tmpArray[index] = array[index, j];
            for (int index = 0; index < R; index++) array[index, j] = array[index, j + 1];
            for (int index = 0; index < R; index++) array[index, j + 1] = tmpArray[index];
        }
    }

for (int r = 0; r < R; r++)
{
    for (int c = 0; c < C; c++)
        Console.Write($"{array[r, c]} ");
    Console.WriteLine();
}