#include <pthread.h>
#include <iostream>
#include "Car.hpp"
#include "Gate.hpp"

using namespace std;

pthread_mutex_t m = PTHREAD_MUTEX_INITIALIZER;
pthread_cond_t c;
bool carWaiting = false;

// FUCK KLASSER JEG LAVER DET OM TIL FUNKTIONER I EEEEN FUCKING LORTE FIL fuck isu

int main()
{
    Car car1 = Car();
    Gate entryGate = Gate();
    Gate exitGate = Gate();

    return 0;
}