using System;
using System.Collections.Generic;


//////////////////////////////////////////////////////////////////
// Write a function that takes in a Binary Tree and returns a list of 
// branch sums ordered from the leftmost branch to the rightmost branch.
// A branch sum the the summ of all the values in the branch

////////////////////////// SOLUTION 1 ////////////////////////////
public class Program {
	
	public class BinaryTree {
		public int value;
		public BinaryTree left;
		public BinaryTree right;

		public BinaryTree(int value) {
			this.value = value;
			this.left = null;
			this.right = null;
		}
	}

	public static List<int> BranchSums(BinaryTree root) {
		List<int> sums = new List<int>();
		calculateBranchSums(root, 0 , sums);
		return sums;
	}
	
	public static void calculateBranchSums(BinaryTree node, int runningSum, List<int> sums){
		if (node == null) return;
		
		int newRunningSum = runningSum + node.value;
		if (node.left == null && node.right == null) {
			sums.Add(newRunningSum);
			return;
		}
		
		calculateBranchSums(node.left, newRunningSum, sums);
		calculateBranchSums(node.right, newRunningSum, sums);
	}
}

//////////////////////////////////////////////////////////////////
// Write a function that takes in a Binary Tree and returns the 
// sum of its nodes' depths. Children nodes can either be BinaryTree
// nodes themselves or None /null.

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program {
	public static int NodeDepths(BinaryTree root) {
		int sumOfDepths = 0;
		Stack<Level> stack = new Stack<Level>();
		stack.Push(new Level(root, 0));
		while (stack.Count > 0){
			Level top = stack.Pop();
			
			BinaryTree node = top.root;
			int depth = top.depth;
			if (node == null) continue;
			
			sumOfDepths += depth;
			stack.Push(new Level(node.left, depth + 1));
			stack.Push(new Level(node.right, depth + 1));
		}
		return sumOfDepths;
	}

	public class Level {
		public BinaryTree root;
		public int depth;
		
		public Level(BinaryTree root, int depth) {
			this.root = root;
			this.depth = depth;
		}
	}
	public class BinaryTree {
		public int value;
		public BinaryTree left;
		public BinaryTree right;

		public BinaryTree(int value) {
			this.value = value;
			left = null;
			right = null;
		}
	}
}

////////////////////////// SOLUTION 2 ////////////////////////////

public class Program {
	public static int NodeDepths(BinaryTree root) {
		return nodeDepthsHelper(root, 0);
	}

	public static int nodeDepthsHelper(BinaryTree root, int depth){
		if (root == null) return 0;
		return depth + nodeDepthsHelper(root.left, depth + 1) +
					   nodeDepthsHelper(root.right, depth + 1);
	}
	
	public class BinaryTree {
		public int value;
		public BinaryTree left;
		public BinaryTree right;

		public BinaryTree(int value) {
			this.value = value;
			left = null;
			right = null;
		}
	}
}

//////////////////////////////////////////////////////////////////
// DEPTH FIRST SEARCH 
// 
// TIME COMPLEXITY - O(V + E) :: SPACE COMPLEXITY - O(V)

public class Program {
	
	public class Node {
		public string name;
		public List<Node> children = new List<Node>();

		public Node(string name) {
			this.name = name;
		}

		public List<string> DepthFirstSearch(List<string> array) {
			array.Add(this.name);
			for (int i = 0; i < children.Count; i++){
				children[i].DepthFirstSearch(array);
			}
			return array;
		}

		public Node AddChild(string name) {
			Node child = new Node(name);
			children.Add(child);
			return this;
		}
	}
}

//////////////////////////////////////////////////////////////////
// Nth Fibonacci
// The first number of the sequence is 0, the second is 1, and the 
// nth number id the sum of the (n-1)th and (n-2)th number.

////////////////////////// SOLUTION 1 ////////////////////////////

public class Program {
	// O(2^n) time | O(n) space
	public static int GetNthFib(int n) {
		if (n == 2){
			return 1;
		} else if (n == 1) {
			return 0;
		} else {
			return GetNthFib(n -1) + GetNthFib(n-2);
		}
	}
}

////////////////////////// SOLUTION 2 ////////////////////////////
public class Program {
	// O(n) time | O(n) space
	public static int GetNthFib(int n) {
		Dictionary<int, int> memoize = new Dictionary<int, int>();
		memoize.Add(1,0);
		memoize.Add(2,1);
		return GetNthFib(n, memoize);
	}
	
	public static int GetNthFib(int n, Dictionary<int, int> memoize){
		if (memoize.ContainsKey(n)){
			return memoize[n];
		} else {
			memoize.Add(n, GetNthFib(n-1, memoize) + GetNthFib(n-2, memoize));
			return memoize[n];
		}
	}
}

////////////////////////// SOLUTION 3 ////////////////////////////
public class Program {
	// O(n) time | O(1) space
	public static int GetNthFib(int n) {
		int[] lastTwo = {0,1};
		int counter = 3;
		while (counter <= n) {
			int nextFib = lastTwo[0] + lastTwo[1];
			lastTwo[0] = lastTwo[1];
			lastTwo[1] = nextFib;
			counter++;
		}
		return n > 1 ? lastTwo[1] : lastTwo[0];
	}
}
