//
// Created by dylan_tmut0bm on 5/6/2024.
//

#include "Vertex.h"

Vertex::Vertex(const char name): value(0) {
    this->name = name;
    next = nullptr;
}

Vertex::Vertex(): name(0), value(0) {
    next = nullptr;
}
