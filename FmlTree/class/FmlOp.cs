using System.Collections.Generic;

namespace github.com.lawwong.FmlTreeCSharp {
	public abstract class FmlOp : FmlNode {
		protected List<FmlNode> ChildList;

		protected FmlOp(BaseValueType t, int childListCap)
			: base(t) {
			ChildList = new List<FmlNode>(childListCap);
			ChildCount = 0;
		}

		public int ChildCount { get; protected set; }

		public sealed override bool FindInDescendant(FmlNode l) {
			for (int i = 0, imax = ChildList.Count; i < imax; ++i) {
				if (ChildList[i] == null) { continue; }
				if (ChildList[i] == l) { return true; }
				if (ChildList[i].FindInDescendant(l)) { return true; }
			}
			return false;
		}

		public sealed override bool FindRecursive() {
			if (FindInDescendant(this)) { return true; }
			for (int i = 0, imax = ChildList.Count; i < imax; ++i) {
				if (ChildList[i] == null) { continue; }
				if (ChildList[i].FindRecursive()) { return true; }
			}
			return false;
		}

		public sealed override int GetInt32() {
			Update();
			return base.GetInt32();
		}

		public sealed override long GetInt64() {
			Update();
			return base.GetInt64();
		}

		public sealed override float GetSingle() {
			Update();
			return base.GetSingle();
		}

		public sealed override double GetDouble() {
			Update();
			return base.GetDouble();
		}

		public void Update() {
			if (!IsDirty) { return; }
			SetClean();
			Calculate();
		}

		protected IEnumerable<FmlNode> Children {
			get {
				for (int i = 0, imax = ChildList.Count; i < imax; ++i) {
					if (ChildList[i] == null) { continue; }
					yield return ChildList[i];
				}
			}
		}

		protected abstract void Calculate();

		protected string CalString(string opName, string saperator = ", ") {
			string str = "";
			int i = 0;
			foreach (FmlNode l in Children) {
				++i;
				str += l.CalculateString();
				if (i != ChildCount) {
					str += saperator;
				}
			}
			return opName + "[" + this.ToString() + "](" + str + ")";
		}
	}
}
