using System;
using XML.Model;
using XML.Repository;

namespace XML.Service
{
    public class FollowerService
    {
        public FollowerService()
        {
        }

        public Follower Following(int userIdFollowed,User currentUser)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                { 
                    User dbUserFollowed = unitOfWork.Users.Get(userIdFollowed);

                    Follower follower = new Follower();

                    follower.UserFollowing = currentUser;
                    follower.UserFollowed = dbUserFollowed;

                    unitOfWork.Followers.Update(follower);
                    unitOfWork.Complete();

                    return follower;
                }
            }catch(Exception e)
            {
                return null;
            }
        }
        public Follower Accept(int followedId)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Follower follower = unitOfWork.Followers.Get(followedId);
                    follower.AcceptedFollow = true;


                    unitOfWork.Followers.Update(follower);
                    unitOfWork.Complete();

                    return follower;
                }
            }catch(Exception e)
            {
                return null;
            }
        }
        public Follower Decline(int followedId)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Follower follower = unitOfWork.Followers.Get(followedId);
                    follower.AcceptedFollow = false;

                    unitOfWork.Followers.Update(follower);
                    unitOfWork.Complete();

                    return follower;
                }
            }catch(Exception e)
            {
                return null;
            }
        }
    }
}
