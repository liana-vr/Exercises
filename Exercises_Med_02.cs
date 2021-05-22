using System;
using System.Collections.Generic;

//////////////////////////////////////////////////////////////////
// BST CONSTRUCTION
// Write a BST class for a Binary Search Tree that has an Insert method,
// a Search method and a Remove method

////////////////////////// SOLUTION 1 ////////////////////////////
public class Program {

	public class BST {
		public int value;
		public BST left;
		public BST right;

		public BST(int value) {
			this.value = value;
		}

		public BST Insert(int value) {
			BST currentNode = this;
			while (true){
				if (value < currentNode.value){
					if (currentNode.left == null){
						BST newNode = new BST(value);
						currentNode.left = newNode;
						break;
					} else {
						currentNode = currentNode.left;
					}
				} else {
					if (currentNode.right == null){
						BST newNode = new BST(value);
						currentNode.right = newNode;
						break;
					} else {
						currentNode = currentNode.right;
					}
				}
			}
			return this;
		}

		public bool Contains(int value) {
			BST currentNode = this;
			while (currentNode != null){
				if (value < currentNode.value){
					currentNode = currentNode.left;
				} else if(value > currentNode.value){
					currentNode = currentNode.right;
				} else {
					return true;
				}
			}
			return false;
		}
		
		public BST Remove(int value){
			Remove(value, null);
			return this;
		}

		public void Remove(int value, BST parentNode) {
			BST currentNode = this;
			while (currentNode != null){
				if (value < currentNode.value){
					parentNode = currentNode;
					currentNode = currentNode.left;
				} else if (value > currentNode.value){
					parentNode = currentNode;
					currentNode = currentNode.right;
				} else {
					if (currentNode.left != null && currentNode.right != null){
						currentNode.value = currentNode.right.getMinValue();
						currentNode.right.Remove(currentNode.value, currentNode);
					} else if (parentNode == null) {
						if (currentNode.left != null) {
							currentNode.value = currentNode.left.value;
							currentNode.right = currentNode.left.right;
							currentNode.left = currentNode.left.left;
						} else if (currentNode.right != null){
							currentNode.value = currentNode.right.value;
							currentNode.left = currentNode.right.left;
							currentNode.right = currentNode.right.right;
						} else {
							// this is a single-node tree; do nothing
						}
					} else if (parentNode.left == currentNode){
						parentNode.left = currentNode.left != null ? currentNode.left : currentNode.right;
					} else if (parentNode.right == currentNode){
						parentNode.right = currentNode.left != null ? currentNode.left : currentNode.right;
					}
					break;
				}
			}
		}
		
		public int getMinValue(){
			if (left == null){
				return value;
			} else {
				return left.getMinValue();
			}
		}
	}
}

