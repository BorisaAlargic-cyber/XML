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
                    follower.isedFollowing = true;

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

        public Follower CheckFollowing(int followedId,User currentUser)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Follower dbIsFollower = unitOfWork.Followers.isFollowing(currentUser.Id, followedId);

                    return dbIsFollower;
                    



                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public Follower UnFollow(User currentUser,int userFpllowedId)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new XMLContext()))
                {
                    Follower dbFollower = unitOfWork.Followers.isFollowing(currentUser.Id,userFpllowedId);

                    dbFollower.isedFollowing = false;

                    unitOfWork.Followers.Update(dbFollower);
                    unitOfWork.Complete();

                    return dbFollower;
                }
            }catch(Exception e)
            {
                return null;
            }
        }
    }
}
