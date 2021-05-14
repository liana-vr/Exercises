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

//////////////////////////////////////////////////////////////////
// Given two non-empty arrays of integers, write a function that determines whether the 
// second array is a subsequence of the first one.
// A single number in an array and the array itself are both valid subsequences of the array.

////////////////////////// SOLUTION 1 ////////////////////////////
public class Program {
	public static bool IsValidSubsequence(List<int> array, List<int> sequence) {
		int seqIdx = 0;
		int arrIdx = 0;
		while (arrIdx < array.Count && seqIdx < sequence.Count) {
			if (array[arrIdx] == sequence[seqIdx]) {
				seqIdx++;
			}
			arrIdx++;
		}
		return seqIdx == sequence.Count;
	}
}

////////////////////////// SOLUTION 2 ////////////////////////////

public class Program {
	public static bool IsValidSubsequence(List<int> array, List<int> sequence) {
		int seqIdx = 0;
		foreach (var val in array){
			if (seqIdx == sequence.Count) {
				break;
			}
			if (sequence[seqIdx] == val) {
				seqIdx++;
			}
		}
		return seqIdx == sequence.Count;
	}
}

//////////////////////////////////////////////////////////////////
// Write a function that takes in a non-empty array of integers that are sorted
// in ascending order and returns a new array of the same length with the square of the 
// original ontegers also sorted in ascending order.

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program {

	public int[] SortedSquaredArray(int[] array) {
		int[] squareArray = new int[array.Length];
		for (int idx = 0; idx < array.Length; idx++){
			int value = array[idx];
			squareArray[idx] = value * value;
		}
		Array.Sort(squareArray);
		return squareArray;
	}
}

////////////////////////// SOLUTION 2 ////////////////////////////
public class Program {

	public int[] SortedSquaredArray(int[] array) {
		int[] squareArray = new int[array.Length];
		int smallerValueIdx = 0;
		int largerValueIdx = array.Length -1;
		for (int idx = array.Length -1; idx >= 0; idx--) {
			int smallerValue = array[smallerValueIdx];
			int largerValue = array[largerValueIdx];
			if (Math.Abs(smallerValue) > Math.Abs(largerValue)) {
				squareArray[idx] = smallerValue * smallerValue;
				smallerValueIdx++;
			} else {
				squareArray[idx] = largerValue * largerValue;
				largerValueIdx--;
			}
		}
		return squareArray;
	}
}

//////////////////////////////////////////////////////////////////
// Find closest value in BST
// You can assume there will only be one closest value 

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program {
	public static int FindClosestValueInBst(BST tree, int target) {
		return FindClosestValueInBst(tree, target, tree.value);
	}
	
	public static int FindClosestValueInBst(BST tree, int target, int closest){
		if (Math.Abs(target - closest) > Math.Abs(target - tree.value)) {
			closest = tree.value;
		}
		if (target < tree.value && tree.left != null) {
			return FindClosestValueInBst(tree.left, target, closest);
		} else if (target > tree.value && tree.right != null) {
			return FindClosestValueInBst(tree.right, target, closest);
		} else {
			return closest;
		}
	}

	public class BST {
		public int value;
		public BST left;
		public BST right;

		public BST(int value) {
			this.value = value;
		}
	}
}

////////////////////////// SOLUTION 2 ////////////////////////////
public class Program {
	public static int FindClosestValueInBst(BST tree, int target) {
		return FindClosestValueInBst(tree, target, tree.value);
	}
	
	public static int FindClosestValueInBst(BST tree, int target, int closest) {
		BST currentNode = tree;
		while (currentNode != null){
			if (Math.Abs(target - closest) > Math.Abs(target - currentNode.value)) {
				closest = currentNode.value;
			}
			if (target < currentNode.value) {
				currentNode = currentNode.left;
			} else if (target > currentNode.value) {
				currentNode = currentNode.right;
			} else {
				break;
			}
		}
		return closest;
	}

	public class BST {
		public int value;
		public BST left;
		public BST right;

		public BST(int value) {
			this.value = value;
		}
	}
}
