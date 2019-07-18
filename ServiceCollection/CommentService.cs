namespace ServiceCollectionDemo
{
    public class CommentService : ICommentService
    {
        public string Content { get; set; }

        public CommentService()
        {
            Content = "Comment 1";
        }
    }

    public interface ICommentService
    {
        string Content { get; set; }
    }

}
