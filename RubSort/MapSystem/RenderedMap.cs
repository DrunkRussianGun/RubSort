namespace RubSort.MapSystem
{
    public class RenderedMap
    {
        public string HtmlScript { get; set; }

        public RenderedMap(string html)
        {
            HtmlScript = html;
        }
    }
}