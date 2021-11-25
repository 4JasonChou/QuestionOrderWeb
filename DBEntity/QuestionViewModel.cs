
namespace DotnetCoreMVC.Models;
public class QuestionViewModel
{
    public QuestionViewModel(QuestionUnitModel converModel)
    {
        Id = converModel.Id;
        Type = EnumDictSet.Instance.TypeDic[converModel.Type];
        Prio = converModel.Prio;
        Level = converModel.Level;
        Title = converModel.Title;
        Des = converModel.Des;
        Status = EnumDictSet.Instance.FlowStatusDic[converModel.Status];
    }
    public int Id {get;set;}
    public string Type {get;set;}
    public string Prio {get;set;}
    public string Level {get;set;}
    public string Title { get; set; }
    public string Des { get; set; }
    public string Status { get; set; }
}