using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace XFSOAnswers
{
	[StructLayout(LayoutKind.Explicit)]
	internal struct UnionStruct
	{
		[FieldOffset(0)] public float bar;
		[FieldOffset(8)] public int killroy;
		[FieldOffset(8)] public float fubar;
		[FieldOffset(8)] public MyTuple tuple;


		public static void Test1()
		{
			var u = new UnionStruct();

			var mt = new MyTuple("a", "abcabc");
			u.tuple = mt;

			u.killroy = 1234567;
			string s = u.fubar.ToString();
			Debug.WriteLine($"{s}");

			var verify1 = u.tuple;
			Debug.WriteLine($"{u.tuple}");

		}
	}
}
