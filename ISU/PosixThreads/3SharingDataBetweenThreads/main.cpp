#include <pthread.h>
#include <iostream>
#include <unistd.h>

using namespace std;

unsigned int shared = 0;

void* incrementer(void* args)
{
    while (true)
    {
        shared++;

        sleep(1);
    }
}

void* reader(void* args)
{
    while (true)
    {
        cout << shared << endl;

        sleep(1);
    }
}

int main()
{
    pthread_t incrementerId, readerId;

    pthread_create(&incrementerId, NULL, incrementer, NULL);
    pthread_create(&readerId, NULL, reader, NULL);

    pthread_join(incrementerId, NULL);
    pthread_join(readerId, NULL);

    return 0;
}
