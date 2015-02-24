using System.Globalization;

namespace FmlTreeCSharp {
	public class FmlArg : FmlNode {
		public FmlArg(BaseValueType t) : base(t) { }
		public FmlArg(int val) : base(BaseValueType.Int32) { SetInt32(val); }
		public FmlArg(long val) : base(BaseValueType.Int64) { SetInt64(val); }
		public FmlArg(float val) : base(BaseValueType.Single) { SetSingle(val); }
		public FmlArg(double val) : base(BaseValueType.Double) { SetDouble(val); }

		public sealed override int GetInt32() {
			SetClean();
			return base.GetInt32();
		}

		public sealed override long GetInt64() {
			SetClean();
			return base.GetInt64();
		}

		public sealed override float GetSingle() {
			SetClean();
			return base.GetSingle();
		}

		public sealed override double GetDouble() {
			SetClean();
			return base.GetDouble();
		}

		public void SetInt32(int val) {
			if (val == GetInt32()) { return; }
			base._SetInt32(val);
			SetDirty();
		}

		public void SetInt64(long val) {
			if (val == GetInt64()) { return; }
			base._SetInt64(val);
			SetDirty();
		}

		public void SetSingle(float val) {
			if (val == GetSingle()) { return; }
			base._SetSingle(val);
			SetDirty();
		}

		public void SetDouble(double val) {
			if (val == GetDouble()) { return; }
			base._SetDouble(val);
			SetDirty();
		}
	}
}
