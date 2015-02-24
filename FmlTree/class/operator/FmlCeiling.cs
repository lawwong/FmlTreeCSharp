using System;

namespace FmlTreeCSharp {
	public class FmlCeiling : FmlArityOp {
		public FmlCeiling(BaseValueType t) : this(t, null) { }
		public FmlCeiling(BaseValueType t, FmlNode v)
			: base(t, 1) {
			Value = v;
		}

		public FmlNode Value {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public override string CalculateString() {
			return CalString("Ceiling");
		}

		protected sealed override void Calculate() {
			_SetDouble(Math.Ceiling(Value.GetDouble()));
		}
	}
}
