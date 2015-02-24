using System;

namespace github.com.lawwong.FmlTreeCSharp {
	public class FmlLogE : FmlArityOp {
		public FmlLogE(BaseValueType t) : this(t, null) { }
		public FmlLogE(BaseValueType t, FmlNode v)
			: base(t, 1) {
			Value = v;
		}

		public FmlNode Value {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public override string CalculateString() {
			return CalString("LogE");
		}

		protected sealed override void Calculate() {
			_SetDouble(Math.Log(Value.GetDouble()));
		}
	}
}
