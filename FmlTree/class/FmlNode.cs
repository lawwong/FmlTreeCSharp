using System;
using System.Collections.Generic;
using System.Globalization;

namespace FmlTreeCSharp {
	public abstract class FmlNode {
		private static string _numberDecimalSeparator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
		private UnionValue Val;

		internal Dictionary<FmlOp, int> Branches = new Dictionary<FmlOp, int>(1);

		protected FmlNode(BaseValueType type) {
			IsDirty = true;
			BaseType = type;
		}

		public bool IsDirty { get; internal set; }

		public BaseValueType BaseType { get; private set; }

		public virtual int GetInt32() { return Val.GetInt32(BaseType); }

		public virtual long GetInt64() { return Val.GetInt64(BaseType); }

		public virtual float GetSingle() { return Val.GetSingle(BaseType); }

		public virtual double GetDouble() { return Val.GetDouble(BaseType); }

		public bool FindInAncestors(FmlOp b) {
			if (b == null) { return false; }
			if (Branches.Count == 0) { return false; }
			if (Branches.ContainsKey(b)) { return true; }
			foreach (FmlOp parent in Branches.Keys) {
				if (FindInAncestors(b)) { return true; }
			}
			return false;
		}

		public virtual bool FindInDescendant(FmlNode l) {
			return false;
		}

		public virtual bool FindRecursive() {
			return false;
		}

		public virtual string CalculateString() {
			return this.ToString();
		}

		public override string ToString() {
			string str;
			switch (BaseType) {
				case BaseValueType.Int32:
				return Val.GetInt32(BaseType).ToString();
				case BaseValueType.Int64:
				return Val.GetInt64(BaseType).ToString() + "L";
				case BaseValueType.Single:
				str = Val.GetSingle(BaseType).ToString();
				if (!str.Contains(_numberDecimalSeparator)) {
					str += ".0";
				}
				return str + "F";
				case BaseValueType.Double:
				str = Val.GetDouble(BaseType).ToString();
				if (!str.Contains(_numberDecimalSeparator)) {
					str += ".0";
				}
				return str;
				default:
				return "NaN";
			}
		}

		protected void _SetInt32(int val) { Val = new UnionValue(BaseType, val); }

		protected void _SetInt64(long val) { Val = new UnionValue(BaseType, val); }

		protected void _SetSingle(float val) { Val = new UnionValue(BaseType, val); }

		protected void _SetDouble(double val) { Val = new UnionValue(BaseType, val); }

		protected void SetDirty() {
			if (IsDirty) { return; }
			IsDirty = true;
			foreach (FmlOp b in Branches.Keys) { b.SetDirty(); }
		}

		protected void SetClean() { IsDirty = false; }

		internal void AddBranch(FmlOp b, int count = 1) {
			if (b == null) { throw new Exception("b is null"); }
			if (count < 1) { throw new Exception("count is less than 1"); }
			if (Branches.ContainsKey(b)) {
				Branches[b] += count;
			} else {
				Branches.Add(b, count);
			}
		}

		internal bool RemoveBranch(FmlOp b, int count = 1) {
			if (!Branches.ContainsKey(b)) { return false; }
			if ((Branches[b] -= count) <= 0) { Branches.Remove(b); }
			return true;
		}
	}
}
