using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Mosh_CSharp_intermediate
{
    public class Sec2_Ex2
    {
        private static List<Post> posts = new List<Post>();

        public static void Start()
        {
            Console.WriteLine("First, enter your nickname: ");
            string nickname = Console.ReadLine() ?? "NewUser1234";

            string input = "";
            while (input != "10")
            {
                Console.WriteLine("StackOverflow Simulator Menu:" +
                            "\n1. See posts" +
                            "\n2. Open post from ID" +
                            "\n3. Create new post" +
                            "\n..." +
                            "\n10. Quit"
                );

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        PrintAllPostsSimpleFormat();
                        break;

                    case "2":
                        HandlePostReadingDialog();
                        break;

                    case "3":
                        HandlePostCreationDialog(nickname);
                        break;

                    case "10":
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private static void PrintAllPostsSimpleFormat()
        {
            Console.WriteLine("All stored posts:");

            foreach (Post post in posts)
            {
                Console.WriteLine("- " + post.ReturnSimpleHeader() + " -");
            }
        }

        private static Post ReturnPostFromId(int id)
        {
            foreach (Post post in posts)
            {
                if (post.Id == id) return post;
            }

            throw new ArgumentException();
        }

        private static void HandlePostReadingDialog()
        {
            Console.WriteLine("Type the desired post ID: ");
            string id = Console.ReadLine();

            Post post = ReturnPostFromId(int.Parse(id));

            Console.WriteLine(post.ReturnContentFormatted());

            string input = "";

            while (input != "3")
            {
                Console.WriteLine("Post interaction menu:" +
                            "\n1. Upvote post" +
                            "\n2. Downvote post" +
                            "\n3. Close post"
                );

                input = Console.ReadLine();
                switch (input) 
                {
                    case "1":
                        post.UpvotePost();
                        break;

                    case "2":
                        post.DownvotePost();
                        break;

                    case "3":
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            


        }

        private static void HandlePostCreationDialog(string nickname)
        {
            Console.WriteLine("Type the desired title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Type the desired description: ");
            string description = Console.ReadLine();

            posts.Add(new Post(title, description, nickname));
        }
    }

    internal class Post
    {
        private static int postCount = 0;

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Creator { get; private set; }
        public int VoteCount { get; private set; }
        public DateTime creationTime { get; private set; }

        public Post(string title, string description, string creator)
        {
            Id = postCount++;
            Title = title;
            Description = description;
            Creator = creator;
            creationTime = DateTime.Now;
        }

        public string ReturnSimpleHeader()
        {
            return $"#{Id} - {Title}";
        }

        public string ReturnContentFormatted()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"#{Id} - {Title}")
                .AppendLine("----------")
                .AppendLine(Description)
                .AppendLine("----------")
                .AppendLine($"Creator: {Creator}\t\tUpvotes: {VoteCount}")
                .AppendLine("Creation time: " + creationTime.ToString("g"));
                

            return builder.ToString();
        }

        public void UpvotePost()
        {
            VoteCount++;
        }

        public void DownvotePost()
        {
            VoteCount--;
        }
    }
}
