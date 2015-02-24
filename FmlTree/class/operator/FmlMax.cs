using System;

namespace FmlTreeCSharp {
	public class FmlMax : FmlVariableOp {
		public FmlMax(BaseValueType t) : base(t) { }

		public override string CalculateString() {
			return CalString("Max");
		}

		protected sealed override void Calculate() {
			if (ChildCount < 1) { throw new Exception("ChildCount is less than 1"); }
			switch (BaseType) {
				case BaseValueType.Double: {
					double result = Double.MinValue;
					foreach (FmlNode child in Children) {
						result = Math.Max(result, child.GetDouble());
					}
					_SetDouble(result);
					break;
				}
				case BaseValueType.Single: {
					float result = Single.MinValue;
					foreach (FmlNode child in Children) {
						result = Math.Max(result, child.GetSingle());
					}
					_SetSingle(result);
					break;
				}
				case BaseValueType.Int64: {
					long result = Int64.MinValue;
					foreach (FmlNode child in Children) {
						result = Math.Max(result, child.GetInt64());
					}
					_SetInt64(result);
					break;
				}
				case BaseValueType.Int32:
				default: {
					int result = Int32.MinValue;
					foreach (FmlNode child in Children) {
						result = Math.Max(result, child.GetInt32());
					}
					_SetInt32(result);
					break;
				}
			}
		}
	}
}

