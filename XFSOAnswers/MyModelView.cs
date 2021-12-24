using System.Collections.ObjectModel;

namespace XFSOAnswers
{
    public class MyModelView
    {
        public ObservableCollection<MyItem> Items { get; set; }

        public MyModelView()
        {
            Items.Add(new MyItem());
            Items.Add(new MyItem());
            Items.Add(new MyItem());

            // Hide line on last item.
            Items[Items.Count - 1].ShowLineUnder = false;
        }
    }
}
