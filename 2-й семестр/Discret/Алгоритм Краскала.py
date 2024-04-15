vertex, edge = map(int, input("Введите количество вершин и ребер графа через пробел \n").split())
edges = []

for i in range(edge):
    vertex1, vertex2, weight = map(int, input("Введите начало ребра, конец ребра и вес ребра через пробел: \n").split())
    edges.append([weight,vertex1, vertex2])
edges.sort()
graf = [i for i in range(vertex)]
answer = 0
for weight,vertex1,vertex2 in edges:
    if graf[vertex1-1] != graf[vertex2-1]:
        answer +=weight
        a = graf[vertex1-1]
        b = graf[vertex2 - 1]
        for i in range(vertex):
            if graf[i] == b:
                graf[i] = a
print(answer)


# 7 вершин 17 ребер
# 1 2 4
# 1 6 1
# 1 4 3
# 1 5 6
# 2 3 2
# 2 6 6
# 2 7 1
# 2 4 3
# 2 5 7
# 3 5 4
# 3 7 2
# 4 6 5
# 4 7 3
# 4 5 1
# 5 6 3
# 5 7 6
# 6 7 7
