#ifndef VERTEX_H
#define VERTEX_H



class Vertex {
public:
    char name;
    int value;
    Vertex *next;

    explicit Vertex(char name);
    Vertex();
};


#endif //VERTEX_H
