using System.ComponentModel.DataAnnotations;

namespace BlogProjesi.ViewModels.Auth.Articles
{
    public class ArticlesViewModel
    {
        [Required(ErrorMessage = "Title cannot be empty.")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Content cannot be empty.")]
        public string Content { get; set; }


    }
}
