using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace github.com.lawwong.FmlTreeCSharp {
	public class BaseCl { }
	public class Cl : BaseCl { }
	class Program {
		static void Main(string[] args) {
			//(0.3 + (0.014 * (argA ^ 1.4))) * argB * (argC ^ 0.1)
			//(0.005 + (0.0001 * (argA ^ 1.7))) * argD / 2
			FmlArg argA = Fml.Arg(10);	// BaseType == int
			FmlArg argB = Fml.Arg(9999L);	// BaseType == long
			FmlArg argC = Fml.Arg(16.3f);	// BaseType == float
			FmlArg argD = Fml.Arg(22.5);	// BaseType == double

			FmlNode fml1;
			fml1 = Fml.Pow(argA, Fml.Arg(1.4));
			fml1 = Fml.Mul(fml1, Fml.Arg(0.014));
			fml1 = Fml.Add(fml1, Fml.Arg(0.3));
			fml1 = Fml.Mul(fml1, argB, Fml.Pow(argC, Fml.Arg(0.1)));
			fml1 = Fml.ToInt64(fml1);

			FmlNode fml2;
			fml2 = Fml.Pow(argA, Fml.Arg(1.7));
			fml2 = Fml.Mul(Fml.Arg(0.0001), fml2);
			fml2 = Fml.Add(Fml.Arg(0.005), fml2);
			fml2 = Fml.Mul(fml2, argD);
			fml2 = Fml.Div(fml2, Fml.Arg(2.0));

			Console.WriteLine("argA = " + argA);
			Console.WriteLine("--------------------------");

			Console.WriteLine("#fml1:");
			Console.WriteLine("Int32 = " + fml1.GetInt32());
			Console.WriteLine("Int64 = " + fml1.GetInt64());
			Console.WriteLine("Single = " + fml1.GetSingle());
			Console.WriteLine("Double = " + fml1.GetDouble());
			Console.WriteLine("ToString = " + fml1);	// print value stored in this node in form of fml1.BastType
			Console.WriteLine("CalculateString = " + fml1.CalculateString());	// opName[result](args...)
			Console.WriteLine("#fml2:");
			Console.WriteLine("Int32 = " + fml2.GetInt32());
			Console.WriteLine("Int64 = " + fml2.GetInt64());
			Console.WriteLine("Single = " + fml2.GetSingle());
			Console.WriteLine("Double = " + fml2.GetDouble());
			Console.WriteLine("ToString = " + fml2);
			Console.WriteLine("CalculateString = " + fml2.CalculateString());

			Console.WriteLine("--------------------------");
			argA.SetInt32(argA.GetInt32() + 1);
			Console.WriteLine("increase argA by one...");
			Console.WriteLine("argA = " + argA);
			Console.WriteLine("--------------------------");

			Console.WriteLine("#fml1:");
			Console.WriteLine("Int32 = " + fml1.GetInt32());
			Console.WriteLine("Int64 = " + fml1.GetInt64());
			Console.WriteLine("Single = " + fml1.GetSingle());
			Console.WriteLine("Double = " + fml1.GetDouble());
			Console.WriteLine("ToString = " + fml1);
			Console.WriteLine("CalculateString = " + fml1.CalculateString());
			Console.WriteLine("#fml2:");
			Console.WriteLine("Int32 = " + fml2.GetInt32());
			Console.WriteLine("Int64 = " + fml2.GetInt64());
			Console.WriteLine("Single = " + fml2.GetSingle());
			Console.WriteLine("Double = " + fml2.GetDouble());
			Console.WriteLine("ToString = " + fml2);
			Console.WriteLine("CalculateString = " + fml2.CalculateString());

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
