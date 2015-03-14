using UnityEngine;
using System.Collections;

public class MazeGenerator
{
	public enum Direction {Horizontal, Vertical}

	public int[,] CreateMaze(int seed, int width, int height, int subdivisions)
	{
		int[,] output = new int[width, height];

		//Set seed.
		Random.seed = seed;

		//output = Devide (output, 0, 0, width, height, ChooseDirection (width, height));
		//output = CheapAndDirtyMazeGen (width, height);
		output = BreadthMaze (width, height);
		return output;
	}

	private int[,] DetectPiecesOfMaze(int[,] maze, int width, int height)
	{
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				if (maze[x, y] == 0)
					continue;
				
				int edgeCount = 0;
				
				MazePiece piece = new MazePiece();
				
				if (x > 0)
				{
					if (maze[x - 1, y] > 0)
					{
						piece.middleLeft = true;
					}
				}
				
				if (x < width - 2)
				{
					if (maze[x + 1, y] > 0)
					{
						piece.middleRight = true;
					}
				}
				
				if (y > 0)
				{
					if (maze[x, y - 1] > 0)
					{
						piece.bottomMiddle = true;
					}
				}
				
				if (y < height - 2)
				{
					if (maze[x, y + 1] > 0)
					{
						piece.topMiddle = true;
					}
				}
				
				if (x > 0 && (y > 0))
				{
					if (maze[x - 1, y - 1] > 0)
					{
						piece.bottomLeft = true;
					}
				}
				
				if (x < width - 2 && (y > 0))
				{
					if (maze[x + 1, y - 1] > 0)
					{
						piece.bottomRight = true;
					}
				}
				
				if (x < width - 2 && y < height - 2)
				{
					if (maze[x + 1, y + 1] > 0)
					{
						piece.topRight = true;
					}
				}
				
				if (x > 0 && y < height - 2)
				{
					if (maze[x - 1, y + 1] > 0)
					{
						piece.topLeft = true;
					}
				}
				
				//Get Part
				if (piece.GetMazeType() == MazePiece.Type.Straight)
				{
					Debug.Log ("Straight");
					//Straight
					maze[x, y] = 1;
				}
				else if (piece.GetMazeType() == MazePiece.Type.Corner)
				{
					//Corner
					maze[x, y] = 2;
				}
				else
					maze[x, y] = 3; // Junction
			}
		}

		return maze;
	}

	private int[,] BreadthMaze(int width, int height)
	{
		int[,] output = new int[width, height];

		//Fill maze with walls.
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				output[x,y] = 1;
			}
		}

		//Pick place to start
		int startX = Random.Range (0, width);
		int startY = Random.Range (0, height);

		output [startX, startY] = 0;

		MazeDigger (output, startX, startY, width, height);

		return DetectPiecesOfMaze (output, width, height);
	}

	private void MazeDigger(int[,] maze, int x, int y, int width, int height)
	{
		int[] directions = new int[] {1, 2, 3, 4};
		directions = Shuffe (directions);

		for (int i = 0; i < directions.Length; i++)
		{
			switch (directions[i])
			{
			case 1:
				if (x - 2 <= 0)
					continue;

				if (maze[x - 2, y] != 0)
				{
					maze[x - 2, y] = 0;
					maze[x - 1, y] = 0;

					MazeDigger (maze, x - 2, y, width, height);
				}
				break;
			case 2:
				if (y + 2 >= height - 1)
					continue;
				
				if (maze[x, y + 2] != 0)
				{
					maze[x, y + 2] = 0;
					maze[x, y + 1] = 0;
					
					MazeDigger (maze, x, y + 2, width, height);
				}
				break;
			case 3:
				if (x + 2 >= width - 1)
					continue;
				
				if (maze[x + 2, y] != 0)
				{
					maze[x + 2, y] = 0;
					maze[x + 1, y] = 0;
					
					MazeDigger (maze, x + 2, y, width, height);
				}
				break;
			case 4:
				if (y - 2 <= 0)
					continue;
				
				if (maze[x, y - 2] != 0)
				{
					maze[x, y - 2] = 0;
					maze[x, y - 1] = 0;
					
					MazeDigger (maze, x, y - 2, width, height);
				}
				break;
			}
		}
	}

	private static T[] Shuffe<T>(T[] array)
	{
		for (int i = array.Length; i> 1; i--)
		{
			int j = Random.Range(0, array.Length);

			T temp = array[j];
			array[j] = array[i - 1];
			array[i - 1] = temp;
		}

		return array;
	}

