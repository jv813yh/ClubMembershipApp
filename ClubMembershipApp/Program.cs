using ClubMembershipApp.View;

namespace ClubMembershipApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IView mainView = Factory.GetMainViewObject();
            mainView.RunView();


        }
    }
}
