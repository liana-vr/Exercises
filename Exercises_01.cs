using System;
using System.Collections.Generic;

//////////////////////////////////////////////////////////////////
// Write a function that takes in a non-empty array of distinct integers and 
// an int representing a target sum, the function should return them in an array, in any order.
// You can't add a single int to itself in order to obtain the target sum.

////////////////////////// SOLUTION 1 ////////////////////////////
public class Program {
	public static int[] TwoNumberSum(int[] array, int targetSum) {
		Array.Sort(array);
		int left = 0;
		int right = array.Length - 1;
		while (left < right){
			int currentSum = array[left] + array[right];
			if (currentSum == targetSum) {
				return new int[] {array[left], array[right]};
			} else if (currentSum < targetSum) {
				left++;
			} else if (currentSum > targetSum) {
				right--;
			}
		}
		return new int[0];
	}
}

////////////////////////// SOLUTION 2 ////////////////////////////
public class Program {
	public static int[] TwoNumberSum(int[] array, int targetSum) {
		HashSet<int> nums = new HashSet<int>();
		foreach (int num in array){
			int potentialMatch = targetSum - num;
			if (nums.Contains(potentialMatch)){
				return new int[] {potentialMatch, num};
			} else {
				nums.Add(num);
			}
		}
		return new int[0];
	}
}