#include <iostream>
#include <string>
#include <iomanip>

#include "Derzhava.h"
#include "Respublika.h"
#include "Monarhiya.h"
#include "Korolivstvo.h"
#include "Uryad.h"
#include "Terytoriya.h"
// Функція для виводу шапки таблиці
void printHeader() {
    cout << left << setw(30) << "Базові поля" << setw(30) << "Поля нащадків" << setw(25) << "Композиція" << setw(30) << "Агрегація" << endl;
    cout << string(115, '-') << endl;
}
int main() {
    setlocale(0, "ukr");

    // Об'єкти для агрегації
    Uryad pres_parl("Президентсько-парламентська");
    Uryad const_mon("Конституційна монархія");
    Uryad parl_mon("Парламентська монархія");

    Derzhava* catalog[100];
    int count = 0;
    // Ініціалізуємо дані, додаючи елементи в масив
    catalog[count++] = new Respublika("Україна", "Київ", 43, &pres_parl, Terytoriya(603628), "В. Зеленський");
    catalog[count++] = new Monarhiya("Велика Британія", "Лондон", 67, &const_mon, Terytoriya(243610), "Чарльз III");
    catalog[count++] = new Korolivstvo("Іспанія", "Мадрид", 47, &parl_mon, Terytoriya(505990), "Філіп VI");
    // Виводимо шапку таблиці
    printHeader();
    for (int i = 0; i < count; i++) {
        catalog[i]->printInfo();
    }
    for (int i = 0; i < count; i++) {
        delete catalog[i];
    }
    return 0;
}
