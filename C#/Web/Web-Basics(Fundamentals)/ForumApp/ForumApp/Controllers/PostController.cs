namespace ForumApp.Controllers
{
    using ForumApp.Data;
    using ForumApp.Data.Models;
    using ForumApp.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class PostController : Controller
    {
        private readonly ForumDbContext data;

        public PostController(ForumDbContext data)
        {
            this.data = data;
        }

        [HttpGet]
        public IActionResult Index() => RedirectToAction(nameof(All));

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var posts = await this.data.Posts
                .Where(p => p.IsDeleted.Equals(false))
                .Select(p => new PostViewModel(p)).ToListAsync();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add Post";
            ViewBag.SubmitButton = "Create";
            return View(viewName: "AddEdit");
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel formModel)
        {
            var post = new Post(formModel);
            await this.data.Posts.AddAsync(post);
            await this.data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Post post = await this.data.Posts.FirstAsync(p => p.Id.Equals(id));
            PostFormModel model = new PostFormModel(post);

            ViewBag.Title = "Edit Post";
            ViewBag.SubmitButton = "Save changes";
            return View(viewName: "AddEdit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel formModel)
        {
            var post = await this.data.Posts.FirstAsync(p => p.Id.Equals(id));
            post.Title = formModel.Title;
            post.Content = formModel.Content;
            await this.data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Post post = await this.data.Posts.FirstAsync(p => p.Id.Equals(id));
            post.IsDeleted = true;

            await this.data.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }
    }
}
