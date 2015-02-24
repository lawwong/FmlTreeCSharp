namespace github.com.lawwong.FmlTreeCSharp {
	public class FmlToSingle : FmlArityOp {
		public FmlToSingle(FmlNode v)
			: base(BaseValueType.Single, 1) {
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
			_SetSingle(Value.GetSingle());
		}
	}
}
