#include <pthread.h>
#include <iostream>
#include <unistd.h>

using namespace std;

pthread_mutex_t m = PTHREAD_MUTEX_INITIALIZER;

void* threadFunc(void* args)
{
    pthread_t id = (pthread_t)args;

    for (int i = 0; i < 10; i++)
    {
        pthread_mutex_lock(&m); // Critical section er mellem lock og unlock. I dette tilfælde skal kun print være i cirical section.
        cout << "id: " << id << " times: " << i + 1 << endl;
        pthread_mutex_unlock(&m);

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
