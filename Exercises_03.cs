using System;
using System.Collections.Generic;

//////////////////////////////////////////////////////////////////
// PRODUCT SUM
// Write a function that takes in a 'special' array and return its product sum.
// A 'special' array is a non-empty array that contains either integers or other 'special arrays'

////////////////////////// SOLUTION 1 ////////////////////////////
public class Program {
	// Tip: You can use `el is IList<object>` to check whether an item is a list or
	// an integer.

    // O(n) Time | O(d) space - where n is the total number of elements in the array, 
    // including sub-elements, and d is the greatest depth of "special" arrays in the array.
	public static int ProductSum(List<object> array) {
		return productSumHelper(array, 1);
	}
	
	public static int productSumHelper(List<object> array, int multiplier){
		int sum = 0;
		foreach (object el in array) {
			if (el is IList<object>){
				sum += productSumHelper((List<object>)el, multiplier + 1);
			} else {
				sum += (int)el;
			}
		}
		return sum * multiplier;
	}
}

//////////////////////////////////////////////////////////////////
// Find Three Largest Numbers
// Write a functions that takes in an array of at least three integers
// and returns a sorted array of the three largest in the input array

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program {
	public static int[] FindThreeLargestNumbers(int[] array) {
		int[] threeLargest = {Int32.MinValue, Int32.MinValue, Int32.MinValue};
		foreach (int num in array){
			updateLargest(threeLargest, num);
		}
		return threeLargest;
	}
	
	public static void updateLargest(int[] threeLargest, int num){
		if (num > threeLargest[2]){
			shiftAndUpdate(threeLargest, num, 2);
		} else if (num > threeLargest[1]){
			shiftAndUpdate(threeLargest, num, 1);
		} else if (num > threeLargest[0]){
			shiftAndUpdate(threeLargest, num, 0);
		}
	}
	
	public static void shiftAndUpdate(int[] array, int num, int idx){
		for (int i = 0; i <= idx; i++){
			if (i == idx) {
				array[i] = num;
			} else {
				array[i] = array[i + 1];
			}
		}
	}
}

//////////////////////////////////////////////////////////////////
// Binary Search
// 
// 

////////////////////////// SOLUTION 1 ////////////////////////////
public class Program {
	// O(log(n)) time | O(log(n)) space
	public static int BinarySearch(int[] array, int target) {
		return BinarySearch(array, target, 0, array.Length -1);
	}	
		
	public static int BinarySearch(int[] array, int target, int L, int R){		
		if (L > R) {
			return -1;
		}
		int middle = (L + R) / 2;
		int potentialMatch = array[middle];
		if (target == potentialMatch){
			return middle;
		} else if (target < potentialMatch){
			return BinarySearch(array, target, L, middle - 1);
		} else {
			return BinarySearch(array, target, middle + 1, R);
		}
	}
}

////////////////////////// SOLUTION 2 ////////////////////////////
public class Program {
    // O(log(n)) time | O(1) space
	public static int BinarySearch(int[] array, int target) {
		return BinarySearch(array, target, 0, array.Length -1);
	}
	
	public static int BinarySearch(int[] array, int target, int L, int R){
		while (L <= R) {
			int middle = (L + R) / 2;
			int potentialMatch = array[middle];
			if (target == potentialMatch){
				return middle;
			} else if (target < potentialMatch){
				R = middle - 1;
			} else {
				L = middle + 1;
			}
		}
		return -1;
	}
}

//////////////////////////////////////////////////////////////////
// BUBBLE SORT
// Write a function that takes in array of integers and returns a 
// sorted version of that array by using Bubble Sort Algorithm

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program {
	// Best: O(n) time | O(1) space
	// Average: O(n^2) time | O(1) space
	// Worst: O(n^2) time | O(1) space
	public static int[] BubbleSort(int[] array) {
		if (array.Length == 0){
			return new int[]{};
		}
		bool isSorted = false;
		int counter = 0;
		while (!isSorted){
			isSorted = true;
			for (int i = 0; i < array.Length - 1 - counter; i++){
				if (array[i] > array[i + 1]){
					swap(i, i + 1, array);
					isSorted = false;
				}
			}
			counter++;
		}
		return array;
	}
	
	public static void swap(int i, int j, int[] array) {
		int temp = array[j];
		array[j] = array[i];
		array[i] = temp;
	}
}

