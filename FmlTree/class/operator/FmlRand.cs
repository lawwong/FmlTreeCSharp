using System;

namespace github.com.lawwong.FmlTreeCSharp {
	public class FmlRand : FmlArityOp {
		private Random _rand;

		public FmlRand(BaseValueType t, int seed) : this(t, seed, null, null) { }
		// difference = minuend - subtrahend
		public FmlRand(BaseValueType t, int seed, FmlNode minValue, FmlNode maxValue, bool manualRand = false)
			: base(t, 2) {
			_rand = new Random(seed);
			Seed = seed;
			MinValue = minValue;
			MaxValue = maxValue;
			ManualRand = manualRand;
		}

		public int Seed { get; private set; }

		public FmlNode MinValue {
			get { return this[0]; }
			set { this[0] = value; }
		}

		public FmlNode MaxValue {
			get { return this[1]; }
			set { this[1] = value; }
		}

		// set true to rand new number in every Get call,
		// set false to disable it. (call Next() to rand new number on next Get call)
		public bool ManualRand { get; set; }

		public void Next() { SetDirty(); }

		public override string CalculateString() {
			return CalString("Rand");
		}

		protected sealed override void Calculate() {
			switch (BaseType) {
				case BaseValueType.Int64:
				case BaseValueType.Single:
				case BaseValueType.Double: {
					double offset = MinValue.GetDouble();
					double diff = MaxValue.GetDouble() - offset;
					_SetDouble(offset + (diff * _rand.NextDouble()));
					break;
				}
				//case BaseValueType.Int64: {
				//	byte[] b = new byte[sizeof(long)];
				//	_rand.NextBytes(b);
				//	_SetInt64(BitConverter.ToInt64(b, 0));
				//	break;
				//}
				case BaseValueType.Int32:
				default: {
					_SetInt32(_rand.Next(MinValue.GetInt32(), MaxValue.GetInt32()));
					break;
				}
			}
			if (!ManualRand) { SetDirty(); }
		}
	}
}
