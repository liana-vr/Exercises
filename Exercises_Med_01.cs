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
