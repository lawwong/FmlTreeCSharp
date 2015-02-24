using System;

namespace FmlTreeCSharp {
	public class FmlSqrt : FmlArityOp {
		public FmlSqrt(BaseValueType t) : this(t, null) { }
		public FmlSqrt(BaseValueType t, FmlNode v)
			: base(t, 1) {
			Value = v;
		}

		public FmlNode Value {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public override string CalculateString() {
			return CalString("Sqrt");
		}

		protected sealed override void Calculate() {
			_SetDouble(Math.Sqrt(Value.GetDouble()));
		}
	}
}
