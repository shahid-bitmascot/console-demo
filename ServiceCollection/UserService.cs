namespace ServiceCollectionDemo
{
    public class UserService : IUserService
    {

        public string Post { get; set; }
        public string Comment { get; set; }

        public UserService(IPostService postService)
        {
            Post = postService.Content;
            Comment = postService.Comment;
        }
    }

    public interface IUserService
    {
        string Post { get; set; }
        string Comment { get; set; }
    }

}
