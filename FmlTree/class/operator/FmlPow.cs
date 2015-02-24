using System;

namespace FmlTreeCSharp {
	public class FmlPow : FmlArityOp {
		public FmlPow(BaseValueType t) : this(t, null, null) { }
		// difference = minuend - subtrahend
		public FmlPow(BaseValueType t, FmlNode x, FmlNode y)
			: base(t, 2) {
			X = x;
			Y = y;
		}

		public FmlNode X {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public FmlNode Y {
			get { return this[1]; }
			set { this[1] = value; }
		}

		public override string CalculateString() {
			return CalString("", " ^ ");
		}

		protected sealed override void Calculate() {
			_SetDouble(Math.Pow(X.GetDouble(), Y.GetDouble()));
		}
	}
}
