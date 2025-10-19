#include "Книга.h"
#include "Стаття.h"
#include "ЕлектроннийРесурс.h"

int main() {
	setlocale(0, "ukr");
    // ===== Створюємо каталог (масив) =====
    const int n = 4;
    Vydannya* catalog[n] = {
    new Knyga("Philosophy of Code", "Pavlenko", 2021, "Lviv Polytechnic"),
    new Stattia("Machine Learning", "Ivanenko", "Tech Today", 5, 2022),
    new Knyga("Discrete Mathematics", "Cormen", 2017, "MIT Press"),
    new ElektronnyResurs("Python Docs", "Guido", "docs.python.org", "Official Documentation")
    };
    int choice;
    do {
        cout << "\n=== МЕНЮ ===\n";
        cout << "1. Перегляд всiх видань\n";
        cout << "2. Пошук видань за автором\n";
        cout << "3. Вихiд\n";
        cout << "Введiть номер дiї: ";
        cin >> choice;
        cin.ignore(); // очищаємо буфер після cin

        switch (choice) {
        case 1: {
            cout << "\n=== Повний каталог ===\n";
            for (int i = 0; i < n; i++) {
                catalog[i]->vyvestyInfo();
                cout << "------------------------\n";
            }
            break;
        }
        case 2: {
            string author;
            cout << "Введіть прiзвище автора: ";
            getline(cin, author);

            bool found = false;
            for (int i = 0; i < n; i++) {
                if (catalog[i]->isAuthor(author)) {
                    catalog[i]->vyvestyInfo();
                    cout << "------------------------\n";
                    found = true;
                }
            }
            if (!found) cout << "Видань з автором '" << author << "' не знайдено.\n";
            break;
        }
        case 3:
            cout << "Вихiд...\n";
            break;
        default:
            cout << "Невiрний вибір, спробуйте ще раз.\n";
        }

    } while (choice != 3);

    // Звільняємо пам’ять
    for (int i = 0; i < n; i++) {
        delete catalog[i];
    }

    return 0;
}
