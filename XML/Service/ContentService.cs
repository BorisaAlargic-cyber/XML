using System;
using XML.Model;
using XML.Repository;

namespace XML.Service
{
    public class ContentService
    {
        public ContentService()
        {
        }

        public Content GetContentForPost(int postId)
        {
            Content content = null;

            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    content = unitOfWork.Contents.GetContentByPostId(postId);

                    return content;
                }
            }
            catch (Exception ex)
            {
                return content;
            }

        }
    }
}
