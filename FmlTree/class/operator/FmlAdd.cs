namespace FmlTreeCSharp {
	public class FmlAdd : FmlVariableOp {
		public FmlAdd(BaseValueType t) : base(t) { }

		public override string CalculateString() {
			return CalString("", " + ");
		}

		protected sealed override void Calculate() {
			switch (BaseType) {
				case BaseValueType.Double: {
					double result = .0;
					foreach (FmlNode child in Children) {
						result += child.GetDouble();
					}
					_SetDouble(result);
					break;
				}
				case BaseValueType.Single: {
					float result = 0f;
					foreach (FmlNode child in Children) {
						result += child.GetSingle();
					}
					_SetSingle(result);
					break;
				}
				case BaseValueType.Int64: {
					long result = 0L;
					foreach (FmlNode child in Children) {
						result += child.GetInt64();
					}
					_SetInt64(result);
					break;
				}
				case BaseValueType.Int32:
				default: {
					int result = 0;
					foreach (FmlNode child in Children) {
						result += child.GetInt32();
					}
					_SetInt32(result);
					break;
				}
			}
		}
	}
}
