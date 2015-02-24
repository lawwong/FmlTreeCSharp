using System.Collections.Generic;

namespace FmlTreeCSharp {
	public abstract class FmlVariableOp : FmlOp {
		protected FmlVariableOp(BaseValueType t)
			: base(t, 20) {
		}

		public void AddChild(FmlNode l) {
			if (l == null) { return; }
			if (ChildList.Count > ChildCount) {
				for (int i = 0, imax = ChildList.Count; i < imax; ++i) {
					if (ChildList[i] == null) {
						ChildList[i] = l;
						break;
					}
				}
			} else {
				ChildList.Add(l);
			}
			l.AddBranch(this);
			++ChildCount;
			SetDirty();
		}

		// equivalent to ReplaceChild(l, null)
		public bool RemoveChild(FmlNode l) {
			return ReplaceChild(l, null);
		}

		// equivalent to ReplaceAllChild(l, null)
		public int RemoveAllChild(FmlNode l) {
			return ReplaceAllChild(l, null);
		}

		public bool ReplaceChild(FmlNode from, FmlNode to) {
			if (from == to) { return false; }

			for (int i = 0, imax = ChildList.Count; i < imax; ++i) {
				if (ChildList[i] == from) {
					ChildList[i] = to;

					if (from == null) {
						to.AddBranch(this);
						++ChildCount;
					} else if( to == null) {
						from.RemoveBranch(this);
						--ChildCount;
						RemoveNullTail();
					} else {
						to.AddBranch(this);
						from.RemoveBranch(this);
					}

					SetDirty();
					return true;
				}
			}
			return false;
		}

		public int ReplaceAllChild(FmlNode from, FmlNode to) {
			if (from == to) { return 0; }
			int count = 0;

			for (int i = 0, imax = ChildList.Count; i < imax; ++i) {
				if (ChildList[i] == from) {
					ChildList[i] = to;
					++count;
				}
			}

			if (count > 0) {
				if (from == null) {
					to.AddBranch(this, count);
					ChildCount += count;
				} else if (to == null) {
					from.RemoveBranch(this, count);
					ChildCount -= count;
					RemoveNullTail();
				} else {
					to.AddBranch(this, count);
					from.RemoveBranch(this, count);
				}
				SetDirty();
			}

			return count;
		}

		public int TrimNullChild() {
			if (ChildCount == ChildList.Count) { return 0; }
			List<FmlNode> newList = new List<FmlNode>(ChildList.Capacity);
			int imax = ChildList.Count;
			for (int i = 0; i < imax; ++i) {
				if (ChildList[i] != null) {
					newList.Add(ChildList[i]);
				}
			}
			ChildList = newList;
			return imax - ChildList.Count;
		}

		public void ClearChild() {
			if (ChildCount == 0) { return; }

			foreach (FmlNode child in Children) {
				child.RemoveBranch(this);
			}

			ChildList.Clear();
			ChildCount = 0;
			SetDirty();
		}

		// 刪掉結尾的 null
		private int RemoveNullTail() {
			int count = 0;
			for (int i = ChildList.Count - 1; i >= 0 && ChildList[i] == null; --i) {
				ChildList.RemoveAt(i);
				++count;
			}
			return count;
		}
	}
}
