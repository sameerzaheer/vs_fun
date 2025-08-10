// BinarySearch.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <string>
#include <iostream>
#include <list>
#include <vector>
#include <ctime>

using std::string;

int main( );
int iterativeLinearSearch(int* array, int arrayLen, int value);
int iterativeBinarySearch(int* array, int arrayLen, int value);
int recursiveBinarySearch(int* array, int arrayLen, int value);

int main()
{
	//string stringOfInts = "";	
	//std::cin >> stringOfInts;
	//std::vector<int> listOfInts;
	//
	//for (int i = 0; i < stringOfInts.length(); i++) {
	//	if (stringOfInts[i] != ',') {
	//		int intFound = (int)(stringOfInts[i] - '0');
	//		listOfInts.push_back(intFound);
	//	}
	//}

	//int* arrayOfInts = new int[listOfInts.size()];
	//for (int i = 0; i < listOfInts.size(); i++) {
	//	std::cout << listOfInts.at(i);
	//	arrayOfInts[i] = listOfInts.at(i);
	//}
	//std::cout << "\n";

	int arraySize = 10;
	int* arrayOfInts = new int[arraySize] {1, 2, 3, 5, 7, 11, 19, 25, 26, 27};
	int value = 25;

	clock_t begin, end;
		
	begin = clock();
	int indexOfValueL = iterativeLinearSearch(arrayOfInts, arraySize, value);
	end = clock();
	std::cout << "Index at (iterative): " + std::to_string(indexOfValueL) + "   in: " 
		+ std::to_string((end - begin) / (CLOCKS_PER_SEC/1000)) + "s \n";

	begin = clock();
	int indexOfValueB = iterativeBinarySearch(arrayOfInts, arraySize, value);
	end = clock();
	std::cout << "Index at (binary): " + std::to_string(indexOfValueB) + "   in: "
		+ std::to_string((end - begin) / (CLOCKS_PER_SEC / 1000)) + "s \n";

	begin = clock();
	int indexOfValueBR = recursiveBinarySearch(arrayOfInts, arraySize, value);
	end = clock();
	std::cout << "Index at (binaryRecursive): " + std::to_string(indexOfValueBR) + "   in: "
		+ std::to_string((end - begin) / (CLOCKS_PER_SEC / 1000)) + "s \n";

	delete[] arrayOfInts;

    return 0;
}

int iterativeLinearSearch(int* array, int arrayLen, int value) {
	int i = 0;
	int ValueIndex = -1;
	while (i < arrayLen) {
		if (array[i] == value) {
			ValueIndex = i;
			break;
		}
		i++;
	}
	return ValueIndex;
}

int iterativeBinarySearch(int* array, int arrayLen, int value) {
	int i = 0;
	int ValueIndex = -1;
	int startI = 0;
	int endI = arrayLen;

	while (endI - startI > 0) {
		int midI = floor((endI + startI) * 0.5);
		int midValue = array[midI];
		if (value > midValue) {
			startI = midI;
		} else if (value < midValue) {
			endI = midI;
		} else {
			startI = midI;
			endI = midI;
		}
	}	

	return startI;
}

int recursiveBinarySearch(int* array, int arrayLen, int value) {
	
	int i = 0;
	int ValueIndex = -1;
	int startI = 0;
	int endI = arrayLen;

	int midI = floor((endI + startI) * 0.5);
	int midValue = array[midI];

	if (value == midValue) {
		return midI;
	} else if (value > midValue) {
		startI = midI;
		return recursiveBinarySearch(array + midI, arrayLen - midI, value) + midI;
	} else if (value < midValue) {
		endI = midI;
		return recursiveBinarySearch(array, arrayLen - midI, value);
	} else {
		startI = midI;
		endI = midI;
	}

	return startI;
}

