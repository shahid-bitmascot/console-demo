namespace ServiceCollectionDemo
{
    public class PostService : IPostService
    {
        public string Content { get; set; }
        public string Comment { get; set; }
        public PostService(ICommentService commentService)
        {
            Content = "Post 1";
            Comment = commentService.Content;
        }
    }

    public interface IPostService
    {
        string Content { get; set; }
        string Comment { get; set; }
    }

}
