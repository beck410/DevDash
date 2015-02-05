using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace DevDash {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
      Check_Current_Project_List_State(true);
      Check_Past_Project_List_State(true);
    }

    public void Current_Projects_Button_Click(object sender, RoutedEventArgs e) {

    }

    public void Past_Projects_Button_Click(object sender, RoutedEventArgs e) {

    }

    public void Main_New_Project_Button_Click(object sender, RoutedEventArgs e) {
      // TODO: open new window
      Main_New_Project_Button.IsEnabled = false;
    }

    public void Check_Current_Project_List_State(bool projectsExist) {
      Current_Projects_Button.IsEnabled = projectsExist;
    }

    public void Check_Past_Project_List_State(bool projectsExist) {
      Past_Projects_Button.IsEnabled = projectsExist;
    }
  }
}
