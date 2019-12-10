// InvokeDll.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
#include "..\DllDemo\DllDemo.h"
/*
首先，这个_tmain()是为了支持unicode所使用的main一个别名而已，既然是别名，应该有宏定义过的，在哪里定义的呢？就在那个让你困惑的<stdafx.h>里，有这么两行
#include <stdio.h>
#include <tchar.h>
我们可以在头文件<tchar.h>里找到_tmain的宏定义
#define _tmain main
所以，经过预编译以后， _tmain就变成main了，这下明白了吧
*/
int main()
{
    std::cout << "Hello World!\n"; 
	printf("5+3 = %d\n", add(5, 3));

	Point p;
	p.Print(5, 3);
	return 0;
	std::cin;
}

// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门提示: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
