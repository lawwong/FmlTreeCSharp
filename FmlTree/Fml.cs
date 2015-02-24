using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace github.com.lawwong.FmlTreeCSharp {
	public static class Fml {
		#region private function
		private static BaseValueType GetProperTypeByParams(params FmlNode[] args) {
			return GetProperType(args);
		}

		private static BaseValueType GetProperType(IEnumerable<FmlNode> args) {
			int t = (int)BaseValueType.Int32;
			foreach (FmlNode arg in args) {
				if (arg == null) { continue; }
				t = Math.Max(t, (int)arg.BaseType);
			}
			return (BaseValueType)t;
		}

		private static void AddChildrenToVariableBranch(FmlVariableOp op, IEnumerable<FmlNode> args) {
			foreach (FmlNode arg in args) {
				if (arg == null) { continue; }
				op.AddChild(arg);
			}
		}
		#endregion private function

		#region new arg
		public static FmlArg Arg(BaseValueType t) {
			return new FmlArg(t);
		}

		public static FmlArg Arg(int v) {
			return new FmlArg(v);
		}
		public static FmlArg Arg(BaseValueType t, int v) {
			FmlArg arg = new FmlArg(t);
			arg.SetInt32(v);
			return arg;
		}

		public static FmlArg Arg(long v) {
			return new FmlArg(v);
		}

		public static FmlArg Arg(BaseValueType t, long v) {
			FmlArg arg = new FmlArg(t);
			arg.SetInt64(v);
			return arg;
		}

		public static FmlArg Arg(float v) {
			return new FmlArg(v);
		}

		public static FmlArg Arg(BaseValueType t, float v) {
			FmlArg arg = new FmlArg(t);
			arg.SetSingle(v);
			return arg;
		}

		public static FmlArg Arg(double v) {
			return new FmlArg(v);
		}

		public static FmlArg Arg(BaseValueType t, double v) {
			FmlArg arg = new FmlArg(t);
			arg.SetDouble(v);
			return arg;
		}
		#endregion new arg

		#region variable arity operator
		public static FmlAdd Add(params FmlNode[] args) {
			return Add(GetProperType(args), args);
		}

		public static FmlAdd Add(BaseValueType t, params FmlNode[] args) {
			FmlAdd op = new FmlAdd(t);
			AddChildrenToVariableBranch(op, args);
			return op;
		}

		public static FmlMul Mul(params FmlNode[] args) {
			return Mul(GetProperType(args), args);
		}

		public static FmlMul Mul(BaseValueType t, params FmlNode[] args) {
			FmlMul op = new FmlMul(t);
			AddChildrenToVariableBranch(op, args);
			return op;
		}

		public static FmlMax Max(params FmlNode[] args) {
			return Max(GetProperType(args), args);
		}

		public static FmlMax Max(BaseValueType t, params FmlNode[] args) {
			FmlMax op = new FmlMax(t);
			AddChildrenToVariableBranch(op, args);
			return op;
		}

		public static FmlMin Min(params FmlNode[] args) {
			return Min(GetProperType(args), args);
		}

		public static FmlMin Min(BaseValueType t, params FmlNode[] args) {
			FmlMin op = new FmlMin(t);
			AddChildrenToVariableBranch(op, args);
			return op;
		}
		#endregion variable arity operator

		#region unary arity operator
		public static FmlAbs Abs(FmlNode arg) {
			return Abs(arg.BaseType, arg);
		}

		public static FmlAbs Abs(BaseValueType t, FmlNode arg) {
			return new FmlAbs(t, arg);
		}

		public static FmlCeiling Ceiling(FmlNode arg) {
			return Ceiling(BaseValueType.Int32, arg);
		}

		public static FmlCeiling Ceiling(BaseValueType t, FmlNode arg) {
			return new FmlCeiling(t, arg);
		}

		public static FmlFloor Floor(FmlNode arg) {
			return Floor(BaseValueType.Int32, arg);
		}

		public static FmlFloor Floor(BaseValueType t, FmlNode arg) {
			return new FmlFloor(t, arg);
		}

		public static FmlAddInv AddInv(FmlNode arg) {
			return AddInv(arg.BaseType, arg);
		}

		public static FmlAddInv AddInv(BaseValueType t, FmlNode arg) {
			return new FmlAddInv(t, arg);
		}

		public static FmlMulInv MulInv(FmlNode arg) {
			return MulInv(arg.BaseType, arg);
		}

		public static FmlMulInv MulInv(BaseValueType t, FmlNode arg) {
			return new FmlMulInv(t, arg);
		}

		public static FmlTruncate Truncate(FmlNode arg) {
			return Truncate(BaseValueType.Int32, arg);
		}

		public static FmlTruncate Truncate(BaseValueType t, FmlNode arg) {
			return new FmlTruncate(t, arg);
		}

		public static FmlLogE LogE(FmlNode arg) {
			return LogE(BaseValueType.Double, arg);
		}

		public static FmlLogE LogE(BaseValueType t, FmlNode arg) {
			return new FmlLogE(t, arg);
		}

		public static FmlLog10 Log10(FmlNode arg) {
			return Log10(BaseValueType.Double, arg);
		}

		public static FmlLog10 Log10(BaseValueType t, FmlNode arg) {
			return new FmlLog10(t, arg);
		}

		public static FmlSqrt Sqrt(FmlNode arg) {
			return Sqrt(BaseValueType.Double, arg);
		}

		public static FmlSqrt Sqrt(BaseValueType t, FmlNode arg) {
			return new FmlSqrt(t, arg);
		}

		public static FmlRound Round(FmlNode arg, int digit = 0, MidpointRounding mode = MidpointRounding.AwayFromZero) {
			return Round(arg.BaseType, arg, digit, mode);
		}

		public static FmlRound Round(BaseValueType t, FmlNode arg, int digit = 0, MidpointRounding mode = MidpointRounding.AwayFromZero) {
			return new FmlRound(t, arg, digit, mode);
		}

		public static FmlToInt32 ToInt32(FmlNode arg) {
			return new FmlToInt32(arg);
		}

		public static FmlToInt64 ToInt64(FmlNode arg) {
			return new FmlToInt64(arg);
		}

		public static FmlToSingle ToSingle(FmlNode arg) {
			return new FmlToSingle(arg);
		}

		public static FmlToDouble ToDouble(FmlNode arg) {
			return new FmlToDouble(arg);
		}
		#endregion unary arity operator

		#region binary arity operator
		public static FmlSub Sub(FmlNode minuend, FmlNode subtrahend) {
			return Sub(GetProperTypeByParams(minuend, subtrahend), minuend, subtrahend);
		}

		public static FmlSub Sub(BaseValueType t, FmlNode minuend, FmlNode subtrahend) {
			return new FmlSub(t, minuend, subtrahend);
		}

		public static FmlDiv Div(FmlNode dividend, FmlNode divisor) {
			return Div(GetProperTypeByParams(dividend, divisor), dividend, divisor);
		}

		public static FmlDiv Div(BaseValueType t, FmlNode dividend, FmlNode divisor) {
			return new FmlDiv(t, dividend, divisor);
		}

		public static FmlLog Log(FmlNode value, FmlNode newBase) {
			return Log(BaseValueType.Double, value, newBase);
		}

		public static FmlLog Log(BaseValueType t, FmlNode value, FmlNode newBase) {
			return new FmlLog(t, value, newBase);
		}

		public static FmlMod Mod(FmlNode dividend, FmlNode divisor) {
			return Mod(GetProperTypeByParams(dividend, divisor), dividend, divisor);
		}

		public static FmlMod Mod(BaseValueType t, FmlNode dividend, FmlNode divisor) {
			return new FmlMod(t, dividend, divisor);
		}

		public static FmlPow Pow(FmlNode x, FmlNode y) {
			return Pow(BaseValueType.Double, x, y);
		}

		public static FmlPow Pow(BaseValueType t, FmlNode x, FmlNode y) {
			return new FmlPow(t, x, y);
		}

		public static FmlRand Rand(int seed, FmlNode minValue, FmlNode maxValue, bool manualRand = false) {
			return Rand(GetProperTypeByParams(minValue, maxValue), seed, minValue, maxValue, manualRand);
		}

		public static FmlRand Rand(BaseValueType t, int seed, FmlNode minValue, FmlNode maxValue, bool manualRand = false) {
			return new FmlRand(t, seed, minValue, maxValue, manualRand);
		}
		#endregion binary arity operator

		#region ternary arity operator
		#endregion ternary arity operator
	}
}
