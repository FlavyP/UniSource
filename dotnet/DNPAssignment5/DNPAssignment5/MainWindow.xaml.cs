using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace DNPAssignment5
{
    public partial class MainWindow : Window
    {
        public Multimedia MultiM { get; set; }

        private ObservableCollection<Multimedia> multimediaList = new ObservableCollection<Multimedia>();

        public MainWindow()
        {
            InitializeComponent();
            MultiM = new Multimedia ();
            DataContext = MultiM;
            MultimediaListBox.DataContext = multimediaList;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TitleBox.Text) || string.IsNullOrWhiteSpace(ArtistBox.Text) || string.IsNullOrWhiteSpace(GenreBox.Text)) {
                MessageBox.Show("Title, Artist and Genre need to be filled in");
            }
            else { 
                Multimedia.MediaType enumValue = (Multimedia.MediaType)Enum.Parse(typeof(Multimedia.MediaType), ComboBox.Text);
                multimediaList.Add(new Multimedia() { Title = TitleBox.Text, Artist = ArtistBox.Text, Genre = GenreBox.Text, Type = enumValue });
                ClearFields();
            }
        }

        private void MultimediaListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            mediaItems.Items.Clear();
            if (MultimediaListBox.SelectedItem != null)
                mediaItems.Items.Add(MultimediaListBox.SelectedItem);
        }

        private void ClearFields()
        {
            TitleBox.Clear();
            ArtistBox.Clear();
            GenreBox.Clear();
            FullMultimediaInfo.Clear();
            MultiM = new Multimedia();
            DataContext = MultiM;
            ComboBox.SelectedIndex = 0;
        }
    }
}
