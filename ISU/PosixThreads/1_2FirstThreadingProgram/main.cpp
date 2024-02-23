#include <pthread.h>
#include <iostream>

using namespace std;

void* myThreadFunc(void* args)
{
    cout << "Hello world!" << endl;
}

int main()
{
    pthread_t myThread1;

    pthread_create(&myThread1, NULL, myThreadFunc, NULL);
    pthread_join(myThread1, NULL);

    return 0;
}
