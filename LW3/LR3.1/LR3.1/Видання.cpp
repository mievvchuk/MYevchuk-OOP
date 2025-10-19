//видання.cpp
#include "Видання.h"

// Ініціалізація статичного поля
Vydannya* Vydannya::head = nullptr;

Vydannya::Vydannya(string n, string a) : nazva(n), avtor(a), next(nullptr) {
    if (!head) {
        head = this;
    }
    else {
        Vydannya* temp = head;
        while (temp->next) temp = temp->next;
        temp->next = this;
    }
}

Vydannya::~Vydannya() {}

void Vydannya::perehlyad() {
    Vydannya* temp = head;
    while (temp) {
        temp->vyvestyInfo();
        cout << "------------------------\n";
        temp = temp->next;
    }
}

void Vydannya::poshukAvtora(const string& a) {
    Vydannya* temp = head;
    bool found = false;
    while (temp) {
        if (temp->isAuthor(a)) {
            temp->vyvestyInfo();
            cout << "------------------------\n";
            found = true;
        }
        temp = temp->next;
    }
    if (!found) cout << "Видань з автором '" << a << "' не знайдено.\n";
}
