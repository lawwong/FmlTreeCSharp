using System;

namespace github.com.lawwong.FmlTreeCSharp {
	public class FmlTruncate : FmlArityOp {
		public FmlTruncate(BaseValueType t) : this(t, null) { }
		public FmlTruncate(BaseValueType t, FmlNode v)
			: base(t, 1) {
			Value = v;
		}

		public FmlNode Value {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public override string CalculateString() {
			return CalString("Truncate");
		}

		protected sealed override void Calculate() {
			_SetDouble(Math.Truncate(Value.GetDouble()));
		}
	}
}
