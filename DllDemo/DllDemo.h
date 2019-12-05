#pragma once

#ifdef DllDemoAPI
#else
#define DllDemoAPI _declspec(dllexport)
#endif // DllDemoAPI

DllDemoAPI int add(int a, int b);

class DllDemoAPI Point
{
public:
	void Print(int x, int y);
};