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

    // O(n) Time | O(d) space - where n is the total number of elements in the array, including sub-elements, and d is the greatest depth of "special" arrays in the array.
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
