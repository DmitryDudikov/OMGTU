edges = [(1, 2), (1, 6), (1, 4), (1, 5), (2, 3), (2, 6), (2, 7), (2, 4), (2, 5), (3, 5), (3, 7), (4, 6), (4, 7), (4, 5),
     (5, 6), (5, 7), (6, 7)]
weightOfEdges = [4, 1, 3, 6, 2, 6, 1, 3, 7, 4, 2, 5, 3, 1, 3, 6, 7]

graph = [(y, x[0], x[1]) for x, y in zip(edges, weightOfEdges)]
connected = {1}
def searchConnection(connection):
    return [x for x in graph if (x[1] in connection or x[2] in connection) and not (x[1] in connection and x[2] in connection)]

weight = 0
while True:
    search = searchConnection(connected)
    if len(search) == 0:
        break

    search.sort(key=lambda x: x[0])
    _weight, v1, v2 = search[0]
    weight += _weight

    connected.add(v1)
    connected.add(v2)

print(weight)
