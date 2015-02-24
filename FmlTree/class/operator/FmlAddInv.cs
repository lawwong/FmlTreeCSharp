namespace FmlTreeCSharp {
	public class FmlAddInv : FmlArityOp {
		public FmlAddInv(BaseValueType t) : this(t, null) { }
		public FmlAddInv(BaseValueType t, FmlNode v)
			: base(t, 1) {
			Value = v;
		}

		public FmlNode Value {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public override string CalculateString() {
			return CalString("AddInv");
		}

		protected sealed override void Calculate() {
			switch (BaseType) {
				case BaseValueType.Double: {
					_SetDouble(-Value.GetDouble());
					break;
				}
				case BaseValueType.Single: {
					_SetSingle(-Value.GetSingle());
					break;
				}
				case BaseValueType.Int64: {
					_SetInt64(-Value.GetInt64());
					break;
				}
				case BaseValueType.Int32:
				default: {
					_SetInt32(-Value.GetInt32());
					break;
				}
			}
		}
	}
}
