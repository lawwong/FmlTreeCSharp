using System;

namespace FmlTreeCSharp {
	public class FmlAbs : FmlArityOp {
		public FmlAbs(BaseValueType t) : this(t, null) { }
		public FmlAbs(BaseValueType t, FmlNode v)
			: base(t, 1) {
			Value = v;
		}

		public FmlNode Value {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public override string CalculateString() {
			return CalString("Abs");
		}

		protected sealed override void Calculate() {
			switch (BaseType) {
				case BaseValueType.Double: {
					_SetDouble(Math.Abs(Value.GetDouble()));
					break;
				}
				case BaseValueType.Single: {
					_SetSingle(Math.Abs(Value.GetSingle()));
					break;
				}
				case BaseValueType.Int64: {
					_SetInt64(Math.Abs(Value.GetInt64()));
					break;
				}
				case BaseValueType.Int32:
				default: {
					_SetInt32(Math.Abs(Value.GetInt32()));
					break;
				}
			}
		}
	}
}
