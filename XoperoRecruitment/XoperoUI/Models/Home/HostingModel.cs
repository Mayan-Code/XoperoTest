namespace XoperoUI.Models.Home
{
    public class HostingModel
    {
        public string HostingName { get; set; }
        public BaseModel BaseModel { get; set; } = new BaseModel();
        public List<XoperoCore.HostingService.Common.IssueModel> Issues { get; set; }
    }
}
