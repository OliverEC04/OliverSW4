#include <pthread.h>
#include <iostream>

using namespace std;

pthread_mutex_t m = PTHREAD_MUTEX_INITIALIZER;
pthread_cond_t c;
bool carWaiting = false;

void *carFunc(void *args)
{
    string name = *((string *)args);

    cout << name << " driving up to entry gate" << endl;
    pthread_mutex_lock(&m);
    carWaiting = true;
    pthread_cond_signal(&c);

    while (!carWaiting)
        pthread_cond_wait(&c, &m);

    cout << name << " chilling in parking lot" << endl;
    carWaiting = false;

    pthread_cond_signal(&c);
}

void *gateFunc(void *args)
{
    string name = *((string *)args);

    pthread_mutex_lock(&m);
    while (!carWaiting)
        pthread_cond_wait(&c, &m);

    cout << name << " opening" << endl;
    pthread_cond_signal(&c);
    while (carWaiting)
        pthread_cond_wait(&c, &m);

    cout << name << " closing" << endl;
    pthread_mutex_unlock(&m);
}

int main()
{
    pthread_t car;
    pthread_t entryGate;
    pthread_t exitGate;

    string carName = "car";
    string entryGateName = "entry gate";
    string exitGateName = "exit gate";

    pthread_create(&car, NULL, carFunc, &carName);
    pthread_create(&entryGate, NULL, gateFunc, &entryGateName);
    pthread_create(&exitGate, NULL, gateFunc, &exitGateName);

    pthread_join(car, NULL);
    pthread_join(entryGate, NULL);
    pthread_join(exitGate, NULL);

    return 0;
}