using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomViewDuplicationIssue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelledEntrywithIcon : ContentView
    {
        public LabelledEntrywithIcon()
        {
            InitializeComponent();
            Content.BindingContext = this;
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(propertyName: nameof(Title),
                                                                                       returnType: typeof(string),
                                                                                       declaringType: typeof(LabelledEntrywithIcon),
                                                                                       defaultValue: default(string));

        private Label detailLabel = new Label() { BindingContext = DetailProperty };
        private static Entry newEntry = new Entry();
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }

            set
            {
                SetValue(TitleProperty, value);
            }
        }


        public static readonly BindableProperty DetailProperty = BindableProperty.Create(propertyName: nameof(Detail),
                                                                                            returnType: typeof(string),
                                                                                            declaringType: typeof(LabelledEntrywithIcon),
                                                                                            defaultValue: default(string));


        public string Detail
        {
            get
            {
                return (string)GetValue(DetailProperty);

            }
            set => SetValue(DetailProperty, value);
        }


        public LabelledEntrywithIcon(string name, string text)
        {
            Title = name;
            Detail = text;
        }

        private void EditIcon_Clicked(object sender, System.EventArgs e)
        {
            detailLabel = (Label)stackLayoutDetail.Children[1];
            stackLayoutDetail.Children.RemoveAt(1);
            newEntry.Text = Detail;
            stackLayoutDetail.Children.Add(newEntry);
            editIcon.IsVisible = false;
            newEntry.Completed += NewEntry_Completed;

        }


        private void NewEntry_Completed(object sender, System.EventArgs e)
        {
            try
            {
                var _newText = newEntry.Text;
                detailLabel.Text = _newText;
                stackLayoutDetail.Children.RemoveAt(1);
                stackLayoutDetail.Children.Add(detailLabel);
                Detail = _newText;
                editIcon.IsVisible = true;
            }
            catch (System.Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }

        public static readonly BindableProperty EditIconVisibleProperty = BindableProperty.Create(propertyName: nameof(EditIconVisible),
                                                                                           returnType: typeof(bool),
                                                                                           declaringType: typeof(LabelledEntrywithIcon),
                                                                                           defaultValue: true);


        public bool EditIconVisible
        {
            get
            {
                return (bool)GetValue(EditIconVisibleProperty);

            }
            set => SetValue(EditIconVisibleProperty, value);
        }

    }
}
