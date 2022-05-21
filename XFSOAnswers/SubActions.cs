using System;
using System.Collections.Generic;
using System.Text;

namespace XFSOAnswers
{
	public class BaseSubAction
	{
		// This gets sets by code not shown.
		protected Data _Data;

	}

	public class SubAction : BaseSubAction
	{
		public Action DoItA { get; set; }
		private Action<SubAction> _DoIt { get; set; }

		public SubAction()
		{

		}
		public SubAction(Action<SubAction> doIt)
		{
			_DoIt = doIt;
		}

		public void DoIt()
		{
			_DoIt(this);
		}


		static public Action<SubAction> GetAction1 => (it) => it.DoSomething(it._Data.Value1);
		static public Action<SubAction> GetAction2 => (it) => it.DoSomething(it._Data.Value2);

		public Action GetActionA1 => () => DoSomething(_Data.Value1);


		protected void DoSomething(string value)
		{
			// ...
		}
	}


	public class Data
	{
		public string Value1;
		public string Value2;
	}


	public class SubActionTests
	{
		static SubActionTests()
		{
			var actions = new List<SubAction>
			{
				new SubAction(SubAction.GetAction1),
				new SubAction(SubAction.GetAction2),
			};

			var it = new SubAction();
			it.DoItA = it.GetActionA1;
			it.DoItA = () => SubAction.GetAction1(it);

			foreach (var subAction in actions)
			{
				subAction.DoIt();
			}
		}
	}
}
