using System.Windows;
using System.Windows.Controls;

namespace DXApplication2.UserControls
{
	public partial class MyComboBox : UserControl
	{
		public MyComboBox()
		{
			InitializeComponent();
		}

		public string Caption
		{
			get { return (string)GetValue(CaptionProperty); }
			set { SetValue(CaptionProperty, value); }
		}

		public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(MyComboBox));
	}
}