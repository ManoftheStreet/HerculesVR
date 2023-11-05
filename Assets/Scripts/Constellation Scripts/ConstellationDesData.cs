public class ConstellationDesData : CsvData
{
    public string Summary { get; set; }
    public string Description { get; set; }

    public override void SetData(string[] data)
    {
        Summary = data[1];
        Description = data[2];
    }
}
