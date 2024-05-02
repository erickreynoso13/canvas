using Library.LearningManagement.models;
using Library.LearningManagement.Services;
using MAUI.LearningManagement.ViewModels;
namespace MAUI.LearningManagement.Views;


public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
		InitializeComponent();
		BindingContext = new PersonDetailViewModel();
	}


private void OkClicked(Object sender, EventArgs e)
{
	var context = BindingContext as PersonDetailViewModel;
	PersonClassification classification;
	switch(context.ClassificationString)
	{
		case "S":
		classification = PersonClassification.Senior;
		break;
		case "J":
		classification = PersonClassification.Junior;
		break;
		case "O":
		classification = PersonClassification.Sophmore;
		break;
		case "F":
		default:
		classification = PersonClassification.Freshman;
		break;
	}
	StudentService.Current.Add(new Person {Name = context.Name,Classification = classification});
	Shell.Current.GoToAsync("//Mainpage");

}
}