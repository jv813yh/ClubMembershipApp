using ClubMembershipApp.FieldValidators;

namespace ClubMembershipApp.View
{
    public interface IView
    {
        void RunView();
        IFieldValidator FieldValidator { get; }
    }
}
