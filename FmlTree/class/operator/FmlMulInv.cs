namespace github.com.lawwong.FmlTreeCSharp {
	public class FmlMulInv : FmlArityOp {
		public FmlMulInv(BaseValueType t) : this(t, null) { }
		public FmlMulInv(BaseValueType t, FmlNode v)
			: base(t, 1) {
			Value = v;
		}

		public FmlNode Value {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public override string CalculateString() {
			return CalString("MulInv");
		}

		protected sealed override void Calculate() {
			switch (BaseType) {
				case BaseValueType.Double: {
					_SetDouble(1.0 / Value.GetDouble());
					break;
				}
				case BaseValueType.Single: {
					_SetSingle(1f / Value.GetSingle());
					break;
				}
				case BaseValueType.Int64: {
					_SetInt64(1L / Value.GetInt64());
					break;
				}
				case BaseValueType.Int32:
				default: {
					_SetInt32(1 / Value.GetInt32());
					break;
				}
			}
		}
	}
}
