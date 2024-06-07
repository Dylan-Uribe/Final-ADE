//
// Created by dylan_tmut0bm on 5/6/2024.
//

#ifndef GRAPH_H
#define GRAPH_H

#include "Vertex.h"

class Graph {
    int v;  //number of vertices
    int numV; //curren number of vertices
    Vertex** adj; //adjacency matrix
    void InsertEdge(int origin, int destiny, int value) const; // Cuando se llama a la función pública "AddEdge" (Código más legible)
    [[nodiscard]] int GetPosition(char name) const; // Obtenemos la posición de un vértice en la función "AddEdge"
    void ReorganizeList() const; //Reorganizamos la lista luego de borrar un vértice "DeleteVertex"

public:
    explicit Graph(int v); ~Graph();
    void CreateVertex(char name); [[nodiscard]] bool VertexExists(char name) const;
    void AddEdge(char origin, char destiny, int value) const; void DeleteVertex(char name);
    void ShowList() const; void DeleteEdge(char origin, char destiny) const;
    void NearestNeighbor(char start) const; // Nearest Neighbor algorithm
};



#endif //GRAPH_H
