namespace github.com.lawwong.FmlTreeCSharp {
	public class FmlMod : FmlArityOp {
		public FmlMod(BaseValueType t) : this(t, null, null) { }
		// quotient = dividend - divisor
		public FmlMod(BaseValueType t, FmlNode dividend, FmlNode divisor)
			: base(t, 2) {
			Dividend = dividend;
			Divisor = divisor;
		}

		public FmlNode Dividend {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public FmlNode Divisor {
			get { return this[1]; }
			set { this[1] = value; }
		}

		public override string CalculateString() {
			return CalString("", " % ");
		}

		protected sealed override void Calculate() {
			switch (BaseType) {
				case BaseValueType.Double: {
					_SetDouble(Dividend.GetDouble() % Divisor.GetDouble());
					break;
				}
				case BaseValueType.Single: {
					_SetSingle(Dividend.GetSingle() % Divisor.GetSingle());
					break;
				}
				case BaseValueType.Int64: {
					_SetInt64(Dividend.GetInt64() % Divisor.GetInt64());
					break;
				}
				case BaseValueType.Int32:
				default: {
					_SetInt32(Dividend.GetInt32() % Divisor.GetInt32());
					break;
				}
			}
		}
	}
}
