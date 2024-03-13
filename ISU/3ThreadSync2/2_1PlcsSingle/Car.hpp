#pragma once

#include <iostream>
#include "ThreadFucker.hpp"

using namespace std;

class Car : ThreadFucker
{
public:
    static bool carWaiting;

    Car(string name = "Car driven by woman so it will crash")
    {
        _name = name;
    }

    void start()
    {
        pthread_create(&tId, NULL, enter, NULL);
    }

private:
    string _name;
    pthread_t tId;

    void *enter(void *args)
    {
        cout << _name << " driving up to entry gate" << endl;

        enter();
        pthread_mutex_lock(&m);
        carWaiting = true;
        pthread_cond_signal(&c);

        while (!carWaiting)
            pthread_cond_wait(&c, &m);

        stay();
        carWaiting = false;

        pthread_cond_signal(&c);
    }

    void stay()
    {
        cout << _name << " is chilling" << endl;
    }

    void exit()
    {
        cout << _name << " driving up to exit gate" << endl;
    }
};
