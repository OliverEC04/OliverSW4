#include <pthread.h>
#include <iostream>
#include <unistd.h>

using namespace std;

void* threadFunc(void* args)
{
    pthread_t id = (pthread_t)args;

    for (int i = 0; i < 10; i++)
    {
        cout << "id: " << id << " times: " << i + 1 << endl;

        sleep(1);
    }

    pthread_exit(NULL);
}

int main()
{
    pthread_t threadAId;
    pthread_t threadBId;

    pthread_create(&threadAId, NULL, threadFunc, &threadAId);
    pthread_create(&threadBId, NULL, threadFunc, &threadBId);

    pthread_join(threadAId, NULL);
    pthread_join(threadBId, NULL);

    return 0;
}
