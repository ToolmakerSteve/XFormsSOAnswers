using System;
using System.Collections.Generic;
using System.Text;

namespace XFSOAnswers
{
	public class MyTuple : Tuple<string, string>
	{
		public MyTuple(string item1, string item2) : base(item1, item2)
		{
		}
	}
}
