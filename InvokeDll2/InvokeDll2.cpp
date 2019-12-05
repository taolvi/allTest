#include "pch.h"
#include <iostream>
#include <windows.h>
int main()
{
    std::cout << "Hello World!\n"; 
	HINSTANCE hInst = LoadLibrary(L"DllDemo2.dll");
	if (!hInst)
	{
		std::cout << "加载失败";
	}
	typedef int(*DllDemoAPIProc)(int a, int b);
	DllDemoAPIProc Add = (DllDemoAPIProc)::GetProcAddress(hInst, "add");
	printf("5+3=%d", Add(5, 3));
	::FreeLibrary(hInst);
	return 0;
}


