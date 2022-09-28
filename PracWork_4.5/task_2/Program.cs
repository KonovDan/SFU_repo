int[,] convert(int[,] b) {
	int[,] temp = new int[,]{};
	for (int i = 0; i < b.Length; i++) {
		for (int j = 0; j < b.Length; j++) {
			temp[i,j]=b[b.Length-j-1,i];
		}
	}
	return temp;
}

void printArray(int[,] f) {
	for (int i = 0; i < f.Length; i++) {
		for (int j = 0; j < f.Length; j++) {
			Console.WriteLine(f[i,j] + " ");
		}
		Console.WriteLine();
	}
}

void main() {
	int[,] b = new int[,]{ { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 } };
    b = convert(b);
	foreach(int i in b) Console.Write(i);
}

main();