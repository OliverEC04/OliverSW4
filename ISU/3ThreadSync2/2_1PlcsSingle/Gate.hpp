#pragma once

#include "ThreadFucker.hpp"

class Gate : ThreadFucker
{
public:
    bool isOpen = false;
    pthread_t tId;

    Gate()
    {
    }

    void start()
    {
        pthread_mutex_lock(&m);
        while (!carWaiting)
            pthread_cond_wait(&c, &m);

        open();
        pthread_cond_signal(&c);
        while (carWaiting)
            pthread_cond_wait(&c, &m);

        close();
        pthread_mutex_unlock(&m);
    }

private:
    void open()
    {
        isOpen = true;
    }

    void close()
    {
        isOpen = false;
    }
};
