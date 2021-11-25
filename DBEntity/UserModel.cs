namespace DotnetCoreMVC.Models;

public class UserModel
{
    public string Acc { get; set; }
    public string Pwd { get; set; }
    public int AuthNumebr { get; set; }
    public string UserName { get; set; }
}

public class UserDataSet
{
    private static UserDataSet INSTANCE = null;
    static readonly object padlock = new object();
    public static UserDataSet Instance
    {
        get
        {
            if (INSTANCE == null)
            {
                lock (padlock) //lock此區段程式碼，讓其它thread無法進入。
                {
                    if (INSTANCE == null)
                    {
                        INSTANCE = new UserDataSet();
                    }
                }
            }
            return INSTANCE;
        }
    }
    
    private List<UserModel> UserList { get; set; }
    private UserDataSet()
    {
        UserList = new List<UserModel>();
        UserList.Add(new UserModel(){ Acc =  "qa001", Pwd = "12345", AuthNumebr = 1, UserName = "QA" });
        UserList.Add(new UserModel(){ Acc =  "rd001", Pwd = "12345", AuthNumebr = 2, UserName = "RD" });
        UserList.Add(new UserModel(){ Acc =  "pm001", Pwd = "12345", AuthNumebr = 3, UserName = "PM" });
        UserList.Add(new UserModel(){ Acc =  "sys001", Pwd = "12345", AuthNumebr = 4, UserName = "Sys" });          
    }

    public UserModel GetUserInfo( string account , string pwd )
    {
        var user = UserList.Where(x=>x.Acc.Equals(account)).FirstOrDefault();
        if( user!= null )
        {
            if( user.Pwd == pwd)
                return user;
        }
        return null;
    }

}