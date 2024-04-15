graph = [
        [1, 2],
        [3, 4],
        [3, 5],
        [4, 5],
        [6, 7],
        [6, 8],
        [7, 9],
        [7, 10],
        [8, 10],
        [8, 12],
        [8, 13],
        [9, 11],
        [10, 11],
        [11, 12],
        [12, 13],
]

def Vertex(graph):
    vertex = set()

    for top in graph:
        vertex.add(top[0])
        vertex.add(top[1])

    return sorted(list(vertex))

def Components(graph):
    components = []

    vertex_list = Vertex(graph)

    graph_copy = graph.copy()

    while len(vertex_list) > 0:
        componentNow = set()
        componentNow.add(vertex_list.pop(0))
        for vertex in graph_copy:
            if vertex[0] in componentNow or vertex[1] in componentNow:
                componentNow.add(vertex[0])
                componentNow.add(vertex[1])

                if vertex[0] in vertex_list:
                    vertex_list.remove(vertex[0])
                if vertex[1] in vertex_list:
                    vertex_list.remove(vertex[1])

        components.append(componentNow)

        graph_copy = [vertex for vertex in graph_copy if vertex[0] not in componentNow and vertex[1] not in componentNow]

    return components

print(Components(graph))
