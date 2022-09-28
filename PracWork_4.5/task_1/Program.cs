const int N = 10;

int[] array = new int[N]{0};
for (int i = 0; i < N; i++) array[i] = new Random.Next();


int max = array.Max();

int lower= 0; for (int i = 0; i < array.Length; i++) if (array[i] <= 0) {lower= i; break;}
int upper= 0; for (int i = l; i < array.Length; i++) if (array[i] <= 0) {upper= i; break;}
int sum = 0; for (int i = lower + 1; i < upper; i++) sum += array[i];

