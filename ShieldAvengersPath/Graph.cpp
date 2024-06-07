//
// Created by dylan_tmut0bm on 5/6/2024.
//

#include "Graph.h"
#include "iostream"
#include <vector>
#include <limits>

Graph::Graph(const int v) {
    this->v = v;
    numV = -1;

    adj = new Vertex * [v];
    for(int i = 0; i < v; i++){
        adj[i] = nullptr;
    }

}

Graph::~Graph() {
    for (int i = 0; i < v; ++i) {
        const Vertex* actual = adj[i];
        while (actual) {
            const Vertex* n = actual->next;
            delete actual;
            actual = n;
        }
    }
    delete[] adj;
}

int Graph::GetPosition(const char name) const {
    for (int i = 0; i < v; ++i) {
        if (adj[i] && adj[i]->name == name) return i;
    }
    return -1;
}

bool Graph::VertexExists(const char name) const {
    for (int i = 0; i < v; ++i) {
        if (adj[i] && adj[i]->name == name) return true;
    }
    return false;
}

void Graph::CreateVertex(const char name) {

    if(!VertexExists(name)){
        if(numV == -1){
            numV = 0;
        }
        for (int i = 0; i < v; ++i) {
            if (!adj[i]) {
                adj[i] = new Vertex(name);
                std::cout << "Vertice " << name << " creado" << std::endl;
                numV++;
                return;
            }
        }
    }
    std::cout << "Can't create more vertices" << std::endl;
}

void Graph::InsertEdge(const int origin, const int destiny, const int value) const {
    auto* p = new Vertex;
    p->name = adj[destiny]->name;
    p->value = value;
    p->next = nullptr;

    Vertex* temp = adj[origin];
    while (temp->next) {
        temp = temp->next;
    }
    temp->next = p;
}

void Graph::AddEdge(const char origin, const char destiny, const int value) const {

    if(!VertexExists(origin) || !VertexExists(destiny)){
        std::cout<<"An Edge can't be created, a vertex doesn't exists." << std::endl;
        std::cout<< "ORIGIN: " << origin << " " << "DESTINY: " << destiny << std::endl;
        return;
    }

    //Insertar al final origen
    InsertEdge(GetPosition(origin), GetPosition(destiny), value);
    //Insertar al final destino
    InsertEdge(GetPosition(destiny), GetPosition(origin), value);

}

void Graph::DeleteVertex(const char name) {

    if(!VertexExists(name)){
        std::cout << "El vertice que quiere eliminar no existe!!! " << std::endl;
    }
    else{
        for(int i = 0; i < numV; i++){
            //Si en la Lista de Adyacencia el primer valor es el vértice a eliminar
            //Entonces borramos toda la lista de adyacencia de dicho vértice y al final la posición donde estaba nuestro vértice
            //apuntará a null
            if(adj[i]->name == name){
                const Vertex* temp = adj[i];
                Vertex* aux = adj[i];
                while (aux->next != nullptr){
                    temp = temp->next;
                    aux->next = temp->next;
                    delete(temp);
                    temp = aux;
                }
                adj[i] = nullptr;
            } else{
                //Si no se encuentra en la primera posición el vértice a eliminar, se busca si existe
                //la conexión entre dicho vértice y otro y se borra la arista.
                Vertex* temp = adj[i];
                Vertex* aux = adj[i];

                while (aux->next != nullptr){
                    temp =temp->next;
                    if(temp->name == name){
                        aux->next = temp->next;
                        delete(temp);
                        break;
                    }
                    aux = temp;
                }
            }
        }
    }
    numV--;
    //como el apuntador del vértice queda en null, esa posición no lo podemos dejar así.
    //Lo que se hace es extraer la siguiente posición donde estaba el vértice borrado para que ocupe su lugar
    //y así hasta que no haya más vértices, es como eliminar un elemento de un vector
    //y recorrer los siguientes valores de adelantes hacia atrás
    ReorganizeList();
}

