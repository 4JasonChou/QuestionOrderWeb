using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DotnetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using DotnetCoreMVC.LogicHandler;

namespace DotnetCoreMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

   
    static UserRuleHandler UserRules = new UserRuleHandler();
    static IList<QuestionUnitModel> QuestionList = new List<QuestionUnitModel>();

    static UserModel loginInfo ;
    public IActionResult Index(IndexViewModel userInfo)
    {
        if(userInfo.LoginInfo == null && loginInfo == null)
            return View();
        else        
        {
            // 進行登入確認
            if(  loginInfo == null )
                loginInfo = CheckUser(userInfo.LoginInfo.Acc,userInfo.LoginInfo.Pwd);
            
            // 登入結果確認
            if(  loginInfo == null )
                return View();


            IList<QuestionViewModel> viewQL = new List<QuestionViewModel>();
            foreach (var tmp in QuestionList)
            {
                viewQL.Add( new QuestionViewModel(tmp) );
            }
            ViewData["questions"] = viewQL;
            return View( new IndexViewModel(){ EventInfo = "", AuthKey = "Auth" , LoginInfo = loginInfo });
        }
    }

    public UserModel CheckUser(string acc , string pwd)
    {
        QuestionList.Add( new QuestionUnitModel(){ Id = 0, Type = "0", Prio = "3", Level = "Warning", Title="001", Des="D001",Status="1"} );
        return UserDataSet.Instance.GetUserInfo(acc,pwd);
    }

    public IActionResult Logout()
    {
        loginInfo = null;
        return RedirectToAction("Index");
    }


    public IActionResult Question(int? id)
    {   
        ViewBag.TypeItem = UserRules.GetTypeList(loginInfo.AuthNumebr);
        ViewBag.LevelItem = UserRules.GetLevelList(loginInfo.AuthNumebr);
        ViewBag.PrioItem = UserRules.GetPrioList();
        ViewBag.RoleItem = UserRules.GetStatusList(loginInfo.AuthNumebr);
        return View();
    }

    public IActionResult EditQuestion(int? id)
    {   
        if( id != null )
        {
            var questionData = QuestionList.Where(x => x.Id == id).FirstOrDefault();        
            ViewBag.TypeItem = UserRules.GetTypeList(loginInfo.AuthNumebr , questionData.Type);
            ViewBag.LevelItem = UserRules.GetLevelList(loginInfo.AuthNumebr,questionData.Level);
            ViewBag.PrioItem = UserRules.GetPrioList();
            ViewBag.RoleItem = UserRules.GetStatusList(loginInfo.AuthNumebr,questionData.Status);

            var viewInfo = new EditQuestionViewModel(){ QuestionInfo =questionData , LoginInfo =  loginInfo};
            return View(viewInfo);
        }
        return View();
    }

    public IActionResult InsertOrUpdate( QuestionUnitModel submitQ )
    {
        QuestionList.Add( new QuestionUnitModel(){ Id = QuestionList.Count + 1 , Type = submitQ.Type , Prio = submitQ.Prio , Level = submitQ.Level , Title = submitQ.Title , Des = submitQ.Des , Status = submitQ.Status } );
        return RedirectToAction("Index");
    }

    public IActionResult Update( EditQuestionViewModel submitQ )
    {
        var questionData = QuestionList.Where(x => x.Id == submitQ.QuestionInfo.Id ).FirstOrDefault(); 
        questionData.Type = submitQ.QuestionInfo.Type;
        questionData.Prio = submitQ.QuestionInfo.Prio;
        questionData.Level = submitQ.QuestionInfo.Level;
        questionData.Title = submitQ.QuestionInfo.Title;
        questionData.Des = submitQ.QuestionInfo.Des;
        questionData.Status = submitQ.QuestionInfo.Status;

        return RedirectToAction("Index");
    }

    public IActionResult DeleteQuestion(int id)
    {
        var itemToRemove = QuestionList.FirstOrDefault(r => r.Id == id);
        if (itemToRemove != null)
            QuestionList.Remove(itemToRemove);
        
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    
}

