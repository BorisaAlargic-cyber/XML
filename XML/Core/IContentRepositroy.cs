using System;
namespace XML.Core
{
    public interface IContentRepositroy : IRepository<Model.Content>
    {
        public Model.Content GetContentByPostId(int id);
    }
}