void Graph::ReorganizeList() const {

    int newPosition = 0;
    // Itera sobre todos los vértices restantes
    for (int i = 0; i < v; ++i) {
        // Si el vértice actual no es nulo
        if (adj[i] != nullptr) {
            // Mueve la lista de adyacencia al nuevo índice
            adj[newPosition] = adj[i];
            // Incrementa la posición donde copiar la lista de adyacencia
            newPosition++;
        }
    }
    // Rellena los elementos restantes con nullptr
    for (int i = newPosition; i < v; ++i) {
        adj[i] = nullptr;
    }
}

void Graph::DeleteEdge(const char origin, const char destiny) const {
    if(!VertexExists(origin) || !VertexExists(destiny)){
        std::cout << "No se puede eliminar la arista al menos un vértice no existe." << std::endl;
    } else{
        for (int i = 0; i < numV; ++i) {
            if(adj[i]->name == origin || adj[i]->name == destiny){
                if(adj[i]->name == origin){
                    Vertex* aux = adj[i];
                    Vertex* temp = adj[i];

                    while (aux->next != nullptr){
                        temp =temp->next;
                        if(temp->name == destiny){
                            aux->next = temp->next;
                            delete(temp);
                            break;
                        }
                        aux = temp;
                    }
                }
                else{
                    if(adj[i]->name == destiny){
                        Vertex* aux = adj[i];
                        Vertex* temp = adj[i];

                        while (aux->next != nullptr){
                            temp =temp->next;
                            if(temp->name == origin){
                                aux->next = temp->next;
                                delete(temp);
                                break;
                            }
                            aux = temp;
                        }
                    }
                }
            }
        }
    }
}

void Graph::NearestNeighbor(char start) const {

    if (!VertexExists(start)) {
        std::cout << "The starting vertex does not exist." << std::endl;
        return;
    }

    std::vector<bool> visited(v, false);
    int currentPos = GetPosition(start);
    visited[currentPos] = true;
    std::cout << "Starting at vertex " << start << std::endl;

    char currentVertex = start;
    int totalDistance = 0;

    for (int i = 0; i < numV - 1; ++i) {
        const Vertex* actual = adj[currentPos];
        int nearestDistance = std::numeric_limits<int>::max();
        int nearestVertexPos = -1;

        while (actual) {
            int pos = GetPosition(actual->name);
            if (!visited[pos] && actual->value < nearestDistance) {
                nearestDistance = actual->value;
                nearestVertexPos = pos;
            }
            actual = actual->next;
        }

        if (nearestVertexPos == -1) {
            std::cout << "There are unreachable vertices from " << currentVertex << std::endl;
            return;
        }

        visited[nearestVertexPos] = true;
        totalDistance += nearestDistance;
        char previousVertex = currentVertex;
        currentVertex = adj[nearestVertexPos]->name;
        std::cout << "Visiting vertex " << currentVertex << " from " << previousVertex << " with distance " << nearestDistance << std::endl;
        currentPos = nearestVertexPos;
    }

    // Return to the start vertex
    const Vertex* actual = adj[currentPos];
    while (actual && actual->name != start) {
        actual = actual->next;
    }
    if (actual) {
        totalDistance += actual->value;
        std::cout << "Returning to start vertex " << start << " with distance " << actual->value << std::endl;
    }

    std::cout << "Total distance of the tour: " << totalDistance << std::endl;
}

void Graph::ShowList() const {

    std::cout << "Adjacency list:" << std::endl;

    if(numV == -1){
        std::cout << "The graph does not exist!!!" << std::endl;
    }
    else{
        for (int i = 0; i < numV; i++) {
            const Vertex* actual = adj[i];
            std::cout << "Vertex " << adj[i]->name << ": ";
            if (actual) {
                std::cout << actual->name;
                actual = actual->next;
            }
            while (actual) {
                std::cout << "->" << actual->name;
                std::cout << "(" << actual->value << ")";
                actual = actual->next;
            }
            std::cout << std::endl;
        }
        std::cout << std::endl;
    }

}
