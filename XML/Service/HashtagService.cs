using System;
using XML.Model;
using XML.Repository;

namespace XML.Service
{
    public class HashtagService
    {
        public HashtagService()
        {
        }

        public Hashtag CreateHashtag(string Name)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Hashtag dbHash = unitOfWork.Hashtags.GetTagWithName(Name);

                    if(dbHash != null)
                    {
                        return dbHash;
                    }

                    dbHash = new Hashtag();
                    dbHash.Name = Name;
                    dbHash.Deleted = false;

                    unitOfWork.Hashtags.Add(dbHash);
                    unitOfWork.Complete();

                    return dbHash;
                    
                }
            }
            catch(Exception ee)
            {
                return null;
            }
        }
    }
}
