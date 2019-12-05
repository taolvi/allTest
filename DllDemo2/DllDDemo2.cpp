
#define DllDemoAPI _declspec(dllexport)
#include "DllDemo2.h"
#include <stdio.h>

DllDemoAPI int add(int a, int b)
{
	return a + b;
}

DllDemoAPI int subtract(int a, int b)
{
	return a - b;
}

DllDemoAPI int multiple(int a, int b)
{
	return a * b;
}