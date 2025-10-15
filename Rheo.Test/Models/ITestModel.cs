namespace Rheo.Test.Models
{
    internal interface ITestModel<TModel> where TModel : class
    {
        public TModel? Content { get; }
        public string? Name { get; }
        public string OriginalPath { get; }
        public string? Operation { get; set; }
        public string? DestinationPath { get; set; }

        public void Update(string operation, string newPath);
    }
}
