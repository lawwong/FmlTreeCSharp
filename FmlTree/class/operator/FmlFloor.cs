using System;

namespace github.com.lawwong.FmlTreeCSharp {
	public class FmlFloor : FmlArityOp {
		public FmlFloor(BaseValueType t) : this(t, null) { }
		public FmlFloor(BaseValueType t, FmlNode v)
			: base(t, 1) {
			Value = v;
		}

		public FmlNode Value {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public override string CalculateString() {
			return CalString("Floor");
		}

		protected sealed override void Calculate() {
			_SetDouble(Math.Floor(Value.GetDouble()));
		}
	}
}
