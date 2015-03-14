using UnityEngine;
using System.Collections;

public class MazePiece
{
	public enum Type {Straight, Corner, Junction}

	public bool topLeft = false;
	public bool topMiddle = false;
	public bool topRight = false;
	public bool middleLeft = false;
	public bool middleMiddle = false;
	public bool middleRight = false;
	public bool bottomLeft = false;
	public bool bottomMiddle = false;
	public bool bottomRight = false;

	Type type = Type.Junction;

	public Type GetMazeType()
	{
		if (!topMiddle && !middleLeft && !middleRight)
			return Type.Corner;

		if (!bottomMiddle && !middleLeft && !middleRight)
			return Type.Corner;

		if (!middleLeft && !topMiddle && !bottomMiddle)
			return Type.Corner;

		if (!middleRight && !topMiddle && !bottomMiddle)
			return Type.Corner;

		//If corner is a bottom right corner.
		if (!topLeft && topMiddle && !topRight && middleLeft && !middleRight && !bottomLeft && !bottomMiddle && !bottomRight)
			return Type.Corner;

		//If corner is a top right corner.
		if (!topLeft && !topMiddle && !topRight && middleLeft && !middleRight && !bottomLeft && bottomMiddle && !bottomRight)
			return Type.Corner;

		//If corner is top left.
		if (!topLeft && !topMiddle && !topRight && !middleLeft && middleRight && !bottomLeft && bottomMiddle && !bottomRight)
			return Type.Corner;

		//If corner is bottom left.
		if (!topLeft && topMiddle && !topRight && !middleLeft && middleRight && !bottomLeft && !bottomMiddle && !bottomRight)
			return Type.Corner;

		//Straights

//		//All top row
//		if (!topMiddle && bottomMiddle && middleLeft && middleRight && bottomLeft && bottomRight && !topRight && !topLeft)
//			return Type.Straight;
//
//		//All bottom row
//		if (topMiddle && !bottomMiddle && middleLeft && middleRight && !bottomLeft && !bottomRight && topRight && topLeft)
//			return Type.Straight;
//
//		//All left row
//		if (topMiddle && bottomMiddle && !middleLeft && middleRight && !bottomLeft && bottomRight && topRight && !topLeft)
//			return Type.Straight;
//
//		//All right row
//		if (topMiddle && bottomMiddle && middleLeft && !middleRight && bottomLeft && !bottomRight && !topRight && topLeft)
//			return Type.Straight;
//
//		if (topMiddle && bottomMiddle && !middleLeft && !middleRight && !bottomLeft && !bottomRight && !topRight && !topLeft)
//			return Type.Straight;
//
//		if (topMiddle && !bottomMiddle && !middleLeft && !middleRight && !bottomLeft && !bottomRight && !topRight && !topLeft)
//			return Type.Straight;
//
//		if (!topMiddle && bottomMiddle && !middleLeft && !middleRight && !bottomLeft && !bottomRight && !topRight && !topLeft)
//			return Type.Straight;
//
//		if (!topMiddle && !bottomMiddle && middleLeft && middleRight && !bottomLeft && !bottomRight && !topRight && !topLeft)
//			return Type.Straight;
//
//		if (!topMiddle && !bottomMiddle && !middleLeft && middleRight && !bottomLeft && !bottomRight && !topRight && !topLeft)
//			return Type.Straight;
//
//		if (!topMiddle && !bottomMiddle && middleLeft && !middleRight && !bottomLeft && !bottomRight && !topRight && !topLeft)
//			return Type.Straight;

		return Type.Junction;
	}
}
