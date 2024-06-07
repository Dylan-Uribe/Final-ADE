
#include "Graph.h"

int main() {


    Graph graph(8);
    graph.CreateVertex('A');
    graph.CreateVertex('B');
    graph.CreateVertex('C');
    graph.CreateVertex('D');
    graph.CreateVertex('E');
    graph.CreateVertex('F');
    graph.CreateVertex('G');
    graph.CreateVertex('H');

    //Vertex A
    graph.AddEdge('A', 'B', 675);
    graph.AddEdge('A', 'C', 400);
    graph.AddEdge('A', 'D', 166);
    graph.AddEdge('A', 'E', 809);
    graph.AddEdge('A', 'F', 720);
    graph.AddEdge('A', 'G', 399);
    graph.AddEdge('A', 'H', 233);

    //Vertex B
    graph.AddEdge('B', 'C', 540);
    graph.AddEdge('B', 'D', 687);
    graph.AddEdge('B', 'E', 179);
    graph.AddEdge('B', 'F', 348);
    graph.AddEdge('B', 'G', 199);
    graph.AddEdge('B', 'H', 401);

    //Vertex C
    graph.AddEdge('C', 'D', 107);
    graph.AddEdge('C', 'E', 752);
    graph.AddEdge('C', 'F', 521);
    graph.AddEdge('C', 'G', 385);
    graph.AddEdge('C', 'H', 280);

    //Vertex D
    graph.AddEdge('D', 'E', 111);
    graph.AddEdge('D', 'F', 540);
    graph.AddEdge('D', 'G', 990);
    graph.AddEdge('D', 'H', 361);

    //Vertex E
    graph.AddEdge('E', 'F', 206);
    graph.AddEdge('E', 'G', 412);
    graph.AddEdge('E', 'H', 576);

    //Vertex F
    graph.AddEdge('F', 'G', 155);
    graph.AddEdge('F', 'H', 621);

    //Vertex G
    graph.AddEdge('G', 'H', 100);

    graph.ShowList();

    graph.NearestNeighbor('A');


    return 0;
}
