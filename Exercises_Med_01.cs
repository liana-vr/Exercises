using System;
using System.Collections.Generic;

//////////////////////////////////////////////////////////////////
// THREE NUMBER SUM
// Write a function that takes in a non-empty array of distinct integers and 
// an int representing a target sum, the function should return them in an array, in any order.

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program {
	// O(n^2) time | O(n) space
	public static List<int[]> ThreeNumberSum(int[] array, int targetSum) {
		Array.Sort(array); // O(Nlog(N))
		List<int[]> triplets = new List<int[]>();
		for(int i = 0; i < array.Length - 2; i++){
			int left = i + 1;
			int right = array.Length - 1;
			while(left < right){
				int currentSum = array[i] + array[left] + array[right];
				if (currentSum == targetSum){
					int[] newTriplet = {array[i], array[left], array[right]};
					triplets.Add(newTriplet);
					left++;
					right--;
				} else if (currentSum < targetSum){
					left++;
				} else if (currentSum > targetSum){
					right--;
				}
			}
		}
		return triplets;
	}
}

//////////////////////////////////////////////////////////////////
// SMALLEST DIFFERENCE
// Find the pair of number (one from each array) whose absolute difference is 
// closest to zero, return array containing these two numbers

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program {
	// O(nLog(n) + mLog(m)) time | O(1) space
	public static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo) {
		Array.Sort(arrayOne);
		Array.Sort(arrayTwo);
		int indexOne = 0;
		int indexTwo = 0;
		int smallest = Int32.MaxValue;
		int current = Int32.MaxValue;
		int [] smallestPair = new int[2];
		while (indexOne < arrayOne.Length && indexTwo < arrayTwo.Length){
			int firstNum = arrayOne[indexOne];
			int secondNum = arrayTwo[indexTwo];
			if (firstNum < secondNum){
				current = secondNum - firstNum;
				indexOne++;
			} else if (secondNum < firstNum){
				current = firstNum - secondNum;
				indexTwo++;
			} else {
				return new int[]{firstNum, secondNum};
			}
			if (smallest > current){
				smallest = current;
				smallestPair = new int[]{firstNum, secondNum};
			}
		}
		return smallestPair;
	} 
}

//////////////////////////////////////////////////////////////////
// MOVE ELEMENT TO END
// You're given an array of integers and a target integer, Write a function that 
// moves all instances of the target in the array to the end of the array.

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program {
	//O(n) time | O(1) space
	public static List<int> MoveElementToEnd(List<int> array, int toMove) {
		int i = 0;
		int j = array.Count - 1;
		while (i < j){
			while (i < j && array[j] == toMove) j--;
			if (array[i] == toMove) Swap(i, j, array);
			i++;
		}
		return array;
	}
	
	public static void Swap(int i, int j, List<int> array){
		int temp = array[j];
		array[j] = array[i];
		array[i] = temp;
	}
}

//////////////////////////////////////////////////////////////////
// MONOTONIC ARRAY
// Write a function that returns a boolean representin whether the is 
// monotoninc. Note that empty arrays and arrays of one element are monotonic

////////////////////////// SOLUTION 1 ////////////////////////////
public class Program {
	// O(n) time | O(1) space
	public static bool IsMonotonic(int[] array) {
		if (array.Length <= 2) return true;
		
		var direction = array[1] - array[0];
		for (int i = 2; i < array.Length; i++){
			if (direction == 0){
				direction = array[i] - array[i-1];
				continue;
			}
			if (breaksDirection(direction, array[i - 1], array[i])){
				return false;
			}
		}
		return true;
	}
	public static bool breaksDirection(int direction, int previous, int current){
		var difference = current - previous;
		if(direction > 0) return difference < 0;
		return difference > 0;
	}
}

////////////////////////// SOLUTION 2 ////////////////////////////
public class Program {
	// O(n) time | O(1) space
	public static bool IsMonotonic(int[] array) {
		var isNonDecreasing = true;
		var isNonIncreasing = true;
		for (int i = 1; i < array.Length; i++){
			if (array[i] < array[i-1]){
				isNonDecreasing = false;
			}
			if (array[i] > array[i-1]){
				isNonIncreasing = false;
			}
		}
		return isNonDecreasing || isNonIncreasing;
	}
}

//////////////////////////////////////////////////////////////////
// SPIRAL TRAVERSE
// Write a function that takes a two-dimentional array and returns a
// one dimentional array of all the elements in spiral order.

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program{
	// O(n) time | O(n) space
	public static List<int> SpiralTraverse(int[,] array) {
		if (array.GetLength(0) == 0) return new List<int>();
		
		var result = new List<int>();
		var startRow = 0;
		var endRow = array.GetLength(0)-1;
		var startCol = 0;
		var endCol = array.GetLength(1)-1;
		
		while (startRow <= endRow && startCol <= endCol){
			for (int col = startCol; col <= endCol; col++){
				result.Add(array[startRow,col]);
			}
			for (int row = startRow + 1; row <= endRow; row++){
				result.Add(array[row,endCol]);
			}
			for(int col = endCol -1; col >= startCol; col--){
				if (startRow == endRow) break;
				result.Add(array[endRow,col]);
			}
			for(int row = endRow -1; row > startRow; row--){
				if (startCol == endCol) break;
				result.Add(array[row,startCol]);
			}
			startRow++;
			endRow--;
			startCol++;
			endCol--;
		}
		return result;
	}
}

////////////////////////// SOLUTION 2 ////////////////////////////
public class Program {
	// O(n) time | O(n) space
	public static List<int> SpiralTraverse(int[,] array) {
		if (array.Length == 0) return new List<int>();
		
		var result = new List<int>();
		spiralFill(array, 0, array.GetLength(0) - 1, 0, array.GetLength(1) - 1, result);
		return result;
	}
	public static void spiralFill(
		int[,] array,
		int startRow,
		int endRow,
		int startCol,
		int endCol,
		List<int> result) {
		if (startRow > endRow || startCol > endCol){
			return;
		}
		for(int col = startCol; col <= endCol; col++){
			result.Add(array[startRow,col]);
		}
		for(int row = startRow + 1; row <= endRow; row++){
			result.Add(array[row,endCol]);
		}
		for (int col = endCol - 1; col >= startCol; col--){
			if (startRow == endRow) break;
			result.Add(array[endRow,col]);
		}
		for (int row = endRow - 1; row >= startRow + 1; row--){
			if (startCol == endCol) break;
			result.Add(array[row,startCol]);
		}
		spiralFill(array, startRow + 1, endRow - 1, startCol + 1, endCol -1, result);
	}
}

//////////////////////////////////////////////////////////////////
// LONGEST PEAK
// Write a function that takes an array of integers and returns 
// the length of the longest peak in the array

////////////////////////// SOLUTION 1 ////////////////////////////
public class Program {
	// O(n) time | O(1) space
	public static int LongestPeak(int[] array) {
		int longestPeakLength = 0;
		int i = 1;
		while (i < array.Length -1){
			bool isPeak = array[i - 1] < array[i] && array[i] > array[i+1];
			if (!isPeak){
				i++;
				continue;
			}
			int leftIdx = i - 2;
			while (leftIdx >= 0 && array[leftIdx] < array[leftIdx+1]){
				leftIdx--;
			}
			int rightIdx = i + 2;
			while (rightIdx < array.Length && array[rightIdx] < array[rightIdx-1]){
				rightIdx++;
			}
			int currentPeakLength = rightIdx - leftIdx -1;
			if (currentPeakLength > longestPeakLength){
				longestPeakLength = currentPeakLength;
			}
			i = rightIdx;
		}
		return longestPeakLength;
	}
}