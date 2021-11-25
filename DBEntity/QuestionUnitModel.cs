using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DotnetCoreMVC.Models;
public class QuestionUnitModel
{
    public int Id {get;set;}
    public string Type {get;set;}
    public string Prio {get;set;}
    public string Level {get;set;}
    public string Title { get; set; }
    public string Des { get; set; }
    public string Status { get; set; }
}



public class EnumDictSet
{
    private static EnumDictSet INSTANCE = null;
    static readonly object padlock = new object();
    public static EnumDictSet Instance
    {
        get
        {
            if (INSTANCE == null)
            {
                lock (padlock) //lock此區段程式碼，讓其它thread無法進入。
                {
                    if (INSTANCE == null)
                    {
                        INSTANCE = new EnumDictSet();
                    }
                }
            }
            return INSTANCE;
        }
    }

    
    private EnumDictSet()
    {
        FlowStatusDic = new Dictionary<string, string>();
        FlowStatusDic.Add(((int)FlowStatus.Finish).ToString(),"Finish");
        FlowStatusDic.Add(((int)FlowStatus.New).ToString(),"New");
        FlowStatusDic.Add(((int)FlowStatus.Solve).ToString(),"Solve");

        TypeDic = new Dictionary<string, string>();
        TypeDic.Add(((int)OrderTpye.Bug).ToString(),"Bug");
        TypeDic.Add(((int)OrderTpye.Function).ToString(),"Function");
        TypeDic.Add(((int)OrderTpye.Test).ToString(),"Test");
    }

    public Dictionary<string, string> FlowStatusDic  { get;set;}
    public Dictionary<string, string> TypeDic{ get;set;}
    
    public enum FlowStatus
    {
        Finish = 0,
        New,
        Solve,
    }

    public enum OrderTpye
    {
        Bug = 0,
        Function,
        Test,
    }

}