#include "�������.h"

Vydannya::Vydannya(string n, Avtor* a, Zhanr z)
    : nazva(n), avtor(a), zhanr(z) {
}

// ��������� ������ isAuthor � �������� ����
bool Vydannya::isAuthor(const string& a) const {
    return avtor->getPrizvyshche() == a;
}