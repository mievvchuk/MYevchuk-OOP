#include <iostream>
#include <string>
#include "Derzhava.h"
#include "Respublika.h"
#include "Monarhiya.h"
#include "Korolivstvo.h"
using namespace std;

int main() {
    setlocale(0, "ukr");
    Derzhava* catalog[100];
    int count = 0;

    int choice;
    do {
        cout << "\n=== МЕНЮ ===\n";
        cout << "1. Додати республiку\n";
        cout << "2. Додати монархiю\n";
        cout << "3. Додати королiвство\n";
        cout << "4. Показати усi держави\n";
        cout << "0. Вихiд\n";
        cout << "Ваш вибір: ";
        cin >> choice;
        cin.ignore(); // щоб прибрати залишок символів з буфера після cin

        if (choice == 1) {
            string n, c, pres;
            int p;
            cout << "Назва: ";
            getline(cin, n);
            cout << "Столиця: ";
            getline(cin, c);
            cout << "Населення (млн): ";
            cin >> p;
            cin.ignore();
            cout << "Президент: ";
            getline(cin, pres);

            catalog[count++] = new Respublika(n, c, p, pres);
        }
        else if (choice == 2) {
            string n, c, mon;
            int p;
            cout << "Назва: ";
            getline(cin, n);
            cout << "Столиця: ";
            getline(cin, c);
            cout << "Населення (млн): ";
            cin >> p;
            cin.ignore();
            cout << "Монарх: ";
            getline(cin, mon);

            catalog[count++] = new Monarhiya(n, c, p, mon);
        }
        else if (choice == 3) {
            string n, c, korol;
            int p;
            cout << "Назва: ";
            getline(cin, n);
            cout << "Столиця: ";
            getline(cin, c);
            cout << "Населення (млн): ";
            cin >> p;
            cin.ignore();
            cout << "Король: ";
            getline(cin, korol);

            catalog[count++] = new Korolivstvo(n, c, p, korol);
        }
        else if (choice == 4) {
            for (int i = 0; i < count; i++) {
                catalog[i]->printInfo();
            }
        }
    } while (choice != 0);
    for (int i = 0; i < count; i++) delete catalog[i];
    return 0;
}