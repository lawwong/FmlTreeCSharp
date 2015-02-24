using System;

namespace FmlTreeCSharp {
	public class FmlLog : FmlArityOp {
		public FmlLog(BaseValueType t) : this(t, null, null) { }
		// difference = minuend - subtrahend
		public FmlLog(BaseValueType t, FmlNode value, FmlNode newBase)
			: base(t, 2) {
			Value = value;
			Base = newBase;
		}

		public FmlNode Value {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public FmlNode Base {
			get { return this[1]; }
			set { this[1] = value; }
		}

		public override string CalculateString() {
			return CalString("Log");
		}

		protected sealed override void Calculate() {
			_SetDouble(Math.Log(Value.GetDouble(), Base.GetDouble()));
		}
	}
}
