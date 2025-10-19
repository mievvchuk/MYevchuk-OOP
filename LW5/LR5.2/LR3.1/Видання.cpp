#include "Видання.h"

Vydannya::Vydannya(string n, Avtor* a, Zhanr z)
    : nazva(n), avtor(a), zhanr(z) {
}

// Реалізація методу isAuthor у базовому класі
bool Vydannya::isAuthor(const string& a) const {
    return avtor->getPrizvyshche() == a;
}