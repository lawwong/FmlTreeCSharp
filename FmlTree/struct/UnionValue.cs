using System;
using System.Runtime.InteropServices;

namespace github.com.lawwong.FmlTreeCSharp {
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	internal struct UnionValue {
		[FieldOffset(0)]
		public Int32 Int32;
		[FieldOffset(0)]
		public Int64 Int64;
		[FieldOffset(0)]
		public Single Single;
		[FieldOffset(0)]
		public Double Double;

		public UnionValue(BaseValueType type, int v) {
			Int32 = 0;
			Int64 = 0L;
			Single = 0f;
			Double = .0;
			switch (type) {
				case BaseValueType.Double:
				Double = (double)v;
				break;
				case BaseValueType.Single:
				Single = (float)v;
				break;
				case BaseValueType.Int64:
				Int64 = (long)v;
				break;
				case BaseValueType.Int32:
				default:
				Int32 = (int)v;
				break;
			}
		}

		public UnionValue(BaseValueType type, long v) {
			Int32 = 0;
			Int64 = 0;
			Single = 0f;
			Double = 0.0;
			switch (type) {
				case BaseValueType.Double:
				Double = (double)v;
				break;
				case BaseValueType.Single:
				Single = (float)v;
				break;
				case BaseValueType.Int64:
				Int64 = (long)v;
				break;
				case BaseValueType.Int32:
				default:
				Int32 = (int)v;
				break;
			}
		}

		public UnionValue(BaseValueType type, float v) {
			Int32 = 0;
			Int64 = 0;
			Single = 0f;
			Double = 0.0;
			switch (type) {
				case BaseValueType.Double:
				Double = (double)v;
				break;
				case BaseValueType.Single:
				Single = (float)v;
				break;
				case BaseValueType.Int64:
				Int64 = (long)v;
				break;
				case BaseValueType.Int32:
				default:
				Int32 = (int)v;
				break;
			}
		}

		public UnionValue(BaseValueType type, double v) {
			Int32 = 0;
			Int64 = 0;
			Single = 0f;
			Double = 0.0;
			switch (type) {
				case BaseValueType.Double:
				Double = (double)v;
				break;
				case BaseValueType.Single:
				Single = (float)v;
				break;
				case BaseValueType.Int64:
				Int64 = (long)v;
				break;
				case BaseValueType.Int32:
				default:
				Int32 = (int)v;
				break;
			}
		}

		public int GetInt32(BaseValueType type) {
			switch (type) {
				case BaseValueType.Double:
				return (int)Double;
				case BaseValueType.Single:
				return (int)Single;
				case BaseValueType.Int64:
				return (int)Int64;
				case BaseValueType.Int32:
				default:
				return (int)Int32;
			}
		}

		public long GetInt64(BaseValueType type) {
			switch (type) {
				case BaseValueType.Double:
				return (long)Double;
				case BaseValueType.Single:
				return (long)Single;
				case BaseValueType.Int64:
				return (long)Int64;
				case BaseValueType.Int32:
				default:
				return (long)Int32;
			}
		}

		public float GetSingle(BaseValueType type) {
			switch (type) {
				case BaseValueType.Double:
				return (float)Double;
				case BaseValueType.Single:
				return (float)Single;
				case BaseValueType.Int64:
				return (float)Int64;
				case BaseValueType.Int32:
				default:
				return (float)Int32;
			}
		}

		public double GetDouble(BaseValueType type) {
			switch (type) {
				case BaseValueType.Double:
				return (double)Double;
				case BaseValueType.Single:
				return (double)Single;
				case BaseValueType.Int64:
				return (double)Int64;
				case BaseValueType.Int32:
				default:
				return (double)Int32;
			}
		}
	}
}
