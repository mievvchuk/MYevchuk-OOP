#include "Книга.h"
#include "Стаття.h"
#include "ЕлектроннийРесурс.h"
void printHeader() {
    cout << left<< setw(20) << "Тип видання"<< setw(30) << "Базові поля (Назва)"<< setw(35) << "Поля нащадків"<< setw(20) << "Композиція (Жанр)"<< setw(20) << "Агрегація (Автор)" << endl;
    cout << string(125, '-') << endl;
}

int main() {
    setlocale(0, "ukr");
    // === Create objects for aggregation (they exist independently) ===
    Avtor pavlenko("Pavlenko");
    Avtor ivanenko("Ivanenko");
    Avtor cormen("Cormen");
    Avtor guido("Guido van Rossum");

    const int n = 4;
    Vydannya* catalog[n] = {
        new Knyga("Philosophy of Code", &pavlenko, Zhanr("IT"), 2021, "Lviv Polytechnic"),
        new Stattia("Machine Learning", &ivanenko, Zhanr("Scientific"), "Tech Today", 5, 2022),
        new Knyga("Discrete Mathematics", &cormen, Zhanr("Educational"), 2017, "MIT Press"),
        new ElektronnyResurs("Python Documentation", &guido, Zhanr("Technical"), "docs.python.org", "Official Docs")
    };

    int choice;
    do {
        cout << "\nMENU\n";
        cout << "1. Переглянути усі видання\n";
        cout << "2. Пошук за автором\n";
        cout << "3. Вихід\n";
        cout << "Введіть вибір: ";
        cin >> choice;
        cin.ignore(); // clear buffer after cin

        switch (choice) {
        case 1: {
            cout << "\nFull Catalog\n";
            printHeader();
            for (int i = 0; i < n; i++) {
                catalog[i]->vyvestyInfo();
            }
            break;
        }
        case 2: {
            string author_lastname;
            cout << "Введіть прізвище автора: ";
            getline(cin, author_lastname);

            cout << "\nРезультати пошуку за прізвищем '" << author_lastname << "'\n";
            printHeader();
            bool found = false;
            for (int i = 0; i < n; i++) {
                if (catalog[i]->isAuthor(author_lastname)) {
                    catalog[i]->vyvestyInfo();
                    found = true;
                }
            }
            if (!found) cout << "Не знайдено нічого.\n";
            break;
        }
        case 3:
            cout << "Вихід...\n";
            break;
        default:
            cout << "Неправильний вибір, повторіть спробу.\n";
        }

    } while (choice != 3);
    // Freeing memory
    for (int i = 0; i < n; i++) {
        delete catalog[i];
    }
    return 0;
} 