#include <pthread.h>
#include <iostream>
#include "Vector.hpp"
#include <unistd.h>

using namespace std;

#define WRITER_COUNT 100

Vector vec;

void* writer(void* args)
{
    while(true)
    {
        bool result = vec.setAndTest((pthread_t)args);

        cout << result;

        if (!result)
            cout << " FAILED";

        cout << endl;

        sleep(1);
    }
}

int main()
{
    pthread_t writerIds[WRITER_COUNT];

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