namespace FmlTreeCSharp {
	public class FmlSub : FmlArityOp {
		public FmlSub(BaseValueType t) : this(t, null, null) { }
		// difference = minuend - subtrahend
		public FmlSub(BaseValueType t, FmlNode minuend, FmlNode subtrahend)
			: base(t, 2) {
			Minuend = minuend;
			Subtrahend = subtrahend;
		}

		public FmlNode Minuend {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public FmlNode Subtrahend {
			get { return this[1]; }
			set { this[1] = value; }
		}

		public override string CalculateString() {
			return CalString("", " - ");
		}

		protected sealed override void Calculate() {
			switch (BaseType) {
				case BaseValueType.Double: {
					_SetDouble(Minuend.GetDouble() - Subtrahend.GetDouble());
					break;
				}
				case BaseValueType.Single: {
					_SetSingle(Minuend.GetSingle() - Subtrahend.GetSingle());
					break;
				}
				case BaseValueType.Int64: {
					_SetInt64(Minuend.GetInt64() - Subtrahend.GetInt64());
					break;
				}
				case BaseValueType.Int32:
				default: {
					_SetInt32(Minuend.GetInt32() - Subtrahend.GetInt32());
					break;
				}
			}
		}
	}
}
