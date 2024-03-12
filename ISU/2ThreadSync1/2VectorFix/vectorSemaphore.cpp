#include <pthread.h>
#include <semaphore.h>
#include <iostream>
#include "Vector.hpp"
#include <unistd.h>

using namespace std;

#define WRITER_COUNT 100
#define SLEEPMS 10
#define VECSIZE 1000000

sem_t s;
Vector vec(VECSIZE);

void* writer(void* args)
{
    while(true)
    {
        sem_wait(&s);
        bool result = vec.setAndTest((pthread_t)args);
        sem_post(&s);

        cout << result;

        if (!result)
            cout << " FAILED";

        cout << endl;

        usleep(SLEEPMS);
    }
}

int main()
{
    pthread_t writerIds[WRITER_COUNT];

    sem_init(&s, 0, 1);

    for (int i = 0; i < WRITER_COUNT; i++)
    {
        pthread_create(&writerIds[i], NULL, writer, &writerIds[i]);
    }

    for (int i = 0; i < WRITER_COUNT; i++)
    {
        pthread_join(writerIds[i], NULL);
    }

    return 0;
}