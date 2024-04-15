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
    components = [set()]

    vertex_list = Vertex(graph)

    components[0].add(graph[0][0])
    components[0].add(graph[0][1])

    vertex_list.remove(graph[0][0])
    vertex_list.remove(graph[0][1])

    while len(vertex_list) > 0:
        for vertex in graph:
            for i in range(len(components)):
                elementOfComponents = components[i]
                if vertex[0] in elementOfComponents or vertex[1] in elementOfComponents:
                    elementOfComponents.add(vertex[0])
                    elementOfComponents.add(vertex[1])

                    if vertex[0] in vertex_list:
                        vertex_list.remove(vertex[0])
                    if vertex[1] in vertex_list:
                        vertex_list.remove(vertex[1])

                else:
                    if i == len(components) - 1:
                        c = set()
                        c.add(vertex[0])
                        c.add(vertex[1])
                        components.append(c)

                    if vertex[0] in vertex_list:
                        vertex_list.remove(vertex[0])
                    if vertex[1] in vertex_list:
                        vertex_list.remove(vertex[1])

    return components

print(Components(graph))
