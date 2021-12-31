//using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFSOAnswers
{
	//[AddINotifyPropertyChangedInterface]
	public class UserViewModel : BindableObject
	{
		private bool _isLastnameValid;
		private bool _isFirstnameValid;
		private string lastname;
		private string firstname;

		public UserViewModel(bool isLastnameValid, bool isFirstnameValid)
		{
			IsLastnameValid = isLastnameValid;
			IsFirstnameValid = isFirstnameValid;
		}

		public string Lastname {
			get => lastname;
			set {
				lastname = value;
				OnPropertyChanged();
			}
		}
		public string Firstname {
			get => firstname;
			set {
				firstname = value;
				OnPropertyChanged();
			}
		}
		public bool IsLastnameValid {
			get => _isLastnameValid;
			set {
				_isLastnameValid = value;
				OnPropertyChanged();
			}
		}
		public bool IsFirstnameValid {
			get => _isFirstnameValid;
			set {
				_isFirstnameValid = value;
				OnPropertyChanged();
			}
		}
	}
}
