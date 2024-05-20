def ford_bellman(graph, start):
    dist = {}
    pred = {}
    for versh in graph:
        dist[versh] = float('inf')
        pred[versh] = None
    dist[start] = 0

    for i in range(len(graph) - 1):
        for u in graph:
            for v, w in graph[u]:
                if dist[u] + w < dist[v]:
                    dist[v] = dist[u] + w
                    pred[v] = u

                    # Ищет контур отрицательного веса
    for u in graph:
        for v, w in graph[u]:
            if dist[u] + w < dist[v]:
                print("Граф содержит цикл отрицательного веса")
                return None, None

    return dist, pred


def reconstruct_path(start, end, pred):
    # Восстановление пути
    path = []
    current = end
    while current is not None:
        path.append(current)
        current = pred[current]
    path.reverse()
    return path


graph = {
    'V1': [('V2', 1), ('V5', 3)],
    'V2': [('V3', 8), ('V4', 7), ('V5',1)],
    'V3': [('V4', 1)],
    'V4': [('V3', 2)],
    'V5': [('V4', 4)],
}

start = 'V1'
dist, pred = ford_bellman(graph, start)

if dist is not None:
    for versh in dist:
        print("Расстояние от", start, "до", versh, "равно", dist[versh])

    print("Путь от", start, "до 'V1':", reconstruct_path(start, 'V1', pred))
    print("Путь от", start, "до 'V2':", reconstruct_path(start, 'V2', pred))
    print("Путь от", start, "до 'V3':", reconstruct_path(start, 'V3', pred))
    print("Путь от", start, "до 'V4':", reconstruct_path(start, 'V4', pred))
    print("Путь от", start, "до 'V5':", reconstruct_path(start, 'V5', pred))


else:
    print("В графе присутствует цикл отрицательного веса.")
