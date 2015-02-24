using System;

namespace github.com.lawwong.FmlTreeCSharp {
	public abstract class FmlArityOp : FmlOp {
		// arity 必須大於 0
		protected FmlArityOp(BaseValueType t, int arity)
			: base(t, arity) {
			// initial _childList
			for (int i = 0, imax = arity; i < imax; ++i) { ChildList.Add(null); }
			ChildCount = arity;
		}

		public int Arity { get { return ChildCount; } }

		protected FmlNode this[int index] {
			get {
				return ChildList[index];
			}
			set {
				if (index < 0 || index >= ChildList.Count) { throw new Exception("index out of range"); }
				if (ChildList[index] == value) { return; }
				if (ChildList[index] != null) { ChildList[index].RemoveBranch(this); }
				if (value != null) { value.AddBranch(this); }
				ChildList[index] = value;
				SetDirty();
			}
		}
	}
}
