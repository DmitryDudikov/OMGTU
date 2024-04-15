using System;
using System.IO;

class DjEXTRA
{
    static int Vertex = 5;
    int minDistance(int[] distance,
                    bool[] shortestPathTree)
    {
        int min = int.MaxValue, min_index = -1;

        for (int vertex = 0; vertex < Vertex; vertex++)
            if (shortestPathTree[vertex] == false && distance[vertex] <= min)
            {
                min = distance[vertex];
                min_index = vertex;
            }

        return min_index;
    }

    void Print(int[] distance, int vertex)
    {
        Console.Write("Вершина \t Кратчайший путь от заданной вершины до остальных: \n");
        for (int i = 0; i < Vertex; i++)
            Console.Write(i + " \t\t " + distance[i] + "\n");
    }

    void DijkstraAlgoritm(int[,] graph, int source)
    {
        int[] distance = new int[Vertex];

        bool[] shortestPathTree = new bool[Vertex];

        for (int i = 0; i < Vertex; i++)
        {
            distance[i] = int.MaxValue;
            shortestPathTree[i] = false;
        }

        distance[source] = 0;

        for (int count = 0; count < Vertex - 1; count++)
        {
            int u = minDistance(distance, shortestPathTree);

            shortestPathTree[u] = true;

            for (int vertex = 0; vertex < Vertex; vertex++)

                if (!shortestPathTree[vertex] && graph[u, vertex] != 0 &&
                    distance[u] != int.MaxValue && distance[u] + graph[u, vertex] < distance[vertex])
                    distance[vertex] = distance[u] + graph[u, vertex];
        }

        Print(distance, Vertex);
    }

    public static void Main()
    {
        int[,] graph =  {

             { 0, 5, 13, 1, 3},
             { 5, 0, 5, 12, 6},
             { 13, 5, 0, 7, 8},
             { 1, 12, 7, 0, 67},
             { 3, 6, 8, 67, 0},

                };

        DjEXTRA solve = new DjEXTRA();
        solve.DijkstraAlgoritm(graph, 0); //Передаем выбранную веришну
    }
}

