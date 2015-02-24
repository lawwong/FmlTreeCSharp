namespace github.com.lawwong.FmlTreeCSharp {
	public class FmlToInt64 : FmlArityOp {
		public FmlToInt64(FmlNode v)
			: base(BaseValueType.Int64, 1) {
			Value = v;
		}

		public FmlNode Value {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public override string CalculateString() {
			return CalString("To");
		}

		protected sealed override void Calculate() {
			_SetInt64(Value.GetInt64());
		}
	}
}
