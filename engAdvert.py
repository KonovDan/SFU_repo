import random
import itertools as iter

N = 1

LIST_1 = ["свежие", "вкусные", "замечательные", "прекрасные", "сочные"]
LIST_2 = ["персики", "яблоки", "ананасы", "бананы", "манго"]
LIST_3 = ["южных", "шведских", "российских", "австралийских", "германских"]


def main():
    for i in range(N): print(random.choice([i for i in generate()]))


def generate():
    lst_all = []

    for x, y, z in iter.product(LIST_1, LIST_2, LIST_3):
        lst_all.append(
            "Попробуйте наши {} {} которые мы вырастили для вас на наших {} фермах".format(x, y, z))
    random.shuffle(lst_all)
    for i in lst_all:
        yield i


if __name__ == "__main__":
    main()
