using System;

namespace FmlTreeCSharp {
	public class FmlRound : FmlArityOp {
		public FmlRound(BaseValueType t) : this(t, null) { }
		public FmlRound(BaseValueType t, FmlNode v, int digit = 0, MidpointRounding mode = MidpointRounding.AwayFromZero)
			: base(t, 1) {
			Value = v;
			Digit = digit;
			Mode = mode;
		}

		public FmlNode Value {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public int Digit { get; set; }

		public MidpointRounding Mode { get; set; }

		public override string CalculateString() {
			return CalString("Round");
		}

		protected sealed override void Calculate() {
			_SetDouble(Math.Round(Value.GetDouble(), Digit, Mode));
		}
	}
}
