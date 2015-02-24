namespace FmlTreeCSharp {
	public class FmlToDouble : FmlArityOp {
		public FmlToDouble(FmlNode v)
			: base(BaseValueType.Double, 1) {
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
			_SetDouble(Value.GetDouble());
		}
	}
}
