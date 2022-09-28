string find_longest(string str) {
    string[] tmp = str.Split();
    string m = "";
    int l = 0;
    for (int i = 0; i < tmp.Length; i++) {
        if (tmp[i].Length > l) {m = tmp[i]; l = tmp[i].Length;}
    }
    return m;
}


Console.WriteLine(find_longest("The template Console App was created successfully"));





