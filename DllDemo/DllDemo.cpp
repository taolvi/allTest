
#define DllDemoAPI  _declspec(dllexport)
#include "DllDemo.h"
#include <stdio.h>

DllDemoAPI int add(int a, int b)
{
	return a + b;
}

DllDemoAPI void Point::Print(int x, int y)
{
	printf("x=%d, y=%d", x, y);
}


