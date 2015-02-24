using System;

namespace FmlTreeCSharp {
	public class FmlLog10 : FmlArityOp {
		public FmlLog10(BaseValueType t) : this(t, null) { }
		public FmlLog10(BaseValueType t, FmlNode v)
			: base(t, 1) {
			Value = v;
		}

		public FmlNode Value {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public override string CalculateString() {
			return CalString("Log10");
		}

		protected sealed override void Calculate() {
			_SetDouble(Math.Log10(Value.GetDouble()));
		}
	}
}
