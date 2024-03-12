SOURCES=main.cpp
OBJECTS=$(SOURCES :. cpp =.o)
EXE=main
CXX=arm-rpizw-g++
# CXX=g++
CXXFLAGS=-pthread

make:
	${CXX} -o ${EXE} ${SOURCES} ${CXXFLAGS}

trans:
	scp ${EXE} root@10.9.8.2:/home/root/isu/