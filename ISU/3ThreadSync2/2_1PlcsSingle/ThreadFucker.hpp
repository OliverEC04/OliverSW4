#pragma once

#include <pthread.h>

class ThreadFucker
{
public:
    static pthread_mutex_t m;
    static pthread_cond_t c;
    static bool carWaiting;
    static bool entryGateOpen;
    static bool exitGateOpen;

    static void reset()
    {
        m = PTHREAD_MUTEX_INITIALIZER;
        carWaiting = false;
        entryGateOpen = false;
        exitGateOpen = false;
    }
};
