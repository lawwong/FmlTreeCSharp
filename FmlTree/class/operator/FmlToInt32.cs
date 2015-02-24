namespace FmlTreeCSharp {
	public class FmlToInt32 : FmlArityOp {
		public FmlToInt32(FmlNode v)
			: base(BaseValueType.Int32, 1) {
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
			_SetInt32(Value.GetInt32());
		}
	}
}