//////////////////////////////////////////////////////////////////
// VALIDATE BST
// Write a function that takes in a potentially invalid BST and 
// returns a boolean representing whether the BST is valid or not.

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program {
    // O(n) time | O(d) space
	public static bool ValidateBst(BST tree) {
		return ValidateBst(tree, Int32.MinValue, Int32.MaxValue);
	}

	public static bool ValidateBst(BST tree, int minValue, int maxValue){
		if (tree.value < minValue || tree.value >= maxValue){
			return false;
		}
		if (tree.left != null && !ValidateBst(tree.left, minValue, tree.value)){
			return false;
		}
		if (tree.right != null && !ValidateBst(tree.right, tree.value, maxValue)){
			return false;
		}
		return true;
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

//////////////////////////////////////////////////////////////////
// BST TRAVERSAL
// Write three functions that take in a BST and an empty array, traverse the BST and 
// add the nodes to the array using in-order, pre-order, post-order

////////////////////////// SOLUTION 1 ////////////////////////////
public class Program {
	public static List<int> InOrderTraverse(BST tree, List<int> array) {
		if (tree.left != null){
			InOrderTraverse(tree.left, array);
		}
		array.Add(tree.value);
		if (tree.right != null){
			InOrderTraverse(tree.right, array);
		}
		return array;
	}

	public static List<int> PreOrderTraverse(BST tree, List<int> array) {
		array.Add(tree.value);
		if (tree.left != null){
			PreOrderTraverse(tree.left, array);
		}
		if (tree.right != null){
			PreOrderTraverse(tree.right, array);
		}
		return array;
	}

	public static List<int> PostOrderTraverse(BST tree, List<int> array) {
		if (tree.left != null){
			PostOrderTraverse(tree.left, array);
		}
		if (tree.right != null){
			PostOrderTraverse(tree.right, array);
		}
		array.Add(tree.value);
		return array;
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

//////////////////////////////////////////////////////////////////
// MIN HEIGHT BST
// Write a function that takes a non-emty sorted array of distinct integers,
// constructs a BST from the ints and return the root. The funtion should minimize the height of the BST

////////////////////////// SOLUTION 1 ////////////////////////////
public class Program {
	//O(n) time | O(n) space - N is the length of the array
	public static BST MinHeightBst(List<int> array) {
		return constructminHeightBst(array, 0, array.Count - 1);
	}
	
	public static BST constructminHeightBst(List<int> array, int startIdx, int endIdx){
		if (endIdx < startIdx) return null;
		int midIdx = (startIdx + endIdx) / 2;
		BST bst = new BST(array[midIdx]);
		bst.left = constructminHeightBst(array, startIdx, midIdx - 1);
		bst.right = constructminHeightBst(array, midIdx + 1, endIdx);
		return bst;
	}

	public class BST {
		public int value;
		public BST left;
		public BST right;

		public BST(int value) {
			this.value = value;
			left = null;
			right = null;
		}

		
		// if we were to use this funtion we would actually have O(Nlog(N)) time
		// we don't use this method for this solution
		public void insert(int value) {
			if (value < this.value) {
				if (left == null) {
					left = new BST(value);
				} else {
					left.insert(value);
				}
			} else {
				if (right == null) {
					right = new BST(value);
				} else {
					right.insert(value);
				}
			}
		}
	}
}

//////////////////////////////////////////////////////////////////
// INVERT BINARY TREE
// write a function that takes a Binary Tree and inverts it.
// In other words the function shouls swap every left node in the tree for its corresponding right node

////////////////////////// SOLUTION 1 ////////////////////////////
public class Program {
	// O(n) time | O(d) space
	public static void InvertBinaryTree(BinaryTree tree) {
		if (tree == null){
			return;
		}
		swapLeftAndRight(tree);
		InvertBinaryTree(tree.left);
		InvertBinaryTree(tree.right);
	}
	
	private static void swapLeftAndRight(BinaryTree tree){
		BinaryTree left = tree.left;
		tree.left = tree.right;
		tree.right = left;
	}

	public class BinaryTree {
		public int value;
		public BinaryTree left;
		public BinaryTree right;

		public BinaryTree(int value) {
			this.value = value;
		}
	}
}

//////////////////////////////////////////////////////////////////
// MAX SUBSET SUM NO ADJACENT
// write a function that takes in an array of positive ints and returns
// the max sum od non-adjacent elements in the array

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program {
	// O(n) time | O(n) space
	public static int MaxSubsetSumNoAdjacent(int[] array) {
		if (array.Length == 0){
			return 0;
		} else if (array.Length == 1){
			return array[0];
		}
		int[] maxSums = (int[]) array.Clone();
		maxSums[1] = Math.Max(array[0], array[1]);
		for (int i = 2; i < array.Length; i++){
			maxSums[i] = Math.Max(maxSums[i-1], maxSums[i-2] + array[i]);
		}
		return maxSums[array.Length - 1];
	}
}

////////////////////////// SOLUTION 2 ////////////////////////////

public class Program {
	// O(n) time | O(1) space
	public static int MaxSubsetSumNoAdjacent(int[] array) {
		if (array.Length == 0){
			return 0;
		} else if (array.Length == 1){
			return array[0];
		}
		int second = array[0];
		int first = Math.Max(array[0], array[1]);
		for(int i = 2; i < array.Length; i++){
			int current = Math.Max(first, second + array[i]);
			second = first;
			first = current;
		}
		return first;
	}
}
