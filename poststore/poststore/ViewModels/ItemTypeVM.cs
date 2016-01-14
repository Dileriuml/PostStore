using PostStore.Data.Models;

namespace PostStore.ViewModels
{
    public class ItemTypeVM : VMBase
    {
        public PostType PostType { get; private set; }

        public ItemTypeVM(PostType type)
        {
            PostType = type;
        }
    }
}
