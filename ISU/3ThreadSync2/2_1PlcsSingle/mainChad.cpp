#include <pthread.h>
#include <iostream>
#include <vector>
#include <unistd.h> // For sleep function

using namespace std;

// Synchronization primitives
pthread_mutex_t m = PTHREAD_MUTEX_INITIALIZER;
pthread_cond_t entryCond = PTHREAD_COND_INITIALIZER; // Entry condition variable
pthread_cond_t exitCond = PTHREAD_COND_INITIALIZER;  // Exit condition variable

// Shared state
bool entryGateOpen = false;
bool exitGateOpen = false;
int carsInParkingLot = 0;

struct Gate
{
    string name;
    bool isEntry;
};

void *carFunc(void *args)
{
    string name = *((string *)args);

    // Enter
    pthread_mutex_lock(&m);
    cout << name << " driving up to entry gate" << endl;
    pthread_cond_signal(&entryCond); // Signal entry gate
    while (!entryGateOpen)
        pthread_cond_wait(&entryCond, &m); // Wait for entry gate to open
    carsInParkingLot++;
    entryGateOpen = false;           // Reset entry gate state
    pthread_cond_signal(&entryCond); // Signal entry gate can close
    pthread_mutex_unlock(&m);

    cout << name << " parked in parking lot" << endl;
    sleep(2); // Simulate time spent in parking lot

    // Exit
    pthread_mutex_lock(&m);
    cout << name << " driving up to exit gate" << endl;
    pthread_cond_signal(&exitCond); // Signal exit gate
    while (!exitGateOpen)
        pthread_cond_wait(&exitCond, &m); // Wait for exit gate to open
    carsInParkingLot--;
    exitGateOpen = false;           // Reset exit gate state
    pthread_cond_signal(&exitCond); // Signal exit gate can close
    pthread_mutex_unlock(&m);

    cout << name << " left the parking lot" << endl;

    return nullptr;
}

void *gateFunc(void *args)
{
    Gate *gate = (Gate *)args;

    pthread_mutex_lock(&m);
    while (true)
    {
        if (gate->isEntry)
        {
            while (carsInParkingLot >= 5) // Assume parking lot capacity is 5 cars
                pthread_cond_wait(&entryCond, &m);

            pthread_cond_wait(&entryCond, &m); // Wait for a car
            cout << gate->name << " opening" << endl;
            entryGateOpen = true;
            pthread_cond_signal(&entryCond); // Signal car can enter
            while (entryGateOpen)
                pthread_cond_wait(&entryCond, &m); // Wait for car to pass through
        }
        else
        {
            if (carsInParkingLot == 0) // If no cars, wait
                pthread_cond_wait(&exitCond, &m);

            pthread_cond_wait(&exitCond, &m); // Wait for a car to exit
            cout << gate->name << " opening" << endl;
            exitGateOpen = true;
            pthread_cond_signal(&exitCond); // Signal car can exit
            while (exitGateOpen)
                pthread_cond_wait(&exitCond, &m); // Wait for car to pass through
        }
        cout << gate->name << " closing" << endl;
    }
    pthread_mutex_unlock(&m);

    return nullptr;
}

int main()
{
    const int numCars = 10;
    pthread_t cars[numCars];
    pthread_t entryGate, exitGate;

    Gate entryGateInfo = {"Entry Gate", true};
    Gate exitGateInfo = {"Exit Gate", false};

    pthread_create(&entryGate, NULL, gateFunc, &entryGateInfo);
    pthread_create(&exitGate, NULL, gateFunc, &exitGateInfo);

    for (int i = 0; i < numCars; ++i)
    {
        string *carName = new string("Car " + to_string(i + 1));
        pthread_create(&cars[i], NULL, carFunc, carName);
    }

    for (int i = 0; i < numCars; ++i)
    {
        pthread_join(cars[i], NULL);
    }

    // In a real application, you would use a mechanism to safely stop the gate threads
    // For this example, we'll just join the entry gate for demonstration and leave the exit gate running
    pthread_join(entryGate, NULL);
    // pthread_join(exitGate, NULL); // Commented out as threads are running infinitely

    pthread_mutex_destroy(&m);
    pthread_cond_destroy(&entryCond);
    pthread_cond_destroy(&exitCond);

    return 0;
}
