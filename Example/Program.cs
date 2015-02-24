using FmlTreeCSharp;
using System;

namespace Example {
	class Program {
		static void Main(string[] args) {
			// Support 4 base value type : int, long, float, double
			FmlArg argA = Fml.Arg(2);	// BaseType == int
			FmlArg argB = Fml.Arg(3L);	// BaseType == long
			FmlArg argC = Fml.Arg(4.1f);	// BaseType == float
			FmlArg argD = Fml.Arg(5.2);	// BaseType == double

			// Both FmlArg and FmlPow are FmlNode
			FmlPow powNode = Fml.Pow(Fml.Arg(3.5), argA);
			Console.WriteLine(powNode.GetDouble());	// 3.5 ^ 2 = 12.25

			// powNode store result in double but it can be retrieved by any other types
			Console.WriteLine(powNode.GetInt64());	// (long)12.25 = 12

			// Addition accept multiple FmlNode as arguments.
			// And most operator select type automatically, float addition is used in this case
			FmlAdd addNode = Fml.Add(argA, Fml.Arg(3), Fml.Arg(2.5f));
			Console.WriteLine(addNode.GetSingle());	// 2 + 3 + 2.5 = 7.5f

			// manipulate child nodes
			addNode.ReplaceChild(argA, argB);
			Console.WriteLine(addNode.GetSingle());	// 3 + 3 + 2.5 = 8.5f

			addNode.RemoveChild(argB);
			Console.WriteLine(addNode.GetSingle());	// 3 + 2.5 = 5.5f

			addNode.ClearChild();
			addNode.AddChild(argC);
			addNode.AddChild(powNode);
			Console.WriteLine(addNode.GetSingle());	// 4.1f + (3.5 ^ 2) = 16.35

			// multiple is similar to addition
			FmlMul mulNode = Fml.Mul(argC, Fml.Arg(2));
			Console.WriteLine(mulNode.GetSingle());	// 4.1f * 2 = 8.2f

			// calculate on demand
			argC.SetSingle(4.2f);
			// If only argC is out of date, addNode will recalculate, but powNode won't
			Console.WriteLine(addNode.GetSingle());	// 	4.2f + (3.5 ^ 2) = 16.45
			// mulNode will recalculate as well
			Console.WriteLine(mulNode.GetSingle());	// 4.2f * 2 = 8.4f

			// Call CalculateString() to get calculation detail for debug
			// The format of string is opName[resultValue](args...)
			Console.WriteLine(addNode.CalculateString());	// [16.45F](4.2F + [12.25](3.5 ^ 2))
			// Remember to get node result or FmlNode.Update() before calling it
			FmlFloor floorNode = Fml.Floor(argD);
			floorNode.Update();
			Console.WriteLine(floorNode.CalculateString());	// Floor[5](5.2)

			// Different type has their own signature
			Console.WriteLine(Fml.Arg(1));	// 1
			Console.WriteLine(Fml.Arg(1L));	// 1L
			Console.WriteLine(Fml.Arg(1f));	// 1.0F
			Console.WriteLine(Fml.Arg((double)1));	// 1.0

			Console.ReadLine();
			// TODO : more example
			// variable op
			// find recursive
			// random
			// explain convert type, base value type
			// use Div to explain auto op type and manual op type
		}
	}
}
