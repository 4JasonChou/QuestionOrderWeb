using Microsoft.AspNetCore.Mvc.Rendering;
using DotnetCoreMVC.Models;
namespace DotnetCoreMVC.LogicHandler;

public class UserRuleHandler 
{
    private List<SelectListItem> GetFinalList( List<DropDownArrayV2> totalList , int userRule , string defaultValue=null)
    {
        var finalRoleList = totalList.Where( x => x.UserRole.Exists(r=>r == userRule)  ).ToList();
        List<SelectListItem> items = new List<SelectListItem>();
        foreach (var str in finalRoleList)
        {
            SelectListItem li = new SelectListItem();
            li.Text = str.DropDownText;
            li.Value = str.DropDownValue;

            if( li.Value == defaultValue )
                li.Selected = true;
            else
                li.Selected = false;

            items.Add(li);
        }
        return items;

    }
    public List<SelectListItem> GetTypeList(int userRule, string defaultValue=null)
    {
        List<DropDownArrayV2> RoleList = new List<DropDownArrayV2>();
		RoleList.Add(new DropDownArrayV2(){ UserRole=new List<int>(){1,4},DropDownText="BUG",DropDownValue=((int)EnumDictSet.OrderTpye.Bug).ToString()});
		RoleList.Add(new DropDownArrayV2(){ UserRole=new List<int>(){1,4},DropDownText="TEST",DropDownValue=((int)EnumDictSet.OrderTpye.Test).ToString()});
        RoleList.Add(new DropDownArrayV2(){ UserRole=new List<int>(){3,4},DropDownText="FUNCTION",DropDownValue=((int)EnumDictSet.OrderTpye.Function).ToString()});
        return GetFinalList(RoleList,userRule,defaultValue) ;
    }

    public List<SelectListItem> GetLevelList(int userRule, string defaultValue=null)
    {
        List<DropDownArrayV2> RoleList = new List<DropDownArrayV2>();
        RoleList.Add(new DropDownArrayV2(){ UserRole=new List<int>(){3,4},DropDownText="Normal",DropDownValue="Normal"});
		RoleList.Add(new DropDownArrayV2(){ UserRole=new List<int>(){1,4},DropDownText="Warning",DropDownValue="Warning"});
		RoleList.Add(new DropDownArrayV2(){ UserRole=new List<int>(){1,4},DropDownText="Error",DropDownValue="Error"});
        RoleList.Add(new DropDownArrayV2(){ UserRole=new List<int>(){1,4},DropDownText="Fatal",DropDownValue="Fatal"});
        return GetFinalList(RoleList,userRule,defaultValue) ;
    }

    public List<SelectListItem> GetPrioList(string defaultValue=null)
    {
        List<SelectListItem> items = new List<SelectListItem>();
        items.Add( new SelectListItem(){ Text = "1" , Value = "1", Selected = true } );
        items.Add( new SelectListItem(){ Text = "2" , Value = "2", Selected = false } );
        items.Add( new SelectListItem(){ Text = "3" , Value = "3", Selected = false } );
        return items;
    }

    public List<SelectListItem> GetStatusList(int userRule, string defaultValue=null)
    {
        List<DropDownArrayV2> RoleList = new List<DropDownArrayV2>();
        RoleList.Add(new DropDownArrayV2(){ UserRole=new List<int>(){1,2,3,4},DropDownText="New",DropDownValue=((int)EnumDictSet.FlowStatus.New).ToString()});
        RoleList.Add(new DropDownArrayV2(){ UserRole=new List<int>(){2,4},DropDownText="Solve",DropDownValue=((int)EnumDictSet.FlowStatus.Solve).ToString()});
		RoleList.Add(new DropDownArrayV2(){ UserRole=new List<int>(){1,4},DropDownText="Finish",DropDownValue=((int)EnumDictSet.FlowStatus.Finish).ToString()});
        
        
        return GetFinalList(RoleList,userRule,defaultValue) ;
    }


}
public class DropDownArrayV2
{
        public List<int> UserRole {get;set;}
		public string DropDownText { get; set; }
		public string DropDownValue { get; set; }
}