//	private int[,] CheapAndDirtyMazeGen(int width, int height)
//	{
//		int [,] output = new int[width, height];
//
//		for (int x = 0; x < width; x++)
//		{
//			for (int y = 0; y < height; y++)
//			{
//				output[x, y] = 1;
//			}
//		}
//
//		for (int i = 0; i < 30; i++)
//		{
//			int startX = Random.Range(0, width);
//			int startY = Random.Range(0, height);
//
//			int endX = Random.Range(0, width);
//			int endY = Random.Range(0, height);
//
//			int currentX = startX;
//			int currentY = startY;
//
//			while (currentX != endX || currentY != endY)
//			{
//				output[currentX, currentY] = 0;
//
//				if (currentX < endX)
//				{
//					currentX++;
//					continue;
//				}
//				else if (currentX > endX)
//				{
//					currentX--;
//					continue;
//				}
//				else if (currentY < endY)
//				{
//					currentY++;
//					continue;
//				}
//				else if (currentY > endY)
//				{
//					currentY--;
//					continue;
//				}
//			}
//		}
//
//		//Set Edges as 1
//		for (int x = 0; x < width; x++)
//		{
//			output[x, 0] = 1;
//			output[x, height - 1] = 1;
//		}
//
//		for (int y = 0; y < height; y++)
//		{
//			output[0, 0] = 1;
//			output[width - 1, y] = 1;
//		}
//
//		for (int x = 0; x < width; x++)
//		{
//			for (int y = 0; y < height; y++)
//			{
//				if (output[x, y] == 0)
//					continue;
//
//				int edgeCount = 0;
//
//				MazePiece piece = new MazePiece();
//
//				if (x > 0)
//				{
//					if (output[x - 1, y] > 0)
//					{
//						piece.middleLeft = true;
//					}
//				}
//
//				if (x < width - 2)
//				{
//					if (output[x + 1, y] > 0)
//					{
//						piece.middleRight = true;
//					}
//				}
//
//				if (y > 0)
//				{
//					if (output[x, y - 1] > 0)
//					{
//						piece.bottomMiddle = true;
//					}
//				}
//				
//				if (y < height - 2)
//				{
//					if (output[x, y + 1] > 0)
//					{
//						piece.topMiddle = true;
//					}
//				}
//
//				if (x > 0 && (y > 0))
//				{
//					if (output[x - 1, y - 1] > 0)
//					{
//						piece.bottomLeft = true;
//					}
//				}
//
//				if (x < width - 2 && (y > 0))
//				{
//					if (output[x + 1, y - 1] > 0)
//					{
//						piece.bottomRight = true;
//					}
//				}
//
//				if (x < width - 2 && y < height - 2)
//				{
//					if (output[x + 1, y + 1] > 0)
//					{
//						piece.topRight = true;
//					}
//				}
//
//				if (x > 0 && y < height - 2)
//				{
//					if (output[x - 1, y + 1] > 0)
//					{
//						piece.topLeft = true;
//					}
//				}
//
//				//Get Part
//				if (piece.GetMazeType() == MazePiece.Type.Straight)
//				{
//					Debug.Log ("Straight");
//					//Straight
//					output[x, y] = 1;
//				}
//				else if (piece.GetMazeType() == MazePiece.Type.Corner)
//				{
//					//Corner
//					output[x, y] = 2;
//				}
//				else
//					output[x, y] = 3; // Junction
//			}
//		}
//
//		return output;
//	}
//
//	private int[,] JordanDivide(int[,] maze, int x, int y, int width, int height, Direction direction)
//	{
//		if (width < 2 || height < 2)
//			return maze;
//
//		int startX = x;
//		int startY = y;
//
//		int length = 0;
//
//		int xAddition = 0;
//		int yAddition = 0;
//
//		//Pick a point to draw a line.
//		if (direction == Direction.Horizontal)
//		{
//			startX = Random.Range (x, width);
//			startY = y;
//
//			length = width = startX;
//			xAddition = 1;
//		}
//		else
//		{
//			startX = x;
//			startY = Random.Range (y, height);
//
//			length = height = startY;
//			yAddition = 1;
//		}
//
//		int currentX = startX;
//		int currentY = startY;
//
//		for (int l = 0; l < length; l++)
//		{
//			maze[currentX, currentY] = 1;
//
//			currentX += xAddition;
//			currentY += yAddition;
//		}
//
//		//Create a hole
//		if (direction == Direction.Horizontal)
//		{
//			maze[Random.Range (startX, width), startY] = 0;
//		}
//		else
//			maze[startX, Random.Range (startY, height)] = 0;
//
//		//Recursion
//		if (direction == Direction.Horizontal)
//			maze = JordanDivide (maze, startX, y, width - startX, height, ChooseDirection (width - startX, height));
//		else
//			maze = JordanDivide (maze, x, startY, width, height - startY, ChooseDirection (width, height - startY));
//
//		if (direction == Direction.Horizontal)
//			maze = JordanDivide (maze, width - startX, y, width, height, ChooseDirection (width, height));
//		else
//			maze = JordanDivide (maze, x, height - startY, width, height, ChooseDirection (width, height));
//
//		return maze;
//	}
//
//	private int[,] Devide(int[,] maze, int x, int y, int width, int height, Direction direction)
//	{
//		if (width < 2 || height < 2)
//			return maze;
//
//		int wx = 0;
//		int wy = 0;
//
//		int startLength = 0;
//		int length = 0;
//
//		if (direction == Direction.Horizontal)
//		{
//			wx = x;
//			wy = y + Random.Range (0, height - 2);
//
//			startLength = x;
//			length = width;
//		}
//		else if (direction == Direction.Vertical)
//		{
//			wx = x + Random.Range (0, width - 2);
//			wy = y;
//
//			startLength = y;
//			length = height;
//		}
//
//		int px = 0;
//		int py = 0;
//
//		//Carve a passage
//		if (direction == Direction.Horizontal)
//		{
//			px = wx + Random.Range (0, width);
//			py = 0;
//		}
//		else if (direction == Direction.Vertical)
//		{
//			px = 0;
//			py = Random.Range (0, height);
//		}
//
//		int dx = 0;
//		int dy = 0;
//
//		if (direction == Direction.Horizontal)
//			dx = 1;
//		else if (direction == Direction.Vertical)
//			dy = 1;
//
//		int dir = 0;
//
//		if (direction == Direction.Horizontal)
//			dir = 0;
//		else if (direction == Direction.Vertical)
//			dir = 1;
//
//		for (int l = startLength; l < length; l++)
//		{
//			if (wx != px || wy != py)
//				maze[wy, wx] = 1;
//
//			wx += dx;
//			wy += dy;
//		}
//
//
//
//		//Find the newly created field and recurse.
//		int nx = x;
//		int ny = y;
//
//		int w = 0;
//		int h = 0;
//
//		//Process Devision 1
//		if (direction == Direction.Horizontal)
//		{
//			w = width;
//			h = wy - y + 1;
//		}
//		else if (direction == Direction.Vertical)
//		{
//			w = wx - x + 1;
//			h = height;
//		}
//
//		maze = Devide (maze, nx, ny, w, h, ChooseDirection(w, h));
//
//		//Process Devision 2
//		if (direction == Direction.Horizontal)
//		{
//			nx = x;
//			ny = wy + 1;
//
//			w = width;
//			h = y + height - wy - 1;
//		}
//		else if (direction == Direction.Vertical)
//		{
//			nx = wx + 1;
//			ny = y;
//
//			w = x + width - wx - 1;
//			h = height;
//		}
//		
//		maze = Devide (maze, nx, ny, w, h, ChooseDirection(w, h));
//
//		return maze;
//	}
//
//	private Direction ChooseDirection(int width, int height)
//	{
//		//TODO: Add weights for width and height.
//
//		if (Random.Range (0, 2) == 0)
//			return Direction.Horizontal;
//		else 
//			return Direction.Vertical;
//	}
}
