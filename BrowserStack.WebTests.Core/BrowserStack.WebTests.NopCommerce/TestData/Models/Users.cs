using System.Collections.Generic;
using System.Linq;

namespace BrowserStack.WebTests.NopCommerce.TestData.Models
{
    public class Users : List<UserTestModel>
    {
        public UserTestModel HelpDeskUser
        {
            get { return this.FirstOrDefault(p => p.Key == "HelpDeskUser"); }
        }
        public UserTestModel WindowsAdmin
        {
            get { return this.FirstOrDefault(p => p.Key == "WindowsAdmin"); }
        }

        public UserTestModel AzureADAdmin
        {
            get { return this.FirstOrDefault(p => p.Key == UserTestModel.AzureADAdmin); }
        }
        public UserTestModel PMQAAzureADUser
        {
            get { return this.FirstOrDefault(p => p.Key == UserTestModel.PMQAAzureADUser); }
        }
        public UserTestModel ADPMQAAdmin
        {
            get { return this.FirstOrDefault(p => p.Key == UserTestModel.ADPMQAAdmin); }
        }

        public UserTestModel MacOsAdmin
        {
            get { return this.FirstOrDefault(p => p.Key == "MacOsAdmin"); }
        }

        public UserTestModel User
        {
            get { return this.FirstOrDefault(p => p.Key == "User"); }
        }
        public UserTestModel TOTPUser
        {
            get { return this.FirstOrDefault(p => p.Key == "TOTPUser"); }
        }
        public UserTestModel TOTPAdminUser
        {
            get { return this.FirstOrDefault(p => p.Key == "TOTPAdminUser"); }
        }

        public UserTestModel TOTHelpDeskUser
        {
            get { return this.FirstOrDefault(p => p.Key == UserTestModel.TOTHelpDeskUser); }
        }

        public UserTestModel TOTWindowsAdmin
        {
            get { return this.FirstOrDefault(p => p.Key == UserTestModel.TOTWindowsAdmin); }
        }
        public UserTestModel RandomUser
        {
            get { return this.FirstOrDefault(p => p.Key == UserTestModel.RandomUser); }

        }

        public UserTestModel SSVaultUser
        {
            get { return this.FirstOrDefault(p => p.Key == UserTestModel.SSVaultUser); }

        }

        public UserTestModel StandardAdmin
        {
            get { return this.FirstOrDefault(p => p.Key == UserTestModel.StandardAdmin); }

        }
        public UserTestModel StandardHelpDeskUser
        {
            get { return this.FirstOrDefault(p => p.Key == UserTestModel.StandardHelpDeskUser); }

        }
        public UserTestModel StandardMacOsAdmin
        {
            get { return this.FirstOrDefault(p => p.Key == UserTestModel.StandardMacOsAdmin); }

        }

        public UserTestModel StandardUser
        {
            get { return this.FirstOrDefault(p => p.Key == UserTestModel.StandardUser); }

        }

        public UserTestModel StandardWindowsAdmin
        {
            get { return this.FirstOrDefault(p => p.Key == UserTestModel.StandardWindowsAdmin); }

        }

        public UserTestModel SSUserForRC
        {
            get { return this.FirstOrDefault(p => p.Key == UserTestModel.SSUserForRC); }

        }

        public void SetRandomUser(UserTestModel Test)
        {
            if (this.Any(p => p.Key == UserTestModel.RandomUser && p.UserName == Test.UserName))
            { return; }
            var A = this.FirstOrDefault(p => p.Key == UserTestModel.RandomUser);
            if (A != null)
            {

                A.UserName = Test.UserName;
                A.Password = Test.Password;
            }
        }


    }
}