//////////////////////////////////////////////////////////////////
// INSERTION SORT
// Write a function that takes in array of integers and returns a 
// sorted version of that array by using Insertion Sort Algorithm

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program {
	// Best: O(n) time | O(1) space
	// Average: O(n^2) time | O(1) space
	// Worst: O(n^2) time | O(1) space
	public static int[] InsertionSort(int[] array) {
		if (array.Length == 0){
			return new int[] {};
		}
		for (int i = 1; i < array.Length; i++) {
			int j = i;
			while (j > 0 && array[j] < array[j - 1]) {
				swap(j, j-1, array);
				j -= 1;
			}
		}
		return array;
	}
	
	public static void swap(int i, int j, int[] array) {
		int temp = array[j];
		array[j] = array[i];
		array[i] = temp;
	}
}

//////////////////////////////////////////////////////////////////
// SELECTION SORT
// Write a function that takes in array of integers and returns a 
// sorted version of that array by using Selection Sort Algorithm

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program {
	// Best: O(n) time | O(1) space
	// Average: O(n^2) time | O(1) space
	// Worst: O(n^2) time | O(1) space
	public static int[] SelectionSort(int[] array) {
		if (array.Length == 0) {
			return new int[]{};
		}
		int startIdx = 0;
		while (startIdx < array.Length - 1){
			int smallestIdx = startIdx;
			for (int i = startIdx + 1; i < array.Length; i++){
				if (array[smallestIdx] > array[i]) {
					smallestIdx = i;
				}
			}
			swap (startIdx, smallestIdx, array);
			startIdx++;
		}
		return array;
	}
	
	public static void swap (int i, int j, int[] array){
		int temp = array[j];
		array[j] = array[i];
		array[i] = temp;
	}
}

//////////////////////////////////////////////////////////////////
// PALINDROMR CHECK
// Write a function that takes a non-empty string and returns a 
// boolean representing whether the string is a palindrome

////////////////////////// SOLUTION 1 ////////////////////////////
public class Program { // BRUTE FORCE
	// O(n^2) time | O(n) space
	public static bool IsPalindrome(string str) {
		string reversedString = "";
		for (int i = str.Length - 1; i >= 0; i--){
			reversedString += str[i];
		}
		return str.Equals(reversedString);
	}
}

////////////////////////// SOLUTION 2 ////////////////////////////
public class Program {
	// O(n) time | O(1) space
	public static bool IsPalindrome(string str) {
		int leftIdx = 0;
		int rightIdx = str.Length -1;
		while (leftIdx < rightIdx){
			if (str[leftIdx] != str[rightIdx]){
				return false;
			}
			leftIdx++;
			rightIdx--;
		}
		return true;
	}
}

//////////////////////////////////////////////////////////////////
// CAESAR CIPHER ENCRYPTOR
// Write a function that returns a new string obtained by shifting every letter 
// in the input string by k positions in the alphabet, where k is the key.

////////////////////////// SOLUTION 1 ////////////////////////////
public class Program {
	// O(n) time | O(n) space
	public static string CaesarCypherEncryptor(string str, int key) {
		char[] newLetters = new char[str.Length];
		int newKey = key % 26;
		for (int i = 0; i < str.Length; i++){
			newLetters[i] = getNewLetter(str[i], newKey);
		}
		return new string(newLetters);
	}
	
	public static char getNewLetter(char letter, int key){
		int newLetterCode = letter + key;
		return newLetterCode <=
						122 ? (char)newLetterCode : (char)(96 + newLetterCode % 122);
	}
}

////////////////////////// SOLUTION 2 ////////////////////////////
public class Program {
	// O(n) time | O(n) space
	public static string CaesarCypherEncryptor(string str, int key) {
		char[] newLetters = new char[str.Length];
		int newKey = key % 26;
		string alphabet = "abcdefghijklmnopqrstuvwxyz";
		for (int i=0; i < str.Length; i++){
			newLetters[i] = getNewLetter(str[i], newKey, alphabet);
		}
		return new string(newLetters);
	}
	
	public static char getNewLetter(char letter, int key, string alphabet){
		int newLetterCode = alphabet.IndexOf(letter) + key;
		return alphabet[newLetterCode % 26];
	}
}