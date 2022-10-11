const int N = 10;

int[] array = new int[N];
for (int i = 0; i < N; i++) array[i] = new Random().Next() % 100;

int f1() {return array.Max();}

int f2(int[] array)
{
    int lower = 0; for (int i = 0; i < array.Length; i++) if (array[i] <= 0) { lower = i; break; }
    int upper = 0; for (int i = lower + 1; i < array.Length; i++) if (array[i] <= 0) { upper = i; break; }
    int sum = 0; for (int i = lower + 1; i < upper; i++) sum += array[i];
    return sum;
}

void f3(int[] array)
{
    const int L = 50;

    for (int i = 0, a = 0; i < array.Length; i++)
    {
        if (Math.Abs(array[i]) < L)
        {
            int tmp = array[a];
            array[a] = array[i];
            array[i] = tmp;
            a++;
        }
    }
}

